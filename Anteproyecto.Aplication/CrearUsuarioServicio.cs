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
    public class CrearUsuarioServicio
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

        public CrearUsuarioResponse CrearCuentaBancaria(crearUsuarioRequest request)
        {
            Usuario user = _usuarioRepository.FindFirstOrDefault(t => t.NumeroIdentificacion == request.NumeroIdentificacion.ToString());
            if (user == null)
            {
                Estudiante us = new Estudiante(request.Nombres, request.Apellidos, request.NumeroIdentificacion, request.Correo, request.Contraseña);
                
                if (us.ValidarUsuario(us) == "Usuario registrado correctamente")
                {
                    _usuarioRepository.Add(us);
                    _unitOfWork.Commit();

                    return new CrearUsuarioResponse() { Mensaje = $"Se ha creado un nuevo usuario con la identificacion: {us.NumeroIdentificacion}" };
                }
                else
                {
                    return new CrearUsuarioResponse() { Mensaje = "Digite los campos primordiales para su registro" };
                }
               
            }
            else
             {
                return new CrearUsuarioResponse() { Mensaje = $"El estudiante con ese numero de cedula ya esta registrado"};
               
            }
        }

        public class crearUsuarioRequest
        { 
            public string Nombres { get; set; }
            public string Apellidos { get; set; }
            public string NumeroIdentificacion { get; set; }
            public string Correo { get; set; }
            public string Contraseña { get; set; }
        }


        public class CrearUsuarioResponse
        {
            public string Mensaje { get; set; }
        }
    }
}
