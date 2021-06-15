using Anteproyecto.Aplication;
using Anteproyecto.Domain.Contracts;
using Anteproyecto.Domain.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Anteproyecto.Aplication.ConvocatoriaService;
using static Anteproyecto.Aplication.CrearConvocatoriaService;

namespace Anteproyecto.Infrastructure.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConvocatoriaController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConvocatoriaRepository _convocatoriaRepository;
        private readonly IMailServer _mailServer;

        public ConvocatoriaController(IUnitOfWork unitOfWork, IConvocatoriaRepository convocatoriaRepository, IMailServer mailServer)
        {
            _unitOfWork = unitOfWork;
            _convocatoriaRepository = convocatoriaRepository;
            _mailServer = mailServer;
        }

        [HttpPost("modificar-convocatoria")]
        public MensageConvocatoriaResponse PostValidarNombre(ConvocatoriaRequest convocatoriaRequest)
        {
            var service = new ConvocatoriaService(_unitOfWork, _convocatoriaRepository, _mailServer);
            var response = service.ModificarConvocatoria(convocatoriaRequest);
            return response;
        }

        [HttpPost]
        public MensageCrearConvocatoriaResponse CrearConvocatoria(CrearConvocatoriaRequest convocatoriaRequest)
        {
            var service = new CrearConvocatoriaService(_unitOfWork, _convocatoriaRepository, _mailServer);
            var response = service.CrearConvocatoria(convocatoriaRequest);
            return response;
        }
    }
}
