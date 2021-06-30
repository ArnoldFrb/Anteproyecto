using Anteproyecto.Domain.Contracts;
using Anteproyecto.Domain.Entities;
using Anteproyecto.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anteproyecto.Aplication
{
    public class ValidarNombreProyectoService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProyectoRepository _proyectoRepository;
        private readonly IMailServer _mailServer;

        public ValidarNombreProyectoService(IUnitOfWork unitOfWork, IProyectoRepository proyectoRepository, IMailServer mailServer)
        {
            _unitOfWork = unitOfWork;
            _proyectoRepository = proyectoRepository;
            _mailServer = mailServer;
        }

        public MensageProyectoResponse ValidarNombre(ProyectoRequest request)
        {
            var proyecto = _proyectoRepository.FindFirstOrDefault(proyect => proyect.Id == request.Id);

            if (proyecto != null)
            {
                proyecto.ValidarNombre(request.Nombre);
                _unitOfWork.Commit();
                return new MensageProyectoResponse() { Mensaje = "El nombre ingresado es correcto" };
            }
            else
            {
                return new MensageProyectoResponse() { Mensaje = "El nombre ingresado es incorrecta" };
            }
        }

        public MensageProyectoResponse ValidarResumen(ProyectoRequest request)
        {
            //validar duda
            //var proyecto = _proyectoRepository.FindFirstOrDefault(proyect => proyect.Id == request.Id);
            var proyecto = new Proyecto(request.Nombre, request.Resumen);

            if (proyecto != null)
            {
                if (proyecto.ValidarResumen(request.Resumen) == "Registro Exitozo, Se ha registrado el nuevo Resumen")
                {

                }
                _unitOfWork.Commit();
                return new MensageProyectoResponse() { Mensaje = "El resumen ingresado es correcto" };
            }
            else
            {
                return new MensageProyectoResponse() { Mensaje = "El resumen ingresado es incorrecta" };
            }

        }

        public class ProyectoRequest
        {
            public int Id { get; set; }
            public string Nombre { get; set; }
            public string Resumen { get; set; }
            public List<Observacion> Obsercion { get; set; }
            public Evaluacion Evaluacion { get; set; }
            public AsesorTematico AsesorTematico { get; set; }
            public AsesorMetodologico AsesorMetodologico { get; set; }
        }

        public class MensageProyectoResponse
        {
            public string Mensaje { get; set; }
        }
    }
}
