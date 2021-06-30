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

        public ConsultarAsesorTematicoResponse ConsultarAsesorTematico(ConsultarAsesorTematicoRequest request)
        {
            var user = (AsesorTematico)_usuarioRepository.FindFirstOrDefault(doc => doc.NumeroIdentificacion == request.NumeroIdentificacion);
            if (user != null)
            {
                return new ConsultarAsesorTematicoResponse(user, $"Operacion Exitosa. Se encontro al usuario {user.Nombres}");
            }
            else
            {
                return new ConsultarAsesorTematicoResponse(user, $"El Usuario {request.NumeroIdentificacion} no existe.");
            }
        }

        public record ConsultarAsesorTematicoRequest(string NumeroIdentificacion);

        public record ConsultarAsesorTematicoResponse(AsesorTematico Usuario, string Mensaje);
    }
}
