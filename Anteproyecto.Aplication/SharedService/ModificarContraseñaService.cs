using Anteproyecto.Domain.Contracts;
using Anteproyecto.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anteproyecto.Aplication.SharedService
{
    public class ModificarContraseñaService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMailServer _mailServer;

        public ModificarContraseñaService(IUnitOfWork unitOfWork, IUsuarioRepository usuarioRepository, IMailServer mailServer)
        {
            _unitOfWork = unitOfWork;
            _usuarioRepository = usuarioRepository;
            _mailServer = mailServer;
        }

        public ModificarContraseñaResponse ModificarContraseña(ModificarContraseñaRequest request)
        {
            var user = _usuarioRepository.FindFirstOrDefault(t => t.Id == request.Id);
            if (user != null)
            {
                var res = user.ModificarContrasena(request.Contraseña);
                if (res.Equals("Su nueva contraseña es correcta"))
                {
                    _unitOfWork.Commit();
                    return new ModificarContraseñaResponse(res);
                }
                else
                {
                    return new ModificarContraseñaResponse(res);
                }
            }
            else
            {
                return new ModificarContraseñaResponse($"El Usuario no existe.");
            }
        }

        public record ModificarContraseñaRequest
        (
            int Id,
            string Contraseña
        );


        public record ModificarContraseñaResponse(string Mensaje);
    }
}