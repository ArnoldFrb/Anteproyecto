using Anteproyecto.Domain.Contracts;
using Anteproyecto.Domain.Entities;
using Anteproyecto.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anteproyecto.Aplication.MiembroComiteService
{
    public class ConsultarMiembroComiteService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMailServer _mailServer;

        public ConsultarMiembroComiteService(IUnitOfWork unitOfWork, IUsuarioRepository usuarioRepository, IMailServer mailServer)
        {
            _unitOfWork = unitOfWork;
            _usuarioRepository = usuarioRepository;
            _mailServer = mailServer;
        }

        public ConsultarMiembroComiteResponse ConsultarMiembroComite(ConsultarMiembroComiteRequest request)
        {
            var user = (MiembroComite)_usuarioRepository.FindFirstOrDefault(doc => doc.Id == request.Usuario.Id);
            if (user != null)
            {
                return new ConsultarMiembroComiteResponse(user, $"Operacion Exitosa. Se encontro al usuario {user.Nombres}");
            }
            else
            {
                return new ConsultarMiembroComiteResponse(user, $"El Usuario {request.Usuario.Nombres} no existe.");
            }
        }

        public record ConsultarMiembroComiteRequest(MiembroComite Usuario);

        public record ConsultarMiembroComiteResponse(MiembroComite Usuario, string Mensaje);
    }
}
