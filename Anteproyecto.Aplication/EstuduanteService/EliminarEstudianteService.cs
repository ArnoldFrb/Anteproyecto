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
    public class EliminarEstudianteService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMailServer _mailServer;

        public EliminarEstudianteService(IUnitOfWork unitOfWork, IUsuarioRepository usuarioRepository, IMailServer mailServer)
        {
            _unitOfWork = unitOfWork;
            _usuarioRepository = usuarioRepository;
            _mailServer = mailServer;
        }

        public EliminarEstudianteResponse EliminarEstudiante(EliminarEstudianteRequest request)
        {
            var user = (Estudiante)_usuarioRepository.FindFirstOrDefault(doc => doc.NumeroIdentificacion == request.NumeroIdentificacion);
            if (user != null)
            {
                _usuarioRepository.Delete(user);
                _unitOfWork.Commit();

                return new EliminarEstudianteResponse($"El Usuario {request.NumeroIdentificacion} fue eliminado.");
            }
            else
            {
                return new EliminarEstudianteResponse($"El Usuario {request.NumeroIdentificacion} no existe.");
            }
        }

        public record EliminarEstudianteRequest(string NumeroIdentificacion);

        public record EliminarEstudianteResponse(string Mensaje);
    }
}
