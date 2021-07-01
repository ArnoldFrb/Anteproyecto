using Anteproyecto.Domain.Contracts;
using Anteproyecto.Domain.Entities;
using Anteproyecto.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anteproyecto.Aplication.UsuarioService
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
            string tipo = "";
            if (user != null)
            {
                 tipo = user.GetType().Name;
                if (user.Contraseña == request.Contrasena.ToString())
                {
                    
                    return new InicioDeSesionResponse(user.Id.ToString(),tipo,user.Nombres,user.Correo.ToString(), user.NumeroIdentificacion.ToString(), "2212222", "Inicio de Seción existoso.");
                }
                else
                {
                    return new InicioDeSesionResponse(user.Id.ToString(), tipo, user.Nombres, user.Correo.ToString(), user.NumeroIdentificacion.ToString(), "2212222", "Contrasena Incorrecta.");
                }
            }
            else
            {
                user = null;
                return new InicioDeSesionResponse(user.Id.ToString(), tipo, user.Nombres, user.Correo.ToString(), user.NumeroIdentificacion.ToString(), "2212222", $"El correo {request.Correo} no fue encontrado");
            }
        }

        public record InicioDeSesionRequest
        (
            string Correo,
            string Contrasena
        );

        public record InicioDeSesionResponse(
            string Id,
            string Type,
            string Name,
            string Email,
            string Idetification,
            string Telephone,
            string Message
        );

    }
}
