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
            //var conv = _convocatoriaRepository.FindFirstOrDefault(doc => DateTime.Now >= doc.FechaInicio && DateTime.Now <= doc.FechaCierre);
            var conv =(Convocatoria) _convocatoriaRepository.Find(1);
            if (conv.CargarProyectos)
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
                                Proyecto proyectoCreado = new Proyecto(request.Nombre,
                                   request.Resumen, request.Focus,
                                   request.Cut, request.Line, DateTime.Now,
                                   AsesorTematico, AsesorMetodologico, user1, user2);

                                var res = proyectoCreado.CargarProyecto(proyectoCreado);
                                if (res.Equals($"Operacion Exitoza: Su proyecto {proyectoCreado.Nombre} ha sido cargado"))
                                {
                                    FileInfo fi = new FileInfo(request.Archive.FileName);
                                    string nameFile = "Archivos/" + DateTime.Now.Ticks.ToString() + fi.Extension;
                                    string filepatch = Path.Combine(path, nameFile);

                                    proyectoCreado.actualizarArchivo(nameFile);
                                    user1.CambiarEstado(false);
                                    user2.CambiarEstado(false);

                                    using (var stream = File.Create(filepatch))
                                    {
                                        request.Archive.CopyTo(stream);
                                    }
                                    _usuarioRepository.Edit(user1);
                                    _usuarioRepository.Edit(user2);
                                    _proyectoRepository.Add(proyectoCreado);
                                    _mailServer.Send(user1.Correo, "Proyecto cargado correctamente", proyectoCreado.enviarPlantillaCorreo(user1.Nombres));
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
          string IdEstudiante1,
          string IdEstudiante2,
          string IdAsesorTematico,
          string IdAsesorMetodologico 
        );

        public record CargarProyectoResponse(string Mensaje);
    }
}