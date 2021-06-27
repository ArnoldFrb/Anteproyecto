using Anteproyecto.Domain.Contracts;
using Anteproyecto.Domain.Entities;
using Anteproyecto.Domain.Repositories;
using System;
using System.Collections.Generic;

namespace Anteproyecto.Aplication.MiembroComiteService
{
    public class ListarMiembroComitesService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMailServer _mailServer;

        public ListarMiembroComitesService(IUnitOfWork unitOfWork, IUsuarioRepository usuarioRepository, IMailServer mailServer)
        {
            _unitOfWork = unitOfWork;
            _usuarioRepository = usuarioRepository;
            _mailServer = mailServer;
        }

        public ListarEstudiantesResponse ListarMiembroComite()
        {
            var user = _usuarioRepository.GetAll();
            if (user != null)
            {
                var res = new List<MiembroComite>();
                foreach (var doc in user) 
                {
                    if (doc.ToString().Equals("Anteproyecto.Domain.Entities.MiembroComite"))
                    {
                        res.Add((MiembroComite)doc);
                    }
                }
                if (res.Count != 0)
                {
                    return new ListarEstudiantesResponse(res, "Lista de Usuarios");
                }
                else
                {
                    return new ListarEstudiantesResponse(null, "No se ncontraron Miembros Comite registrados");
                }
            }
            else
            {
                return new ListarEstudiantesResponse(null, "No existen usuarios en el sistema");
            }
        }
        public record ListarEstudiantesResponse(IEnumerable<MiembroComite> Usuario, string Mensaje);
    }
}
