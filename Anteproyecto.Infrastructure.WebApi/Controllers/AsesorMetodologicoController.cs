using Anteproyecto.Aplication.AsesorMetodologicoService;
using Anteproyecto.Domain.Contracts;
using Anteproyecto.Domain.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Anteproyecto.Aplication.AsesorMetodologicoService.ActualizarAsesorMetodologicoService;
using static Anteproyecto.Aplication.AsesorMetodologicoService.ConsultarAsesorMetodologicoService;
using static Anteproyecto.Aplication.AsesorMetodologicoService.EliminarAsesorMetodologicoService;
using static Anteproyecto.Aplication.AsesorMetodologicoService.ListarAsesoresMetodologicosService;
using static Anteproyecto.Aplication.AsesorMetodologicoService.RegistrarAsesorMetodologicoService;

namespace Anteproyecto.Infrastructure.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AsesorMetodologicoController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMailServer _mailServer;
        public AsesorMetodologicoController(IUnitOfWork unitOfWork, IUsuarioRepository usuarioRepository, IMailServer mailServer)
        {
            _unitOfWork = unitOfWork;
            _usuarioRepository = usuarioRepository;
            _mailServer = mailServer;
        }

        [HttpPost("Registrar")]
        public RegistrarAsesorMetodologicoResponse RegistrarAsesorMetodologico(RegistrarAsesorMetodologicoRequest request)
        {
            var service = new RegistrarAsesorMetodologicoService(_unitOfWork, _usuarioRepository, _mailServer);
            var response = service.RegistrarAsesorMetodologico(request);
            return response;
        }

        [HttpPost("Actualizar")]
        public ActualizarAsesorMetodologicoResponse ActualizarAsesorMetodologico(ActualizarAsesorMetodologicoRequest request)
        {
            var service = new ActualizarAsesorMetodologicoService(_unitOfWork, _usuarioRepository, _mailServer);
            var response = service.ActualizarAsesorMetodologico(request);
            return response;
        }

        [HttpPost("Eliminar")]
        public EliminarAsesorMetodologicoResponse EliminarAsesorMetodologico(EliminarAsesorMetodologicoRequest request)
        {
            var service = new EliminarAsesorMetodologicoService(_unitOfWork, _usuarioRepository, _mailServer);
            var response = service.EliminarAsesorMetodologico(request);
            return response;
        }

        [HttpPost("Consultar")]
        public ConsultarAsesorMetodologicoResponse ConsultarAsesorMetodologico(ConsultarAsesorMetodologicoRequest request)
        {
            var service = new ConsultarAsesorMetodologicoService(_unitOfWork, _usuarioRepository, _mailServer);
            var response = service.ConsultarAsesorMetodologico(request);
            return response;
        }

        [HttpGet("Listar")]
        public ListarAsesorMetodologicoResponse GetListarAsesoresMetodologicos()
        {
            var service = new ListarAsesoresMetodologicosService(_unitOfWork, _usuarioRepository, _mailServer);
            var response = service.ListarAsesoresMetodologicos();
            return response;
        }
    }
}
