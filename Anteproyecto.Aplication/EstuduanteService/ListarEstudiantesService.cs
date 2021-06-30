using Anteproyecto.Domain.Contracts;
using Anteproyecto.Domain.Entities;
using Anteproyecto.Domain.Repositories;
using System;
using System.Collections.Generic;

namespace Anteproyecto.Aplication.EstuduanteService
{
    public class ListarEstudiantesService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMailServer _mailServer;

        public ListarEstudiantesService(IUnitOfWork unitOfWork, IUsuarioRepository usuarioRepository, IMailServer mailServer)
        {
            _unitOfWork = unitOfWork;
            _usuarioRepository = usuarioRepository;
            _mailServer = mailServer;
        }

        public ListarEstudiantesResponse ListarEstudiantes()
        {
            var user = _usuarioRepository.GetAll();
            if (user != null)
            {
                var res = new List<Estudiante>();
                foreach (var doc in user) 
                {
                    if (doc.ToString().Equals("Anteproyecto.Domain.Entities.Estudiante"))
                    {
                        res.Add((Estudiante)doc);
                    }
                    
                }
                if (res.Count != 0)
                {
                    return new ListarEstudiantesResponse(res, "Lista de Usuarios");
                }
                else
                {
                    return new ListarEstudiantesResponse(null, "No se ncontraron Estudiantes registrados");
                }
                
            }
            else
            {
                return new ListarEstudiantesResponse(null, "No existen usuarios en el sistema");
            }
        }

        public record ListarEstudiantesResponse(List<Estudiante> Estudiantes, string Mensaje);
    }
}
