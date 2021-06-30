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
    public class ConsultarAsesorMetodologicoService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMailServer _mailServer;

        public ConsultarAsesorMetodologicoService(IUnitOfWork unitOfWork, IUsuarioRepository usuarioRepository, IMailServer mailServer)
        {
            _unitOfWork = unitOfWork;
            _usuarioRepository = usuarioRepository;
            _mailServer = mailServer;
        }

        public ConsultarAsesorMetodologicoResponse ConsultarAsesorMetodologico(ConsultarAsesorMetodologicoRequest request)
        {
            var user = (AsesorMetodologico)_usuarioRepository.FindFirstOrDefault(doc => doc.NumeroIdentificacion == request.NumeroIdentificacion);
            if (user != null)
            {
                return new ConsultarAsesorMetodologicoResponse(user, $"Operacion Exitosa. Se encontro al usuario {user.Nombres}");
            }
            else
            {
                return new ConsultarAsesorMetodologicoResponse(user, $"El Usuario {request.NumeroIdentificacion} no existe.");
            }
        }

        public record ConsultarAsesorMetodologicoRequest(string NumeroIdentificacion);

        public record ConsultarAsesorMetodologicoResponse(AsesorMetodologico Usuario, string Mensaje);
    }
}
