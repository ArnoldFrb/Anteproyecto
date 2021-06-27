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
    public class EliminarMiembroComiteService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMailServer _mailServer;

        public EliminarMiembroComiteService(IUnitOfWork unitOfWork, IUsuarioRepository usuarioRepository, IMailServer mailServer)
        {
            _unitOfWork = unitOfWork;
            _usuarioRepository = usuarioRepository;
            _mailServer = mailServer;
        }

        public EliminarMiembroComiteResponse EliminarMiembroComite(EliminarMiembroComiteRequest request)
        {
            var user = (MiembroComite)_usuarioRepository.FindFirstOrDefault(doc => doc.Id == request.Usuario.Id);
            if (user != null)
            {
                _usuarioRepository.Delete(user);
                _unitOfWork.Commit();

                return new EliminarMiembroComiteResponse($"El Usuario {request.Usuario.Nombres} fue eliminado.");
            }
            else
            {
                return new EliminarMiembroComiteResponse($"El Usuario {request.Usuario.Nombres} no existe.");
            }
        }

        public record EliminarMiembroComiteRequest(MiembroComite Usuario);

        public record EliminarMiembroComiteResponse(string Mensaje);
    }
}
