using Anteproyecto.Domain.Contracts;
using Anteproyecto.Domain.Entities;
using Anteproyecto.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anteproyecto.Aplication.AsesorMetodologicoService
{
    public class EliminarAsesorMetodologicoService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMailServer _mailServer;

        public EliminarAsesorMetodologicoService(IUnitOfWork unitOfWork, IUsuarioRepository usuarioRepository, IMailServer mailServer)
        {
            _unitOfWork = unitOfWork;
            _usuarioRepository = usuarioRepository;
            _mailServer = mailServer;
        }

        public EliminarAsesorMetodologicoResponse EliminarAsesorMetodologico(EliminarAsesorMetodologicoRequest request)
        {
            var user = (AsesorMetodologico)_usuarioRepository.FindFirstOrDefault(doc => doc.Id == request.Usuario.Id);
            if (user != null)
            {
                _usuarioRepository.Delete(user);
                _unitOfWork.Commit();

                return new EliminarAsesorMetodologicoResponse($"El Usuario {request.Usuario.Nombres} fue eliminado.");
            }
            else
            {
                return new EliminarAsesorMetodologicoResponse($"El Usuario {request.Usuario.Nombres} no existe.");
            }
        }

        public record EliminarAsesorMetodologicoRequest(AsesorMetodologico Usuario);

        public record EliminarAsesorMetodologicoResponse(string Mensaje);
    }
}
