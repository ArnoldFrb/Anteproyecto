using Anteproyecto.Domain.Contracts;
using Anteproyecto.Domain.Entities;
using Anteproyecto.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anteproyecto.Aplication.AsesorTemeticoService
{
    public class ConsultarAsesorTematicoService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMailServer _mailServer;

        public ConsultarAsesorTematicoService(IUnitOfWork unitOfWork, IUsuarioRepository usuarioRepository, IMailServer mailServer)
        {
            _unitOfWork = unitOfWork;
            _usuarioRepository = usuarioRepository;
            _mailServer = mailServer;
        }

        public ConsultarEstudianteResponse ConsultarAsesorTematico(ConsultarEstudianteRequest request)
        {
            var user = (AsesorTematico)_usuarioRepository.FindFirstOrDefault(doc => doc.Id == request.Usuario.Id);
            if (user != null)
            {
                return new ConsultarEstudianteResponse(user, $"Operacion Exitosa. Se encontro al usuario {user.Nombres}");
            }
            else
            {
                return new ConsultarEstudianteResponse(user, $"El Usuario {request.Usuario.Nombres} no existe.");
            }
        }

        public record ConsultarEstudianteRequest(AsesorTematico Usuario);

        public record ConsultarEstudianteResponse(AsesorTematico Usuario, string Mensaje);
    }
}
