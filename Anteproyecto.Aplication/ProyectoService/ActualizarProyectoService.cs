using Anteproyecto.Domain.Contracts;
using Anteproyecto.Domain.Entities;
using Anteproyecto.Domain.Repositories;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anteproyecto.Aplication.ProyectoService
{
    public class ActualizarProyectoService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProyectoRepository _proyectoRepository;
        private readonly IMailServer _mailServer;

        public ActualizarProyectoService(IUnitOfWork unitOfWork, IProyectoRepository proyectoRepository, IMailServer mailServer)
        {
            _unitOfWork = unitOfWork;
            _proyectoRepository = proyectoRepository;
            _mailServer = mailServer;
        }


        public ActualizarProyectoResponse ActualizarProyecto(ActualizarProyectoRequest request)
        {
            Proyecto proyecto = _proyectoRepository.Find(request.Id);
            if (proyecto != null)
            {
                string path = Path.GetFullPath("../../../../Anteproyecto.Infrastructure.WebApi/");
                FileInfo fi = new FileInfo(request.Archivo.FileName);
                string nameFile = "Archivos/" + DateTime.Now.Ticks.ToString() + fi.Extension;
                string filepatch = Path.Combine(path, nameFile);

                using (var stream = File.Create(filepatch))
                {
                    request.Archivo.CopyTo(stream);
                }

                var res = proyecto.actualizarArchivo(nameFile);

                _proyectoRepository.Edit(proyecto);
                _unitOfWork.Commit();
                return new ActualizarProyectoResponse(res);
            }
            else
            {
                return new ActualizarProyectoResponse("El proyecto no esta registrado.");
            }
        }

        public record ActualizarProyectoRequest
        (
            int Id,
            IFormFile Archivo
        );
         
        public record ActualizarProyectoResponse(string Mensaje);

    }
}
