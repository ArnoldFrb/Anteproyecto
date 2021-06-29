using Anteproyecto.Aplication.ConvocatoriaService;
using Anteproyecto.Domain.Contracts;
using Anteproyecto.Domain.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Anteproyecto.Aplication.ConvocatoriaService.ActivarCargaProyectosService;
using static Anteproyecto.Aplication.ConvocatoriaService.CrearConvocatoriaService;
using static Anteproyecto.Aplication.ConvocatoriaService.DesactivarCargaProyectosService;

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

        [HttpPost("CrearConvocatoria")]
        public CrearConvocatoriaResponse PostCrearConvocatoria(CrearConvocatoriaRequest request)
        {
            var service = new CrearConvocatoriaService(_unitOfWork, _convocatoriaRepository, _mailServer);
            var response = service.CrearConvocatoria(request);
            
            return response;
        }

        [HttpPost("ActivarCargaProyectos")]
        public ActivarCargaProyectosResponse PostActivarCargaProyectos(ActivarCargaProyectosRequest request)
        {
            var service = new ActivarCargaProyectosService(_unitOfWork, _convocatoriaRepository, _mailServer);
            var response = service.ActivarCargaProyectos(request);

            return response;
        }

        [HttpPost("DesactivarCargaProyectos")]
        public DesactivarCargaProyectosResponse PostDesactivarCargaProyectos(DesactivarCargaProyectosRequest request)
        {
            var service = new DesactivarCargaProyectosService(_unitOfWork, _convocatoriaRepository, _mailServer);
            var response = service.DesactivarCargaProyectos(request);

            return response;
        }
    }
}
