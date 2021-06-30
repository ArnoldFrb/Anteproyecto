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
    public class RegistrarMiembroComiteService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMailServer _mailServer;

        public RegistrarMiembroComiteService(IUnitOfWork unitOfWork, IUsuarioRepository usuarioRepository, IMailServer mailServer)
        {
            _unitOfWork = unitOfWork;
            _usuarioRepository = usuarioRepository;
            _mailServer = mailServer;
        }

        public RegistrarMiembroComiteResponse RegistrarMiembroComite(RegistrarMiembroComiteRequest request)
        {
            var user = _usuarioRepository.FindFirstOrDefault(doc => doc.NumeroIdentificacion == request.NumeroIdentificacion);
            if (user == null)
            {
                user = new MiembroComite(request.Nombres, request.Apellidos, request.NumeroIdentificacion, request.Correo, request.Contraseña, request.Semestre, request.Edad, request.Estado);
                var res = user.ValidarUsuario(user);
                if (res.Equals($"El Usuario {user.Nombres} ha sido registrado correctamente"))
                {
                    _usuarioRepository.Add(user);
                    _mailServer.Send(user.Correo, "Se realizo el registro ecorrectamente", user.enviarPlantillaCorreo());
                    _unitOfWork.Commit();

                    return new RegistrarMiembroComiteResponse(res);
                }
                else
                {
                    return new RegistrarMiembroComiteResponse(res);
                }
            }
            else
            {
                return new RegistrarMiembroComiteResponse($"El Usuario {user.Nombres} ya ha sido registrado.");
            }
        }

        public record RegistrarMiembroComiteRequest(string Nombres, string Apellidos, string NumeroIdentificacion, string Correo, string Contraseña, int Semestre, int Edad, bool Estado);

        public record RegistrarMiembroComiteResponse(string Mensaje);
    }
}