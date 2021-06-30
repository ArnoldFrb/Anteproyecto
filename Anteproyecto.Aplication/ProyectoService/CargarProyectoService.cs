using Anteproyecto.Domain.Contracts;
using Anteproyecto.Domain.Entities;
using Anteproyecto.Domain.Repositories;
using System;

namespace Anteproyecto.Aplication.ProyectoService
{
    public class CargarProyectoService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IProyectoRepository _proyectoRepository;
        private readonly IConvocatoriaRepository _convocatoriaRepository;
        private readonly IMailServer _mailServer;

        public CargarProyectoService(IUnitOfWork unitOfWork, IUsuarioRepository usuarioRepository, IProyectoRepository proyectoRepository, IConvocatoriaRepository convocatoriaRepository, IMailServer mailServer)
        {
            _unitOfWork = unitOfWork;
            _usuarioRepository = usuarioRepository;
            _proyectoRepository = proyectoRepository;
            _convocatoriaRepository = convocatoriaRepository;
            _mailServer = mailServer;
        }

        public CargarProyectoResponse CargarProyecto(CargarProyectoRequest request)
        {
            var conv = _convocatoriaRepository.FindFirstOrDefault(doc => DateTime.Now >= doc.FechaInicio);
            if (conv != null)
            {
                var user1 = (Estudiante)_usuarioRepository.FindFirstOrDefault(t => t.NumeroIdentificacion == request.IdEstudiante1.ToString());
                if (user1 != null)
                {
                    var user2 = (Estudiante)_usuarioRepository.FindFirstOrDefault(t => t.NumeroIdentificacion == request.IdEstudiante2.ToString());
                    if (user2 != null)
                    {
                        var AsesorTematico = (AsesorTematico)_usuarioRepository.FindFirstOrDefault(t => t.NumeroIdentificacion == request.IdAsesorTematico.ToString());
                        if (AsesorTematico != null)
                        {
                            var AsesorMetodologico = (AsesorMetodologico)_usuarioRepository.FindFirstOrDefault(t => t.NumeroIdentificacion == request.IdAsesorMetodologico.ToString());
                            if (AsesorMetodologico != null)
                            {
                                var proy = new Proyecto(); 
                                var res = proy.CargarProyecto(request.Nombre, request.Resumen, request.Url_Archive, request.Focus, request.Cut, request.Line,
                                    DateTime.Now, request.State, AsesorTematico, AsesorMetodologico, user1, user2);

                                if (res.Equals($"Operacion Exitoza: Su proyecto {proy.Nombre} ha sido cargado"))
                                {

                                    _proyectoRepository.Add(proy);
                                    _unitOfWork.Commit();
                                    return new CargarProyectoResponse(res);
                                }
                                else
                                {
                                    return new CargarProyectoResponse(res);
                                }
                            }
                            else
                            {
                                return new CargarProyectoResponse($"El Asesor Metodologico identificado con la cedula {request.IdAsesorTematico} no existe.");
                            }
                        }
                        else
                        {
                            return new CargarProyectoResponse($"El Asesor Tematico identificado con la cedula {request.IdAsesorMetodologico} no existe.");
                        }
                    }
                    else
                    {
                        return new CargarProyectoResponse($"El Usuario identificado con la cedula {request.IdEstudiante1} no existe.");
                    }
                }
                else
                {
                    return new CargarProyectoResponse($"El Usuario identificado con la cedula {request.IdEstudiante2} no existe.");
                }
            }
            else
            {
                return new CargarProyectoResponse("No existe Convocatoria para este proceso");
            }
        }

        public record CargarProyectoRequest 
        (
            string Nombre,
            string Resumen,
            string Url_Archive,
            string Focus,
            int Cut,
            string Line,
            int State,
            string IdEstudiante1,
            string IdEstudiante2,
            string IdAsesorTematico,
            string IdAsesorMetodologico
        );

        public record CargarProyectoResponse(string Mensaje);
    }
}
