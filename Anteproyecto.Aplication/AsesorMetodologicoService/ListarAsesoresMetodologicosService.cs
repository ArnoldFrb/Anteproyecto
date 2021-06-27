using Anteproyecto.Domain.Contracts;
using Anteproyecto.Domain.Entities;
using Anteproyecto.Domain.Repositories;
using System;
using System.Collections.Generic;

namespace Anteproyecto.Aplication.AsesorMetodologicoService
{
    public class ListarAsesoresMetodologicosService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMailServer _mailServer;

        public ListarAsesoresMetodologicosService(IUnitOfWork unitOfWork, IUsuarioRepository usuarioRepository, IMailServer mailServer)
        {
            _unitOfWork = unitOfWork;
            _usuarioRepository = usuarioRepository;
            _mailServer = mailServer;
        }

        public ListarAsesorMetodologicoResponse ListarAsesoresMetodologicos()
        {
            var user = _usuarioRepository.GetAll();
            if (user != null)
            {
                var res = new List<AsesorMetodologico>();
                foreach (var doc in user) 
                {
                    if (doc.ToString().Equals("Anteproyecto.Domain.Entities.AsesorMetodologico"))
                    {
                        res.Add((AsesorMetodologico)doc);
                    }
                }
                if (res.Count != 0)
                {
                    return new ListarAsesorMetodologicoResponse(res, "Lista de Usuarios");
                }
                else
                {
                    return new ListarAsesorMetodologicoResponse(null, "No se ncontraron Estudiantes registrados");
                }
            }
            else
            {
                return new ListarAsesorMetodologicoResponse(null, "No existen usuarios en el sistema");
            }
        }

        public record ListarAsesorMetodologicoResponse(IEnumerable<Usuario> Usuarios, string Mensaje);
    }
}
