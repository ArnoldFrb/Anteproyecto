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
            var proyecto = _proyectoRepository.FindFirstOrDefault(proyect => proyect.Id == request.IdProyecto);
            if (proyecto != null)
            {
                var obs = new Observacion(request.Nombre, request.Comentario);
                var res = obs.AgregarObservacion(request.Nombre, request.Comentario, proyecto);
                if (res.Equals($"Nueva Observacon: {obs.Nombre}"))
                {
                    _observacionRepository.Add(obs);
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
