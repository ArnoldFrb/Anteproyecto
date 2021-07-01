using Anteproyecto.Domain.Contracts;
using Anteproyecto.Domain.Entities;
using Anteproyecto.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anteproyecto.Aplication.EvaluacionService
{
    public class ListEvaluacionService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProyectoRepository _proyectoRepository;
        private readonly IEvaluacionRepository _evaluacionRepository;
        private readonly IMailServer _mailServer;

        public ListEvaluacionService(IUnitOfWork unitOfWork, IProyectoRepository proyectoRepository, IEvaluacionRepository evaluacionRepository, IMailServer mailServer)
        {
            _unitOfWork = unitOfWork;
            _proyectoRepository = proyectoRepository;
            _evaluacionRepository = evaluacionRepository;
            _mailServer = mailServer;
        }

        public ListEvaluacionResponse List(ListEvaluacionRequest request)
        {
            var proyecto = _proyectoRepository.FindFirstOrDefault(proyect => proyect.Id == request.IdProyecto);
            if (proyecto != null)
            {
                var list = _evaluacionRepository.FindBy(doc => doc.Proyecto.Id == request.IdProyecto);
                if (list.Count() != 0)
                {
                    return new ListEvaluacionResponse(list, "Evaluaciones del Proyecto.");
                }
                else
                {
                    return new ListEvaluacionResponse(null, "No hay Evaluaciones.");
                }
            }
            else
            {
                return new ListEvaluacionResponse(null, "No existe el Proyecto.");
            }
        }


        public ListEvaluacionResponse ProyectosEvaluados(int request)
        {

            ///var proyecto = _proyectoRepository.FindFirstOrDefault(proyect => proyect.Id == request.ToString());
            var proyecto = _evaluacionRepository.FindBy(Proyecto => Proyecto.Proyecto.Estudiante1.Id == request || Proyecto.Proyecto.Estudiante2.Id == request, includeProperties: "Proyecto");
            if (proyecto != null)
            {
                List<Evaluacion> evaluacions = new List<Evaluacion>();

                foreach (var itemlist in proyecto.ToList())
                {
                    evaluacions.Add(itemlist);
                } 

                if (evaluacions.Count() != 0)
                {
                    return new ListEvaluacionResponse(evaluacions, "Evaluaciones realizadas al proyecto.");
                }
                else
                {
                    return new ListEvaluacionResponse(null, "No hay Evaluaciones.");
                }
            }
            else
            {
                return new ListEvaluacionResponse(null, "No existe el Proyecto.");
            }
            
        }

        public record ListEvaluacionRequest
        (
            int IdProyecto
        );

        public record ListEvaluacionResponse(IEnumerable<Evaluacion> Evaluacions, string Mensaje);
    }
}
