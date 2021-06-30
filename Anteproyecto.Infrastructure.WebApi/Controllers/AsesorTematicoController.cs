using Anteproyecto.Aplication.AsesorTemeticoService;
using Anteproyecto.Domain.Contracts;
using Anteproyecto.Domain.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Anteproyecto.Aplication.AsesorTemeticoService.ActualizarAsesorTematicoService;
using static Anteproyecto.Aplication.AsesorTemeticoService.ConsultarAsesorTematicoService;
using static Anteproyecto.Aplication.AsesorTemeticoService.EliminarAsesorTematicoService;
using static Anteproyecto.Aplication.AsesorTemeticoService.ListarAsesorTematicoService;
using static Anteproyecto.Aplication.AsesorTemeticoService.RegistrarAsesorTematicoService;

namespace Anteproyecto.Infrastructure.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AsesorTematicoController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMailServer _mailServer;
        public AsesorTematicoController(IUnitOfWork unitOfWork, IUsuarioRepository usuarioRepository, IMailServer mailServer)
        {
            _unitOfWork = unitOfWork;
            _usuarioRepository = usuarioRepository;
            _mailServer = mailServer;
        }

        [HttpPost("Registrar")]
        public RegistrarAsesorTematicoResponse RegistrarAsesorMetodologico(RegistrarAsesorTematicoRequest request)
        {
            var service = new RegistrarAsesorTematicoService(_unitOfWork, _usuarioRepository, _mailServer);
            var response = service.RegistrarAsesorTematico(request);
            return response;
        }

        [HttpPost("Actualizar")]
        public ActualizarAsesorTematicoResponse ActualizarAsesorMetodologico(ActualizarAsesorTematicoRequest request)
        {
            var service = new ActualizarAsesorTematicoService(_unitOfWork, _usuarioRepository, _mailServer);
            var response = service.ActualizarAsesorTematico(request);
            return response;
        }

        [HttpPost("Eliminar")]
        public EliminarAsesorTematicoResponse EliminarAsesorMetodologico(EliminarAsesorTematicoRequest request)
        {
            var service = new EliminarAsesorTematicoService(_unitOfWork, _usuarioRepository, _mailServer);
            var response = service.EliminarAsesorTematico(request);
            return response;
        }

        [HttpPost("Consultar")]
        public ConsultarAsesorTematicoResponse ConsultarAsesorMetodologico(ConsultarAsesorTematicoRequest request)
        {
            var service = new ConsultarAsesorTematicoService(_unitOfWork, _usuarioRepository, _mailServer);
            var response = service.ConsultarAsesorTematico(request);
            return response;
        }

        [HttpGet("Listar")]
        public ListarAsesorTematicoResponse GetListarAsesoresMetodologicos()
        {
            var service = new ListarAsesorTematicoService(_unitOfWork, _usuarioRepository, _mailServer);
            var response = service.ListarAsesorTematico();
            return response;
        }
    }
}
