using Anteproyecto.Domain.Contracts;
using Anteproyecto.Domain.Entities;
using Anteproyecto.Domain.Repositories;
using System;
using System.Collections.Generic;

namespace Anteproyecto.Aplication.AsesorTemeticoService
{
    public class ListarAsesorTematicoService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMailServer _mailServer;

        public ListarAsesorTematicoService(IUnitOfWork unitOfWork, IUsuarioRepository usuarioRepository, IMailServer mailServer)
        {
            _unitOfWork = unitOfWork;
            _usuarioRepository = usuarioRepository;
            _mailServer = mailServer;
        }

        public ListarAsesorTematicoResponse ListarAsesorTematico()
        {
            var user = _usuarioRepository.GetAll();
            if (user != null)
            {
                var res = new List<AsesorTematico>();
                foreach (var doc in user) 
                {
                    if (doc.ToString().Equals("Anteproyecto.Domain.Entities.AsesorTematico"))
                    {
                        res.Add((AsesorTematico)doc);
                    }
                }
                if (res.Count != 0)
                {
                    return new ListarAsesorTematicoResponse(res, "Lista de Usuarios");
                }
                else
                {
                    return new ListarAsesorTematicoResponse(null, "No se ncontraron Asesor Tematico registrados");
                }
            }
            else
            {
                return new ListarAsesorTematicoResponse(null, "No existen usuarios en el sistema");
            }
        }

        public record ListarAsesorTematicoResponse(IEnumerable<Usuario> Usuarios, string Mensaje);
    }
}
