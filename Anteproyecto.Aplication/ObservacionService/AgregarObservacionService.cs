using Anteproyecto.Domain.Contracts;
using Anteproyecto.Domain.Entities;
using Anteproyecto.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anteproyecto.Aplication.ObservacionService
{
    public class AgregarObservacionService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProyectoRepository _proyectoRepository;
        private readonly IObservacionRepository _observacionRepository;
        private readonly IMailServer _mailServer;

        public AgregarObservacionService(IUnitOfWork unitOfWork, IProyectoRepository proyectoRepository, IObservacionRepository observacionRepository, IMailServer mailServer)
        {
            _unitOfWork = unitOfWork;
            _proyectoRepository = proyectoRepository;
            _observacionRepository = observacionRepository;
            _mailServer = mailServer;
        }

        public AgregarObservacionResponse AgregarObservacion(AgregarObservacionRequest request)
        {
            ///var observacion = (List<Proyecto>) _observacionRepository.FindBy(x=>x.Id == request.IdProyecto, includeProperties: "Proyecto");

            var proyecto = (List<Proyecto>)_proyectoRepository.FindBy(x => x.Id == request.IdProyecto, includeProperties: "Estudiante1");

            if (proyecto != null) 
            {

                var obs = new Observacion(request.Nombre, request.Comentario);
                var res = obs.AgregarObservacion(request.Nombre, request.Comentario, proyecto[0]);
                if (res.Equals($"Nueva Observacon: {obs.Nombre}"))
                {
                    _observacionRepository.Add(obs);
                    _mailServer.Send(proyecto[0].Estudiante1.Correo, "Se agrego un nueva Observacion a su proyecto", obs.enviarPlantillaCorreo());
                    _unitOfWork.Commit();
                    return new AgregarObservacionResponse(res);
                }
                else
                {
                    return new AgregarObservacionResponse(res);
                } 
            }
            else
            {
                return new AgregarObservacionResponse($"No existe el Proyecto a Observar");
            }
        }

        public record AgregarObservacionRequest
        (
            string Nombre,
            string Comentario,
            int IdProyecto
        );

        public record AgregarObservacionResponse(string Mensaje);
    }
}
