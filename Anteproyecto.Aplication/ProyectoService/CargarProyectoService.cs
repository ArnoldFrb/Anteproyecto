using Anteproyecto.Domain.Contracts;
using Anteproyecto.Domain.Entities;
using Anteproyecto.Domain.Repositories;

namespace Anteproyecto.Aplication.ProyectoService
{
    public class CargarProyectoService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IProyectoRepository _proyectoRepository;
        private readonly IMailServer _mailServer;

        public CargarProyectoService(IUnitOfWork unitOfWork, IUsuarioRepository usuarioRepository, IProyectoRepository proyectoRepository, IMailServer mailServer)
        {
            _unitOfWork = unitOfWork;
            _usuarioRepository = usuarioRepository;
            _proyectoRepository = proyectoRepository;
            _mailServer = mailServer;
        }

        public CargarProyectoResponse CargarProyecto(CargarProyectoRequest request)
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
                            var res = user1.CargarProyecto(request.Proyecto);
                            if (res.Equals($"Operacion exitoza: Se ha cargado el proyecto {request.Proyecto.Nombre}"))
                            {
                                //string nombre, string resumen, string url_Archive, string focus, int cut, string line, DateTime date, int state
                                Proyecto proyectoCreado = new Proyecto(request.Proyecto.Nombre,
                                    request.Proyecto.Resumen, request.Proyecto.Url_Archive, request.Proyecto.Focus,
                                    request.Proyecto.Cut, request.Proyecto.Line, request.Proyecto.Date, request.Proyecto.State);

                                proyectoCreado.AsignarEstudianteUno(user1);
                                proyectoCreado.AsignarEstudianteDos(user2);
                                proyectoCreado.AsignarAsesorTematico(AsesorTematico);
                                proyectoCreado.AsignarAsesorMetodologico(AsesorMetodologico);


                                _proyectoRepository.Add(proyectoCreado);
                                _unitOfWork.Commit();
                                return new CargarProyectoResponse(res);
                            }
                            else
                            {
                                return new CargarProyectoResponse($"El proyecto {request.Proyecto.Nombre} no tiene el formato valido.");
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

        public record CargarProyectoRequest 
        (
            string IdEstudiante1,
            string IdEstudiante2,
            string IdAsesorTematico,
            string IdAsesorMetodologico,
            Proyecto Proyecto
        );

        public record CargarProyectoResponse(string Mensaje);
    }
}
