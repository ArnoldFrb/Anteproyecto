using Anteproyecto.Domain.Contracts;
using Anteproyecto.Domain.Entities;
using Anteproyecto.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anteproyecto.Aplication.AsesorMetodologicoService
{
    public class ActualizarAsesorMetodologicoService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMailServer _mailServer;

        public ActualizarAsesorMetodologicoService(IUnitOfWork unitOfWork, IUsuarioRepository usuarioRepository, IMailServer mailServer)
        {
            _unitOfWork = unitOfWork;
            _usuarioRepository = usuarioRepository;
            _mailServer = mailServer;
        }

        public ActualizarAsesorMetodologicoResponse ActualizarAsesorMetodologico(ActualizarAsesorMetodologicoRequest request)
        {
            var user = (AsesorMetodologico)_usuarioRepository.FindFirstOrDefault(doc => doc.NumeroIdentificacion == request.NumeroIdentificacion);
            if (user != null)
            {
                var res = user.Editar(request.Nombres, request.Apellidos, request.NumeroIdentificacion, request.Correo, request.Semestre, request.Edad, request.Estado);
                if (res.Equals($"El Usuario {user.Nombres} ha sido modificado correctamente"))
                {
                    _unitOfWork.Commit();
                    return new ActualizarAsesorMetodologicoResponse(res);
                }
                else
                {
                    return new ActualizarAsesorMetodologicoResponse(res);
                }
            }
            else
            {
                return new ActualizarAsesorMetodologicoResponse($"El Usuario {request.Nombres} no existe.");
            }
        }

        public record ActualizarAsesorMetodologicoRequest(string Nombres, string Apellidos, string NumeroIdentificacion, string Correo, int Semestre, int Edad, bool Estado);

        public record ActualizarAsesorMetodologicoResponse(string Mensaje);
    }
}
