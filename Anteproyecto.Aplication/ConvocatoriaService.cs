using Anteproyecto.Domain.Contracts;
using Anteproyecto.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anteproyecto.Aplication
{
    public class ConvocatoriaService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConvocatoriaRepository _convocatoriaRepository;
        private readonly IMailServer _mailServer;

        public ConvocatoriaService(IUnitOfWork unitOfWork, IConvocatoriaRepository convocatoriaRepository, IMailServer mailServer)
        {
            _unitOfWork = unitOfWork;
            _convocatoriaRepository = convocatoriaRepository;
            _mailServer = mailServer;
        }

        public MensageResponse ModificarConvocatoria(ConvocatoriaRequest request)
        {
            var convocatoria = _unitOfWork.ConvocatoriaRepository.FindFirstOrDefault(conv => conv.Id == request.Id);

            if (convocatoria != null)
            {
                convocatoria.ModificarConvocatoria(request.FechaInicio, request.FechaCierre);
                _unitOfWork.Commit();
                return new MensageResponse() { Mensaje = "La convovatoria ha sido modificada correctamente" };
            }
            else
            {
                return new MensageResponse() { Mensaje = "Error al modificar la convocatoria" };
            }
        }

        public MensageResponse ActivarCargaProyectos(ConvocatoriaRequest request)
        {
            var convocatoria = _unitOfWork.ConvocatoriaRepository.FindFirstOrDefault(conv => conv.Id == request.Id);

            if (convocatoria != null)
            {
                convocatoria.ActivarCargaProyectos();
                _unitOfWork.Commit();
                return new MensageResponse() { Mensaje = "La carga de proyectos ha sido activada" };
            }
            else
            {
                return new MensageResponse() { Mensaje = "Error al activar la carga de proyectos" };
            }
        }

        public MensageResponse DesactivarCargaProyectos(ConvocatoriaRequest request)
        {
            var convocatoria = _unitOfWork.ConvocatoriaRepository.FindFirstOrDefault(conv => conv.Id == request.Id);

            if (convocatoria != null)
            {
                convocatoria.DesactivarCargaProyectos();
                _unitOfWork.Commit();
                return new MensageResponse() { Mensaje = "La carga de proyectos ha sido desactivada" };
            }
            else
            {
                return new MensageResponse() { Mensaje = "Error al desactivada la carga de proyectos" };
            }
        }

        public class ConvocatoriaRequest
        {
            public int Id { get; set; }
            public DateTime FechaInicio { get; set; }
            public DateTime FechaCierre { get; set; }
            public bool CargarProyectos { get; set; }
        }

        public class MensageResponse
        {
            public string Mensaje { get; set; }
        }
    }
}
