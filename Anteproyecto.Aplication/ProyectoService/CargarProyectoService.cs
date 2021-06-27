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
        private readonly IMailServer _mailServer;

        public CargarProyectoService(IUnitOfWork unitOfWork, IUsuarioRepository usuarioRepository, IProyectoRepository proyectoRepository, IMailServer mailServer)
        {
            _unitOfWork = unitOfWork;
            _usuarioRepository = usuarioRepository;
            _proyectoRepository = proyectoRepository;
            _mailServer = mailServer;
        }

        public CargarProyectoResponse CargarProyecto(CargarProyectoRequest request,string path)
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
                                    AsesorTematico,AsesorMetodologico,user1,user2);

                            var res = proyectoCreado.CargarProyecto(proyectoCreado);
                            if (res.Equals("Se cargo el archivo correctamento"))
                            {
                                FileInfo fi = new FileInfo(request.Archive.FileName);
                                string nameFile = "Archivos/" + DateTime.Now.Ticks.ToString() + fi.Extension;
                                string filepatch = Path.Combine(path, nameFile);

                                proyectoCreado.actualizarArchivo(nameFile);
                                user1.CambiarEstado(false);
                                user2.CambiarEstado(false);

                                using (var stream = System.IO.File.Create(filepatch))
                                {
                                    request.Archive.CopyTo(stream);
                                }

                                _usuarioRepository.Edit(user1);
                                _usuarioRepository.Edit(user2);
                                _proyectoRepository.Add(proyectoCreado);
                                _unitOfWork.Commit();
                                return new CargarProyectoResponse($"El proyecto {request.Nombre} Se cargo correctamento.");
                            }
                            else
                            {
                                return new CargarProyectoResponse($"El proyecto {request.Nombre} Tiene la informcion incompleta.");
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
