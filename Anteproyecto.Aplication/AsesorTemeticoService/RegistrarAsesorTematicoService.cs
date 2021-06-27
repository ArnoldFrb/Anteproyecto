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

        public RegistrarAsesorTematicoResponse RegistrarEstudiante(RegistrarAsesorTematicoRequest request)
        {
            var user = _usuarioRepository.FindFirstOrDefault(doc => doc.NumeroIdentificacion == request.Usuario.NumeroIdentificacion);
            if (user == null)
            {
                user = request.Usuario;
                var res = user.ValidarUsuario(request.Usuario);
                if (res.Equals($"El Usuario {user.Nombres} ha sido registrado correctamente"))
                {
                    var ID = _usuarioRepository.GetAll();
                    user.Id = ID.Last().Id + 1;

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

        public record RegistrarAsesorTematicoRequest(AsesorTematico Usuario);

        public record RegistrarAsesorTematicoResponse(string Mensaje);
    }
}