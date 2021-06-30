using Anteproyecto.Domain.Entities;
using Anteproyecto.Domain.Contracts;
using Anteproyecto.Domain.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Anteproyecto.Aplication.UsuarioService;
using static Anteproyecto.Aplication.UsuarioService.ModificarContraseñaService;
using static Anteproyecto.Aplication.UsuarioService.InicioDeSesionService;

namespace Anteproyecto.Infrastructure.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMailServer _mailServer;
        public UsuarioController(IUnitOfWork unitOfWork, IUsuarioRepository usuarioRepository, IMailServer mailServer)
        {
            _unitOfWork = unitOfWork;
            _usuarioRepository = usuarioRepository;
            _mailServer = mailServer;

            if (!usuarioRepository.GetAll().Any())
            {
                var cuenta = new Estudiante("Jose Carlos", "Oñate Oñate", "123456789", "usuario@user.com", "1234567",9,24,true);
                usuarioRepository.Add(cuenta);
                unitOfWork.Commit();
            }
        }

        [HttpPost("ModificarContraseña")]
        public ModificarContraseñaResponse PostModificarContraseña(ModificarContraseñaRequest request)
        {
            var service = new ModificarContraseñaService(_unitOfWork, _usuarioRepository, _mailServer);
            var response = service.ModificarContraseña(request);
            return response;
        }

        [HttpPost("IniciosDeSesion")]
        public InicioDeSesionResponse PostIniciosDeSesion(InicioDeSesionRequest request)
        {
            var service = new InicioDeSesionService(_unitOfWork, _usuarioRepository, _mailServer);
            var response = service.IniciosDeSesion(request);
            return response;
        }
    }
}
