using Anteproyecto.Domain.Contracts;
using Anteproyecto.Domain.Entities;
using Anteproyecto.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anteproyecto.Aplication.EstuduanteService
{
    public class ConsultarEstudianteService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMailServer _mailServer;

        public ConsultarEstudianteService(IUnitOfWork unitOfWork, IUsuarioRepository usuarioRepository, IMailServer mailServer)
        {
            _unitOfWork = unitOfWork;
            _usuarioRepository = usuarioRepository;
            _mailServer = mailServer;
        }

        public ConsultarEstudianteResponse ConsultarEstudiante(ConsultarEstudianteRequest request)
        {
            var user = (Estudiante)_usuarioRepository.FindFirstOrDefault(doc => doc.NumeroIdentificacion == request.NumeroIdentificacion);
            if (user != null)
            {
                return new ConsultarEstudianteResponse(user, $"Operacion Exitosa. Se encontro al usuario {user.Nombres}");
            }
            else
            {
                return new ConsultarEstudianteResponse(user, $"El Usuario identificado con {request.NumeroIdentificacion} no existe.");
            }
        }

        public record ConsultarEstudianteRequest(string NumeroIdentificacion);

        public record ConsultarEstudianteResponse(Estudiante Estudiante, string Mensaje);
    }
}
