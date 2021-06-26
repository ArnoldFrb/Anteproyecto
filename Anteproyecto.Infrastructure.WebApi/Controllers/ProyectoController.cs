using Anteproyecto.Aplication;
using Anteproyecto.Aplication.ProyectoService;
using Anteproyecto.Domain.Contracts;
using Anteproyecto.Domain.Entities;
using Anteproyecto.Domain.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Anteproyecto.Aplication.ValidarNombreProyectoService;

namespace Anteproyecto.Infrastructure.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProyectoController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProyectoRepository _proyectoRepository;
        private readonly IMailServer _mailServer;

        public ProyectoController(IUnitOfWork unitOfWork, IProyectoRepository proyectoRepository, IMailServer mailServer)
        {
            _unitOfWork = unitOfWork;
            _proyectoRepository = proyectoRepository;
            _mailServer = mailServer;
        }

        [HttpPost]
        public MensageProyectoResponse PostValidarNombre(ProyectoRequest proyectoRequest)
        {
            var service = new ValidarNombreProyectoService(_unitOfWork, _proyectoRepository, _mailServer);
            var response = service.ValidarNombre(proyectoRequest);
            return response;
        }

        [HttpGet("[action]")]
        public ActionResult<IEnumerable<Proyecto>> GetProyectos()
        {
            ConsultarProyectoService servicio = new ConsultarProyectoService(_unitOfWork,_proyectoRepository);
            List<Proyecto> Lista = servicio.GetAll();

            return Ok(Lista);
        }
    }
}
