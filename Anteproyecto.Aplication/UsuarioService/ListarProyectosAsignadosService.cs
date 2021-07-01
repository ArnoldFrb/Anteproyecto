using Anteproyecto.Domain.Contracts;
using Anteproyecto.Domain.Entities;
using Anteproyecto.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anteproyecto.Aplication.UsuarioService
{
    public class ListarProyectosAsignadosService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProyectoRepository _proyectoRepository;

        public ListarProyectosAsignadosService(IUnitOfWork unitOfWork, IProyectoRepository proyectoRepository)
        {
            _unitOfWork = unitOfWork;
            _proyectoRepository = proyectoRepository;
        }

        public ListarProyectosAsignadosResponse List(ListarProyectosAsignadosRequest request, string Host)
        {
            var proyecto = _proyectoRepository.FindBy(doc => doc.AsesorMetodologico.Id == request.Id);
            if (proyecto.Count() != 0)
            {
                proyecto.ToList().ForEach(x =>
                {
                    x.asignarArchivo(request + "/" + x.Url_Archive);
                });

                return new ListarProyectosAsignadosResponse(proyecto, "Proyecto asignados");
            }
            else
            {
                return new ListarProyectosAsignadosResponse(null, "No tiene proyectos asignados.");
            }
        }

        public record ListarProyectosAsignadosRequest(int Id);

        public record ListarProyectosAsignadosResponse(IEnumerable<Proyecto> Proyectos, string Mensaje);
    }
}
