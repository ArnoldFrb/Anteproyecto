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

        public RegistrarMiembroComiteResponse RegistrarEstudiante(RegistrarEstudianteRequest request)
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

        public record RegistrarEstudianteRequest(MiembroComite Usuario);

        public record RegistrarMiembroComiteResponse(string Mensaje);
    }
}