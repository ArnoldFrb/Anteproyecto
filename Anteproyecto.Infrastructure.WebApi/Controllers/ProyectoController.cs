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
using static Anteproyecto.Aplication.ProyectoService.ActualizarProyectoService;
using static Anteproyecto.Aplication.ProyectoService.AgregarAsesorMetodoloficoService;
using static Anteproyecto.Aplication.ProyectoService.AgregarAsesorTematicoService;
using static Anteproyecto.Aplication.ProyectoService.CargarProyectoService;
using static Anteproyecto.Aplication.ProyectoService.ListProyectosService;

namespace Anteproyecto.Infrastructure.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProyectoController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProyectoRepository _proyectoRepository;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IConvocatoriaRepository _convocatoriaRepository;
        private readonly IMailServer _mailServer;
        private readonly IWebHostEnvironment _appEnvironment;

        public ProyectoController(IUnitOfWork unitOfWork, IProyectoRepository proyectoRepository, IUsuarioRepository usuarioRepository, IConvocatoriaRepository convocatoriaRepository, IMailServer mailServer, IWebHostEnvironment appEnvironment)
        {
            _unitOfWork = unitOfWork;
            _usuarioRepository = usuarioRepository;
            _proyectoRepository = proyectoRepository;
            _usuarioRepository = usuarioRepository;
            _convocatoriaRepository = convocatoriaRepository;
            _mailServer = mailServer;
            _appEnvironment = appEnvironment;
        }

        [HttpPost("Cargar")]
        public CargarProyectoResponse PostCargarProyecto([FromForm] CargarProyectoRequest request)
        {
            var service = new CargarProyectoService(_unitOfWork, _usuarioRepository, _proyectoRepository, _convocatoriaRepository, _mailServer);
            var response = service.CargarProyecto(request, _appEnvironment.ContentRootPath);

            return response;
        }

        [HttpPost("Correfir")]
        public ActualizarProyectoResponse PostCargarProyecto(ActualizarProyectoRequest request)
        {
            var service = new ActualizarProyectoService(_unitOfWork, _proyectoRepository, _mailServer);
            var response = service.ActualizarProyecto(request);

            return response;
        }

        [HttpPost("List")]
        public ListProyectosResponse GetProyectos()
        {
            var servicio = new ListProyectosService(_unitOfWork,_proyectoRepository);
            var response = servicio.List();

            return response;
        }

        [HttpPost("AsesorMetodolofico")]
        public AgregarAsesorMetodoloficoResponse AgregarAsesorMetodolofico(AgregarAsesorMetodoloficoRequest request)
        {
            var servicio = new AgregarAsesorMetodoloficoService(_unitOfWork, _proyectoRepository, _usuarioRepository, _mailServer);
            var response = servicio.AgregarAsesor(request);

            return response;
        }

        [HttpPost("AsesorTematico")]
        public AgregarAsesorTematicoResponse AgregarAsesorTematico(AgregarAsesorTematicoReques request)
        {
            var servicio = new AgregarAsesorTematicoService(_unitOfWork, _proyectoRepository, _usuarioRepository, _mailServer);
            var response = servicio.AgregarAsesor(request);

            return response;
        }

    }
}
