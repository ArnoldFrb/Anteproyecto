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
    public class RegistrarEstudianteService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMailServer _mailServer;

        public RegistrarEstudianteService(IUnitOfWork unitOfWork, IUsuarioRepository usuarioRepository, IMailServer mailServer)
        {
            _unitOfWork = unitOfWork;
            _usuarioRepository = usuarioRepository;
            _mailServer = mailServer;
        }

        public RegistrarEstudianteResponse RegistrarEstudiante(RegistrarEstudianteRequest request)
        {
            var user = _usuarioRepository.FindFirstOrDefault(doc => doc.NumeroIdentificacion == request.NumeroIdentificacion);
            if (user == null)
            {
                user = new Estudiante(request.Nombres, request.Apellidos, request.NumeroIdentificacion, request.Correo, request.Contraseña, request.Semestre, request.Edad, request.Estado);
                var res = user.ValidarUsuario(user);
                if (res.Equals($"El Usuario {user.Nombres} ha sido registrado correctamente"))
                {
                    _usuarioRepository.Add(user);
                    _mailServer.Send(user.Correo, "Se realizo el registro ecorrectamente", user.enviarPlantillaCorreo());
                    _unitOfWork.Commit();
                    return new RegistrarEstudianteResponse(res);
                }
                else
                {
                    return new RegistrarEstudianteResponse(res);
                }
            }
            else
            {
                return new RegistrarEstudianteResponse($"El Usuario {user.Nombres} ya existe.");
            }
        }

        public record RegistrarEstudianteRequest(string Nombres, string Apellidos, string NumeroIdentificacion, string Correo, string Contraseña, int Semestre, int Edad, bool Estado);

        public record RegistrarEstudianteResponse(string Mensaje);
    }
}