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
    public class ListObservacionService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProyectoRepository _proyectoRepository;
        private readonly IObservacionRepository _observacionRepository;
        private readonly IMailServer _mailServer;

        public ListObservacionService(IUnitOfWork unitOfWork, IProyectoRepository proyectoRepository, IObservacionRepository observacionRepository, IMailServer mailServer)
        {
            _unitOfWork = unitOfWork;
            _proyectoRepository = proyectoRepository;
            _observacionRepository = observacionRepository;
            _mailServer = mailServer;
        }

        public ListObservacionResponse List(ListObservacionRequest request)
        {
            var proyecto = _proyectoRepository.FindFirstOrDefault(proyect => proyect.Id == request.IdProyecto);
            if (proyecto != null)
            {
                var list = _observacionRepository.FindBy(doc => doc.Proyecto.Id == request.IdProyecto);

                if (list.Count() != 0)
                {
                    return new ListObservacionResponse(list, "Observaciones del Proyecto");
                }
                else
                {
                    return new ListObservacionResponse(null, "No hay Observaciones");
                }
            }
            else
            {
                return new ListObservacionResponse(null, "No existe el Proyecto");
            }
        }


        public ListObservacionResponse listarProyectoObservaciones(int request)
        {
            var proyecto = _observacionRepository.FindBy(Proyecto => Proyecto.Proyecto.Estudiante1.Id == request || Proyecto.Proyecto.Estudiante2.Id == request, includeProperties: "Proyecto");
            if (proyecto != null)
            {
                List<Observacion> observaciones = new List<Observacion>();

                foreach (var itemlist in proyecto.ToList())
                {
                    observaciones.Add(itemlist);
                }

                if (observaciones.Count() != 0)
                {
                    return new ListObservacionResponse(observaciones, "Evaluaciones realizadas al proyecto.");
                }
                else
                {
                    return new ListObservacionResponse(null, "No hay Evaluaciones.");
                }
            }
            else
            {
                return new ListObservacionResponse(null, "No existe el Proyecto.");
            }
        }

        public record ListObservacionRequest
        (
            int IdProyecto
        );

        public record ListObservacionResponse(IEnumerable<Observacion> Observacions, string Mensaje);
    }
}
