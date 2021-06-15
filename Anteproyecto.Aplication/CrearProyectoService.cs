using Anteproyecto.Domain.Contracts;
using Anteproyecto.Domain.Entities;
using Anteproyecto.Domain.Repositories;
using System;
using System.Collections.Generic;

namespace Anteproyecto.Aplication
{
    public class CrearProyectoService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProyectoRepository _proyectoRepository;
        private readonly IMailServer _mailServer;

        public CrearProyectoService(IUnitOfWork unitOfWork, IProyectoRepository proyectoRepository, IMailServer mailServer)
        {
            _unitOfWork = unitOfWork;
            _proyectoRepository = proyectoRepository;
            _mailServer = mailServer;
        }

        public string CrearProyecto(ProyectoRequest request)
        {
            Proyecto proyecto = _proyectoRepository.FindFirstOrDefault(t => t.Nombre == request.Nombre);
            if (proyecto == null)
            {
                Proyecto proyectoNueva = ProyectoNuevo.CrearProyecto(request.Nombre, request.Resumen);
                _proyectoRepository.Add(proyectoNueva);
                _unitOfWork.Commit();
                return $"Se agrego con exito el proyecto: {proyectoNueva.Nombre}.";
            }
            else
            {
                return $"El Nombre del proyecto ya ha sido registrado";
            }
        }

        public class ProyectoRequest
        {
            public string Nombre { get; set; }
            public string Resumen { get; set; }
            public List<Obsercion> Obsercion { get; private set; }
            public Evaluacion Evaluacion { get; private set; }
            public AsesorTematico AsesorTematico { get; private set; }
            public AsesorMetodologico AsesorMetodologico { get; private set; }
        }

        public static class ProyectoNuevo
        {
            public static Proyecto CrearProyecto(string nombre, string resumen)
            {
                return new Proyecto(nombre, resumen);
            }
        }
    }
}
