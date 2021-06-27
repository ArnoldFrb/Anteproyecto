using Anteproyecto.Aplication;
using Anteproyecto.Aplication.ProyectoService;
using Anteproyecto.Domain.Contracts;
using Anteproyecto.Domain.Entities;
using Anteproyecto.Domain.Repositories;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Anteproyecto.Aplication.ProyectoService.CargarProyectoService;
using static Anteproyecto.Aplication.ValidarNombreProyectoService;

namespace Anteproyecto.Infrastructure.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProyectoController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProyectoRepository _proyectoRepository;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMailServer _mailServer;
        private readonly IWebHostEnvironment _appEnvironment;

        public ProyectoController(IUnitOfWork unitOfWork, IUsuarioRepository usuarioRepository, IProyectoRepository proyectoRepository, IMailServer mailServer, IWebHostEnvironment appEnvironment)
        {
            _unitOfWork = unitOfWork;
            _usuarioRepository = usuarioRepository;
            _proyectoRepository = proyectoRepository;
            _mailServer = mailServer;
            _appEnvironment = appEnvironment;
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

        [HttpPost("[action]")]
        public ActionResult<CargarProyectoResponse> PostCargarProyecto([FromForm] CargarProyectoRequest request)
        {
            CargarProyectoService _service = new CargarProyectoService(_unitOfWork, _usuarioRepository, _proyectoRepository,_mailServer);
            CargarProyectoResponse response = _service.CargarProyecto(request, _appEnvironment.ContentRootPath);
            return Ok(response);
        }

    }
}
