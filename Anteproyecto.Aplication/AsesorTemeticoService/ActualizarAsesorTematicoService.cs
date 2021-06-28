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
    public class ActualizarAsesorTematicoService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMailServer _mailServer;

        public ActualizarAsesorTematicoService(IUnitOfWork unitOfWork, IUsuarioRepository usuarioRepository, IMailServer mailServer)
        {
            _unitOfWork = unitOfWork;
            _usuarioRepository = usuarioRepository;
            _mailServer = mailServer;
        }

        public ActualizarAsesorTematicoResponse ActualizarAsesorTematico(ActualizarAsesorTematicoRequest request)
        {
            var user = (AsesorTematico)_usuarioRepository.FindFirstOrDefault(doc => doc.NumeroIdentificacion == request.NumeroIdentificacion);
            if (user != null)
            {
                var res = user.Editar(request.Nombres, request.Apellidos, request.NumeroIdentificacion, request.Correo, request.Semestre, request.Edad, request.Estado);
                if (res.Equals($"El Usuario {user.Nombres} ha sido modificado correctamente"))
                {
                    _unitOfWork.Commit();
                    return new ActualizarAsesorTematicoResponse(res);
                }
                else
                {
                    return new ActualizarAsesorTematicoResponse(res);
                }
            }
            else
            {
                return new ActualizarAsesorTematicoResponse($"El Usuario {request.Nombres} no existe.");
            }
        }

        public record ActualizarAsesorTematicoRequest(string Nombres, string Apellidos, string NumeroIdentificacion, string Correo, int Semestre, int Edad, bool Estado);

        public record ActualizarAsesorTematicoResponse(string Mensaje);
    }
}
