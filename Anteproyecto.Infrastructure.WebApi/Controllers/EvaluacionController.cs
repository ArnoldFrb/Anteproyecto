using Anteproyecto.Aplication.EvaluacionService;
using Anteproyecto.Domain.Contracts;
using Anteproyecto.Domain.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Anteproyecto.Aplication.EvaluacionService.AgregarEvaluacionService;
using static Anteproyecto.Aplication.EvaluacionService.ListEvaluacionService;

namespace Anteproyecto.Infrastructure.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EvaluacionController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProyectoRepository _proyectoRepository;
        private readonly IEvaluacionRepository _evaluacionRepository;
        private readonly IMailServer _mailServer;

        public EvaluacionController(IUnitOfWork unitOfWork, IProyectoRepository proyectoRepository, IEvaluacionRepository evaluacionRepository, IMailServer mailServer)
        {
            _unitOfWork = unitOfWork;
            _proyectoRepository = proyectoRepository;
            _evaluacionRepository = evaluacionRepository;
            _mailServer = mailServer;
        }

        [HttpPost("Agregar")]
        public AgregarEvaluacionResponse PostAgregarEvaluacion(AgregarEvaluacionRequest request)
        {
            var servicio = new AgregarEvaluacionService(_unitOfWork, _proyectoRepository, _evaluacionRepository, _mailServer);
            var response = servicio.AgregarEvaluacion(request);

            return response;
        }

        [HttpPost("List")]
        public ListEvaluacionResponse PostList(ListEvaluacionRequest request)
        {
            var servicio = new ListEvaluacionService(_unitOfWork, _proyectoRepository, _evaluacionRepository, _mailServer);
            var response = servicio.List(request);

            return response;
        }
    }
}
