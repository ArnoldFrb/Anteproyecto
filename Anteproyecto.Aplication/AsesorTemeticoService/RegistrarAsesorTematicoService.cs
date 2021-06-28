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
    public class RegistrarAsesorTematicoService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMailServer _mailServer;

        public RegistrarAsesorTematicoService(IUnitOfWork unitOfWork, IUsuarioRepository usuarioRepository, IMailServer mailServer)
        {
            _unitOfWork = unitOfWork;
            _usuarioRepository = usuarioRepository;
            _mailServer = mailServer;
        }

        public RegistrarAsesorTematicoResponse RegistrarAsesorTematico(RegistrarAsesorTematicoRequest request)
        {
            var user = _usuarioRepository.FindFirstOrDefault(doc => doc.NumeroIdentificacion == request.NumeroIdentificacion);
            if (user == null)
            {
                user = new AsesorTematico(request.Nombres, request.Apellidos, request.NumeroIdentificacion, request.Correo, request.Contraseña, request.Semestre, request.Edad, request.Estado);
                var res = user.ValidarUsuario(user);
                if (res.Equals($"El Usuario {user.Nombres} ha sido registrado correctamente"))
                {
                    _usuarioRepository.Add(user);
                    _unitOfWork.Commit();

                    return new RegistrarAsesorTematicoResponse(res);
                }
                else
                {
                    return new RegistrarAsesorTematicoResponse(res);
                }
            }
            else
            {
                return new RegistrarAsesorTematicoResponse($"El Usuario {user.Nombres} ya ha sido registrado.");
            }
        }

        public record RegistrarAsesorTematicoRequest(string Nombres, string Apellidos, string NumeroIdentificacion, string Correo, string Contraseña, int Semestre, int Edad, bool Estado);

        public record RegistrarAsesorTematicoResponse(string Mensaje);
    }
}