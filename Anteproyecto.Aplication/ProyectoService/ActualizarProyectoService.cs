using Anteproyecto.Domain.Contracts;
using Anteproyecto.Domain.Entities;
using Anteproyecto.Domain.Repositories;
using System;
using System.Collections.Generic;
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
                proyecto.actualizarArchivo(request.archivo);

                _proyectoRepository.Edit(proyecto);
                _unitOfWork.Commit();
                return new ActualizarProyectoResponse("El proyecto ha sido actualizado.");
            }
            else
            {
                return new ActualizarProyectoResponse("El proyecto no esta registrado.");
            }
        }

        public record ActualizarProyectoRequest
       (
            int Id,
            string archivo
       );
         
        public record ActualizarProyectoResponse(string Mensaje);

    }
}
