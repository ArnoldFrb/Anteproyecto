using Anteproyecto.Aplication.MiembroComiteService;
using Anteproyecto.Domain.Contracts;
using Anteproyecto.Domain.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Anteproyecto.Aplication.MiembroComiteService.ActualizarMiembroComiteService;
using static Anteproyecto.Aplication.MiembroComiteService.ConsultarMiembroComiteService;
using static Anteproyecto.Aplication.MiembroComiteService.EliminarMiembroComiteService;
using static Anteproyecto.Aplication.MiembroComiteService.ListarMiembroComitesService;
using static Anteproyecto.Aplication.MiembroComiteService.RegistrarMiembroComiteService;

namespace Anteproyecto.Infrastructure.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MiembroComiteController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMailServer _mailServer;
        public MiembroComiteController(IUnitOfWork unitOfWork, IUsuarioRepository usuarioRepository, IMailServer mailServer)
        {
            _unitOfWork = unitOfWork;
            _usuarioRepository = usuarioRepository;
            _mailServer = mailServer;
        }

        [HttpPost("Registrar")]
        public RegistrarMiembroComiteResponse PostRegistrarMiembroComite(RegistrarMiembroComiteRequest request)
        {
            var service = new RegistrarMiembroComiteService(_unitOfWork, _usuarioRepository, _mailServer);
            var response = service.RegistrarMiembroComite(request);
            return response;
        }

        [HttpPost("Actualizar")]
        public ActualizarMiembroComiteResponse PostRegistrarMiembroComite(ActualizarMiembroComiteRequest request)
        {
            var service = new ActualizarMiembroComiteService(_unitOfWork, _usuarioRepository, _mailServer);
            var response = service.ActualizarMiembroComite(request);
            return response;
        }

        [HttpPost("Eliminar")]
        public EliminarMiembroComiteResponse PostEliminarMiembroComite(EliminarMiembroComiteRequest request)
        {
            var service = new EliminarMiembroComiteService(_unitOfWork, _usuarioRepository, _mailServer);
            var response = service.EliminarMiembroComite(request);
            return response;
        }

        [HttpPost("Consultar")]
        public ConsultarMiembroComiteResponse PostConsultarMiembroComite(ConsultarMiembroComiteRequest request)
        {
            var service = new ConsultarMiembroComiteService(_unitOfWork, _usuarioRepository, _mailServer);
            var response = service.ConsultarMiembroComite(request);
            return response;
        }

        [HttpGet("Listar")]
        public ListarMiembroComitesResponse GetListarMiembroComite()
        {
            var service = new ListarMiembroComitesService(_unitOfWork, _usuarioRepository, _mailServer);
            var response = service.ListarMiembroComite();
            return response;
        }
    }
}
