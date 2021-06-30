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
    public class AgregarEvaluacionService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProyectoRepository _proyectoRepository;
        private readonly IEvaluacionRepository _evaluacionRepository;
        private readonly IMailServer _mailServer;

        public AgregarEvaluacionService(IUnitOfWork unitOfWork, IProyectoRepository proyectoRepository, IEvaluacionRepository evaluacionRepository, IMailServer mailServer)
        {
            _unitOfWork = unitOfWork;
            _proyectoRepository = proyectoRepository;
            _evaluacionRepository = evaluacionRepository;
            _mailServer = mailServer;
        }

        public AgregarEvaluacionResponse AgregarEvaluacion(AgregarEvaluacionRequest request)
        {
            var proyecto = _proyectoRepository.FindFirstOrDefault(proyect => proyect.Id == request.IdProyecto);
            if (proyecto != null)
            {
                var eval = new Evaluacion();
                var res = eval.AgregarEvaluacion(request.Nombre, request.Comentario, request.Estado, proyecto);
                if (res.Equals($"Nueva Evaluacion: {eval.Nombre}"))
                {
                    _evaluacionRepository.Add(eval);
                    _mailServer.Send(eval.Proyecto.Estudiante1.Correo, "Nueva evaluacion agregada", eval.enviarPlantillaCorreo());
                    _unitOfWork.Commit();

                    return new AgregarEvaluacionResponse(res);
                }
                else
                {
                    return new AgregarEvaluacionResponse(res);
                }
            }
            else
            {
                return new AgregarEvaluacionResponse("No existe el Proyecto a Evaluar");
            }
        }

        public record AgregarEvaluacionRequest
        (
            string Nombre,
            string Comentario,
            bool Estado,
            int IdProyecto
        );

        public record AgregarEvaluacionResponse(string Mensaje);
    }
}
