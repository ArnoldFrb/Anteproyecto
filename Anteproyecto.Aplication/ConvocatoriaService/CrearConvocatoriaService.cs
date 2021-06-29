using Anteproyecto.Domain.Contracts;
using Anteproyecto.Domain.Entities;
using Anteproyecto.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anteproyecto.Aplication.ConvocatoriaService
{
    public class CrearConvocatoriaService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConvocatoriaRepository _convocatoriaRepository;
        private readonly IMailServer _mailServer;

        public CrearConvocatoriaService(IUnitOfWork unitOfWork, IConvocatoriaRepository convocatoriaRepository, IMailServer mailServer)
        {
            _unitOfWork = unitOfWork;
            _convocatoriaRepository = convocatoriaRepository;
            _mailServer = mailServer;
        }

        public CrearConvocatoriaResponse CrearConvocatoria(CrearConvocatoriaRequest request)
        {
            var convocatoria = new Convocatoria(request.FechaInicio, request.FechaCierre);
            var res = convocatoria.CrearConvocatoria(request.FechaInicio, request.FechaCierre, request.CargarProyectos);

            if (res.Equals($"Se ha creado la convocatoria para las fechas: Inicio: {convocatoria.FechaInicio} / Cierre: {convocatoria.FechaCierre}"))
            {
                _convocatoriaRepository.Add(convocatoria);
                _unitOfWork.Commit();
                return new CrearConvocatoriaResponse(res);
            }
            else
            {
                return new CrearConvocatoriaResponse(res);
            }
        }

        public record CrearConvocatoriaRequest
        (
            DateTime FechaInicio,
            DateTime FechaCierre,
            bool CargarProyectos
        );

        public record CrearConvocatoriaResponse(string Mensaje);
    }
}
