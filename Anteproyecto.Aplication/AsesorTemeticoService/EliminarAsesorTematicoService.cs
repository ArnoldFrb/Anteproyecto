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
    public class EliminarAsesorTematicoService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMailServer _mailServer;

        public EliminarAsesorTematicoService(IUnitOfWork unitOfWork, IUsuarioRepository usuarioRepository, IMailServer mailServer)
        {
            _unitOfWork = unitOfWork;
            _usuarioRepository = usuarioRepository;
            _mailServer = mailServer;
        }

        public EliminarAsesorTematicoResponse EliminarAsesorTematico(EliminarAsesorTematicoRequest request)
        {
            var user = (AsesorTematico)_usuarioRepository.FindFirstOrDefault(doc => doc.NumeroIdentificacion == request.NumeroIdentificacion);
            if (user != null)
            {
                _usuarioRepository.Delete(user);
                _unitOfWork.Commit();

                return new EliminarAsesorTematicoResponse($"El Usuario {request.NumeroIdentificacion} fue eliminado.");
            }
            else
            {
                return new EliminarAsesorTematicoResponse($"El Usuario {request.NumeroIdentificacion} no existe.");
            }
        }

        public record EliminarAsesorTematicoRequest(string NumeroIdentificacion);

        public record EliminarAsesorTematicoResponse(string Mensaje);
    }
}
