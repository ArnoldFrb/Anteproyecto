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
    public class AgregarEvaluacionAProyectoService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProyectoRepository _proyectoRepository;
        private readonly IMailServer _mailServer;

        public AgregarEvaluacionAProyectoService(IUnitOfWork unitOfWork, IProyectoRepository proyectoRepository, IMailServer mailServer)
        {
            _unitOfWork = unitOfWork;
            _proyectoRepository = proyectoRepository;
            _mailServer = mailServer;
        }

        public MensageEvaluacionAProyectoResponse AgregarEvaluacion(AgregarEvaluacionAProyectoReques request)
        {
            var proyecto = _proyectoRepository.FindFirstOrDefault(proyect => proyect.Id == request.Id);
            if (proyecto != null)
            {
                var res = proyecto.Evaluar(request.Evaluacion);
                if (res.Equals($"Nueva Evaluacion: {request.Evaluacion.Nombre}"))
                {
                    _unitOfWork.Commit();
                    return new MensageEvaluacionAProyectoResponse(res);
                }
                else
                {
                    return new MensageEvaluacionAProyectoResponse(res);
                }
            }
            else
            {
                return new MensageEvaluacionAProyectoResponse($"No existe el Proyecto: {proyecto.Nombre}");
            }
        }

        public record AgregarEvaluacionAProyectoReques
        (
            int Id,
            string Nombre,
            string Resumen,
            List<Observacion> Obsercion,
            Evaluacion Evaluacion,
            AsesorTematico AsesorTematico,
            AsesorMetodologico AsesorMetodologico
        );

        public record MensageEvaluacionAProyectoResponse(string Mensaje);
    }
}
