using Anteproyecto.Domain.Contracts;
using Anteproyecto.Domain.Entities;
using Anteproyecto.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anteproyecto.Aplication
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

        public string CrearConvocatoria(CrearConvocatoriaRequest request)
        {
            Convocatoria convocatoria = ConvocatoriaNueva.EstablerConvocatoria(request.FechaInicio, request.FechaCierre);
            if (convocatoria != null)
            {
                _convocatoriaRepository.Add(convocatoria);
                _unitOfWork.Commit();
                return $"Se ha añadido la sigiente convocatoria, Inicio: {convocatoria.FechaInicio} / Fin: {convocatoria.FechaCierre}.";
            }
            else
            {
                return $"Error al establecer la convocatoria";
            }
        }

        public class CrearConvocatoriaRequest
        {
            public DateTime FechaInicio { get; set; }
            public DateTime FechaCierre { get; set; }
            public bool CargarProyectos { get; set; }
        }

        public static class ConvocatoriaNueva
        {
            public static Convocatoria EstablerConvocatoria(DateTime fechaInicio, DateTime fechaCierre)
            {
                if (fechaInicio < fechaCierre)
                {
                    return new Convocatoria(fechaInicio, fechaCierre);
                }
                return null;
            }
        }
    }
}
