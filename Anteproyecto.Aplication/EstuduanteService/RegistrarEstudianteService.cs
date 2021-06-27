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
            var user = _usuarioRepository.FindFirstOrDefault(doc => doc.NumeroIdentificacion == request.Estudiante.NumeroIdentificacion);
            if (user == null)
            {
                user = request.Estudiante;
                var res = user.ValidarUsuario(request.Estudiante);
                if (res.Equals($"El Usuario {user.Nombres} ha sido registrado correctamente"))
                {
                    var ID = _usuarioRepository.GetAll();
                    user.Id = ID.Last().Id + 1;

                    _usuarioRepository.Add(user);
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
                return new RegistrarEstudianteResponse($"El Usuario {user.Nombres} ya ha sido registrado.");
            }
        }

        public record RegistrarEstudianteRequest(Estudiante Estudiante);

        public record RegistrarEstudianteResponse(string Mensaje);
    }
}