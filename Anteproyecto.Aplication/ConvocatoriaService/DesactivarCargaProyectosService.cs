using Anteproyecto.Domain.Contracts;
using Anteproyecto.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anteproyecto.Aplication.ConvocatoriaService
{
    public class DesactivarCargaProyectosService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConvocatoriaRepository _convocatoriaRepository;
        private readonly IMailServer _mailServer;

        public DesactivarCargaProyectosService(IUnitOfWork unitOfWork, IConvocatoriaRepository convocatoriaRepository, IMailServer mailServer)
        {
            _unitOfWork = unitOfWork;
            _convocatoriaRepository = convocatoriaRepository;
            _mailServer = mailServer;
        }

        public DesactivarCargaProyectosResponse DesactivarCargaProyectos(DesactivarCargaProyectosRequest request)
        {
            var convocatoria = _convocatoriaRepository.FindFirstOrDefault(conv => conv.Id == request.Id);

            if (convocatoria != null)
            {
                var res = convocatoria.DesactivarCargaProyectos();

                if (res.Equals("Carga de proyectos desactivada."))
                {
                    _unitOfWork.Commit();
                    return new DesactivarCargaProyectosResponse(res);
                }
                else
                {
                    return new DesactivarCargaProyectosResponse(res);
                }
            }
            else
            {
                return new DesactivarCargaProyectosResponse("No existe la convocatoria");
            }
        }

        public record DesactivarCargaProyectosRequest
        (
            int Id
        );

        public record DesactivarCargaProyectosResponse(string Mensaje);
    }
}
