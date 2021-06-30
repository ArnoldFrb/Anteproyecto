using Anteproyecto.Domain.Contracts;
using Anteproyecto.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anteproyecto.Aplication.ConvocatoriaService
{
    public class ActivarCargaProyectosService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConvocatoriaRepository _convocatoriaRepository;
        private readonly IMailServer _mailServer;

        public ActivarCargaProyectosService(IUnitOfWork unitOfWork, IConvocatoriaRepository convocatoriaRepository, IMailServer mailServer)
        {
            _unitOfWork = unitOfWork;
            _convocatoriaRepository = convocatoriaRepository;
            _mailServer = mailServer;
        }

        public ActivarCargaProyectosResponse ActivarCargaProyectos(ActivarCargaProyectosRequest request)
        {
            var convocatoria = _convocatoriaRepository.FindFirstOrDefault(conv => conv.Id == request.Id);

            if (convocatoria != null)
            {
                var res = convocatoria.ActivarCargaProyectos();

                if (res.Equals("Carga de proyectos activada."))
                {
                    _unitOfWork.Commit();
                    return new ActivarCargaProyectosResponse(res);
                }
                else
                {
                    return new ActivarCargaProyectosResponse(res);
                }
            }
            else
            {
                return new ActivarCargaProyectosResponse("No existe la convocatoria");
            }
        }

        public record ActivarCargaProyectosRequest
        (
            int Id
        );

        public record ActivarCargaProyectosResponse(string Mensaje);
    }
}
