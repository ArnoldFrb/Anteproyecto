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
    public class AgregarObservacionAProyectoService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProyectoRepository _proyectoRepository;
        private readonly IObservacionRepository _observacionRepository;
        private readonly IMailServer _mailServer;

        public AgregarObservacionAProyectoService(IUnitOfWork unitOfWork, IProyectoRepository proyectoRepository, IObservacionRepository observacionRepository, IMailServer mailServer)
        {
            _unitOfWork = unitOfWork;
            _proyectoRepository = proyectoRepository;
            _observacionRepository = observacionRepository;
            _mailServer = mailServer;
        }

        public MensageObservacionAProyectoResponse AgregarObservacion(AgregarObservacionAProyectoReques request)
        {
            var proyecto = _proyectoRepository.FindFirstOrDefault(proyect => proyect.Id == request.Id);
            if (proyecto != null)
            {
                var obser = _observacionRepository.FindFirstOrDefault(doc => doc.Id == request.Obsercion.Id);
                if (obser != null)
                {
                    var res = proyecto.Observar(request.Obsercion);
                    if (res.Equals($"Nueva Observacon: {request.Obsercion.Nombre}"))
                    {
                        _unitOfWork.Commit();
                        return new MensageObservacionAProyectoResponse(res);
                    }
                    else
                    {
                        return new MensageObservacionAProyectoResponse(res);
                    }
                }
                else
                {
                    return new MensageObservacionAProyectoResponse($"No existe el Obsercion: { request.Obsercion.Nombre}");
                }
            }
            else
            {
                return new MensageObservacionAProyectoResponse($"No existe el Proyecto: {proyecto.Nombre}");
            }
        }

        public record AgregarObservacionAProyectoReques
        (
            int Id,
            string Nombre,
            string Resumen,
            Observacion Obsercion,
            Evaluacion Evaluacion,
            AsesorTematico AsesorTematico,
            AsesorMetodologico AsesorMetodologico
        );

        public record MensageObservacionAProyectoResponse(string Mensaje);
    }
}
