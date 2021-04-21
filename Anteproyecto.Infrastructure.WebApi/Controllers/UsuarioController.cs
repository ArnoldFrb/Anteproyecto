using Anteproyecto.Aplication;
using Anteproyecto.Domain;
using Anteproyecto.Domain.Contracts;
using Anteproyecto.Domain.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Anteproyecto.Aplication.UsuarioService;

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
                var cuenta = new Estudiante("Jose Carlos", "Oñate Oñate", "123456789", "cliente@bancoacme.com", "1234567");
                usuarioRepository.Add(cuenta);
                unitOfWork.Commit();
            }
        }

        [HttpPost]
        public ModificarContrasenaResponse PostModificarContraseña(UsuarioRequest usuarioRequest)
        {
            var service = new UsuarioService(_unitOfWork, _usuarioRepository, _mailServer);
            var response = service.ModificarContraseña(usuarioRequest);
            return response;
        }
    }
}
