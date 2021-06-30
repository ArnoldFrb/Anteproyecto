using Anteproyecto.Domain.Contracts;
using Anteproyecto.Domain.Entities;
using Anteproyecto.Domain.Repositories;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;


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

        public CargarProyectoResponse CargarProyecto(CargarProyectoRequest request, string path)
        {
            var conv = _convocatoriaRepository.FindFirstOrDefault(doc => DateTime.Now >= doc.FechaInicio);
            if (conv != null)
            {
                var user1 = (Estudiante)_usuarioRepository.FindFirstOrDefault(t => t.NumeroIdentificacion == request.IdEstudiante1);
                if (user1 != null)
                {
                    var user2 = (Estudiante)_usuarioRepository.FindFirstOrDefault(t => t.NumeroIdentificacion == request.IdEstudiante2);
                    if (user2 != null)
                    {
                        var AsesorTematico = (AsesorTematico)_usuarioRepository.FindFirstOrDefault(t => t.NumeroIdentificacion == request.IdAsesorTematico);
                        if (AsesorTematico != null)
                        {
                            var AsesorMetodologico = (AsesorMetodologico)_usuarioRepository.FindFirstOrDefault(t => t.NumeroIdentificacion == request.IdAsesorMetodologico);
                            if (AsesorMetodologico != null)
                            {
                                var proyecto = new Proyecto();

                                FileInfo fi = new FileInfo(request.Archive.FileName);
                                string nameFile = "Archivos/" + DateTime.Now.Ticks.ToString() + fi.Extension;
                                string filepatch = Path.Combine(path, nameFile);

                                user1.CambiarEstado(false);
                                user2.CambiarEstado(false);

                                using (var stream = File.Create(filepatch))
                                {
                                    request.Archive.CopyTo(stream);
                                }

                                var res = proyecto.CargarProyecto(request.Nombre, request.Resumen, nameFile, request.Focus, request.Cut, request.Line,
                                    DateTime.Now, request.State, AsesorTematico, AsesorMetodologico, user1, user2);

                                if (res.Equals($"Operacion Exitoza: Su proyecto {proyecto.Nombre} ha sido cargado"))
                                {

                                    _proyectoRepository.Add(proyecto);
                                    _mailServer.Send(user1.Correo, "Proyecto cargado correctamente", proyecto.enviarPlantillaCorreo(user1.Nombres));
                                    _mailServer.Send(user2.Correo, "Proyecto cargado correctamente", proyecto.enviarPlantillaCorreo(user2.Nombres));
                                    _mailServer.Send(AsesorMetodologico.Correo, "Se le asignado un proyecto", proyecto.enviarPlantillaCorreo(AsesorMetodologico.Nombres));
                                    _mailServer.Send(AsesorTematico.Correo, "Se le asignado un proyecto", proyecto.enviarPlantillaCorreo(AsesorTematico.Nombres));
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
          string Focus,
          int Cut,
          string Line,
          IFormFile Archive,
          int State,
          string IdEstudiante1,
          string IdEstudiante2,
          string IdAsesorTematico,
          string IdAsesorMetodologico 
        );

        public record CargarProyectoResponse(string Mensaje);
    }
}