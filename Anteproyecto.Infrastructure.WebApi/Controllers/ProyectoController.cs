using Anteproyecto.Aplication;
using Anteproyecto.Domain.Contracts;
using Anteproyecto.Domain.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Anteproyecto.Aplication.ProyectoService;

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
            var service = new ProyectoService(_unitOfWork, _proyectoRepository, _mailServer);
            var response = service.ValidarNombre(proyectoRequest);
            return response;
        }
    }
}
