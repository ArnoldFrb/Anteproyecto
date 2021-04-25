using Anteproyecto.Domain.Contracts;
using Anteproyecto.Domain.Entities;
using Anteproyecto.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anteproyecto.Aplication
{
    class CrearUsuarioServicio
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMailServer _mailServer;

        public CrearUsuarioServicio(IUnitOfWork unitOfWork, IUsuarioRepository usuarioRepository, IMailServer mailServer)
        {
            _unitOfWork = unitOfWork;
            _usuarioRepository = usuarioRepository;
            _mailServer = mailServer;
        }

        public string CrearCuentaBancaria(ProyectoRequest request)
        {
            Usuario user = _usuarioRepository.FindFirstOrDefault(t => t.NumeroIdentificacion == request.NumeroIdentificacion);
            if (user != null)
            {
                _usuarioRepository.Add(user);
                _unitOfWork.Commit();
                return $"Se ha creado un nuevo usuario con la identificacion: {user.NumeroIdentificacion}";
            }
            else
            {
                return $"El usuario ya existe";
            }
        }

        public class ProyectoRequest
        {
            public string Nombres { get; set; }
            public string Apellidos { get; set; }
            public string NumeroIdentificacion { get; set; }
            public string Correo { get; set; }
            public string Contraseña { get; set; }
        }
    }
}
