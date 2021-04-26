using System;
using Anteproyecto.Domain.Contracts;
using Anteproyecto.Domain.Repositories;

namespace Anteproyecto.Aplication
{
    public class UsuarioService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMailServer _mailServer;

        public UsuarioService(IUnitOfWork unitOfWork, IUsuarioRepository usuarioRepository, IMailServer mailServer)
        {
            _unitOfWork = unitOfWork;
            _usuarioRepository = usuarioRepository;
            _mailServer = mailServer;
        }

        public ModificarContrasenaResponse ModificarContraseña(UsuarioRequest request)
        { 
            var usuario = _usuarioRepository.FindFirstOrDefault(user => user.NumeroIdentificacion == request.NumeroIdentificacion);

            if (usuario != null)
            {
                usuario.ModificarContraseña(request.Contraseña);
                _unitOfWork.Commit();
                return new ModificarContrasenaResponse() { Mensaje = "La contraseña a sido modificada satifctoriamente"};
            }
            else
            {
                return new ModificarContrasenaResponse() { Mensaje = "La identificacion del usuario es incorrecta" };
            }
        }

        public ModificarContrasenaResponse ModificarCorreo(UsuarioRequest request)
        {
            var usuario = _usuarioRepository.FindFirstOrDefault(user => user.NumeroIdentificacion == request.NumeroIdentificacion);

            if (usuario != null)
            {
                usuario.ModificarCorreo(request.Correo);
                _unitOfWork.Commit();
                return new ModificarContrasenaResponse() { Mensaje = "El correo a sido modificada satifctoriamente" };
            }
            else
            {
                return new ModificarContrasenaResponse() { Mensaje = "La identificacion del usuario es incorrecta" };

            }
        }

        public class UsuarioRequest
        {
           
            public string Nombres { get;   set; }
           
            public string Apellidos { get;   set; }
          
            public string NumeroIdentificacion { get;   set; }
            
            public string Correo { get;   set; }
           
            public string Contraseña { get;   set; }
        }

        public class ModificarContrasenaResponse
        {
            public string Mensaje { get; set; }
        }

    }
}
