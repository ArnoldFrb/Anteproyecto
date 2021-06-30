using Anteproyecto.Aplication.ObservacionService;
using Anteproyecto.Domain.Contracts;
using Anteproyecto.Domain.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Anteproyecto.Aplication.ObservacionService.AgregarObservacionService;
using static Anteproyecto.Aplication.ObservacionService.ListObservacionService;

namespace Anteproyecto.Infrastructure.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ObservacionController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProyectoRepository _proyectoRepository;
        private readonly IObservacionRepository _observacionRepository;
        private readonly IMailServer _mailServer;

        public ObservacionController(IUnitOfWork unitOfWork, IProyectoRepository proyectoRepository, IObservacionRepository observacionRepository, IMailServer mailServer)
        {
            _unitOfWork = unitOfWork;
            _proyectoRepository = proyectoRepository;
            _observacionRepository = observacionRepository;
            _mailServer = mailServer;
        }

        [HttpPost("Agregar")]
        public AgregarObservacionResponse PostAgregarObservacion(AgregarObservacionRequest request)
        {
            var servicio = new AgregarObservacionService(_unitOfWork, _proyectoRepository, _observacionRepository, _mailServer);
            var response = servicio.AgregarObservacion(request);

            return response;
        }

        [HttpPost("List")]
        public ListObservacionResponse PostList(ListObservacionRequest request)
        {
            var servicio = new ListObservacionService(_unitOfWork, _proyectoRepository, _observacionRepository, _mailServer);
            var response = servicio.List(request);

            return response;
        }
    }
}
