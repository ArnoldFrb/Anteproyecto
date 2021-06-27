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
            var user = (AsesorTematico)_usuarioRepository.FindFirstOrDefault(doc => doc.Id == request.Usuario.Id);
            if (user != null)
            {
                var res = user.Editar(request.Usuario);
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
                return new ActualizarAsesorTematicoResponse($"El Usuario {request.Usuario.Nombres} no existe.");
            }
        }

        public record ActualizarAsesorTematicoRequest(AsesorTematico Usuario);

        public record ActualizarAsesorTematicoResponse(string Mensaje);
    }
}
