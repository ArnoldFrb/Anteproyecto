using Anteproyecto.Domain.Contracts;
using Anteproyecto.Domain.Entities;
using Anteproyecto.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anteproyecto.Aplication.SharedService
{
    public class InicioDeSesionService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMailServer _mailServer;

        public InicioDeSesionService(IUnitOfWork unitOfWork, IUsuarioRepository usuarioRepository, IMailServer mailServer)
        {
            _unitOfWork = unitOfWork;
            _usuarioRepository = usuarioRepository;
            _mailServer = mailServer;
        }

        public InicioDeSesionResponse IniciosDeSesion(InicioDeSesionRequest request)
        {
            var user = _usuarioRepository.FindFirstOrDefault(t => t.Correo == request.Correo.ToString());
            if (user != null)
            {
                if (user.Contraseña == request.Contraseña.ToString())
                {
                    return new InicioDeSesionResponse(user, "Inicio de Seción existoso.");
                }
                else
                {
                    return new InicioDeSesionResponse(user, "Contrasena Incorrecta.");
                }
            }
            else
            {
                return new InicioDeSesionResponse(user, $"El correo {request.Correo} no fue encontrado");
            }
        }

        public record InicioDeSesionRequest
        (
            string Correo,
            string Contraseña
        );

        public record InicioDeSesionResponse(Usuario Usuario, string Mensaje);

    }
}
