using Anteproyecto.Aplication.EstuduanteService;
using Anteproyecto.Domain.Contracts;
using Anteproyecto.Domain.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Anteproyecto.Aplication.EstuduanteService.ActualizarEstudianteService;
using static Anteproyecto.Aplication.EstuduanteService.ConsultarEstudianteService;
using static Anteproyecto.Aplication.EstuduanteService.EliminarEstudianteService;
using static Anteproyecto.Aplication.EstuduanteService.ListarEstudiantesService;
using static Anteproyecto.Aplication.EstuduanteService.RegistrarEstudianteService;

namespace Anteproyecto.Infrastructure.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstudianteController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMailServer _mailServer;
        public EstudianteController(IUnitOfWork unitOfWork, IUsuarioRepository usuarioRepository, IMailServer mailServer)
        {
            _unitOfWork = unitOfWork;
            _usuarioRepository = usuarioRepository;
            _mailServer = mailServer;
        }

        [HttpPost("Registrar")]
        public RegistrarEstudianteResponse PostRegistrarEstudiante(RegistrarEstudianteRequest request)
        {
            var service = new RegistrarEstudianteService(_unitOfWork, _usuarioRepository, _mailServer);
            var response = service.RegistrarEstudiante(request);
            return response;
        }

        [HttpPost("Actualizar")]
        public ActualizarEstudianteResponse PostActualizarEstudiante(ActualizarEstudianteRequest request)
        {
            var service = new ActualizarEstudianteService(_unitOfWork, _usuarioRepository, _mailServer);
            var response = service.ActualizarEstudiante(request);
            return response;
        }

        [HttpPost("Eliminar")]
        public EliminarEstudianteResponse PostEliminarEstudiante(EliminarEstudianteRequest request)
        {
            var service = new EliminarEstudianteService(_unitOfWork, _usuarioRepository, _mailServer);
            var response = service.EliminarEstudiante(request);
            return response;
        }

        [HttpPost("Consultar")]
        public ConsultarEstudianteResponse PostConsultarEstudiante(ConsultarEstudianteRequest request)
        {
            var service = new ConsultarEstudianteService(_unitOfWork, _usuarioRepository, _mailServer);
            var response = service.ConsultarEstudiante(request);
            return response;
        }

        [HttpGet("Listar")]
        public ListarEstudiantesResponse GetListarEstudiantes()
        {
            var service = new ListarEstudiantesService(_unitOfWork, _usuarioRepository, _mailServer);
            var response = service.ListarEstudiantes();
            return response;
        }


        [HttpGet("Listasinproyecto")]
        public ListarEstudiantesResponse GetListarSinProyecto()
        {
            var service = new ListarEstudiantesService(_unitOfWork, _usuarioRepository, _mailServer);
            var response = service.ListarEstudiantesSinProyecto();
            return response;
        }

    }
}
