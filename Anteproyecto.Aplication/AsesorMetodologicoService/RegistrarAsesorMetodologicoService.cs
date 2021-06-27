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
    public class RegistrarAsesorMetodologicoService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMailServer _mailServer;

        public RegistrarAsesorMetodologicoService(IUnitOfWork unitOfWork, IUsuarioRepository usuarioRepository, IMailServer mailServer)
        {
            _unitOfWork = unitOfWork;
            _usuarioRepository = usuarioRepository;
            _mailServer = mailServer;
        }

        public RegistrarAsesorMetodologicoResponse RegistrarEstudiante(RegistrarAsesorMetodologicoRequest request)
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
                    return new RegistrarAsesorMetodologicoResponse(res);
                }
                else
                {
                    return new RegistrarAsesorMetodologicoResponse(res);
                }
            }
            else
            {
                return new RegistrarAsesorMetodologicoResponse($"El Usuario {user.Nombres} ya ha sido registrado.");
            }
        }

        public record RegistrarAsesorMetodologicoRequest(AsesorMetodologico Usuario);

        public record RegistrarAsesorMetodologicoResponse(string Mensaje);
    }
}