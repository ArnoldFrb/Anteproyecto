using Anteproyecto.Domain.Contracts;
using Anteproyecto.Domain.Entities;
using Anteproyecto.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anteproyecto.Aplication.ProyectoService
{
    public class AgregarAsesorTematicoService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProyectoRepository _proyectoRepository;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMailServer _mailServer;

        public AgregarAsesorTematicoService(IUnitOfWork unitOfWork, IProyectoRepository proyectoRepository, IUsuarioRepository usuarioRepository, IMailServer mailServer)
        {
            _unitOfWork = unitOfWork;
            _proyectoRepository = proyectoRepository;
            _usuarioRepository = usuarioRepository;
            _mailServer = mailServer;
        }

        public AgregarAsesorTematicoResponse AgregarAsesor(AgregarAsesorTematicoReques request)
        {
            var proyecto = _proyectoRepository.FindFirstOrDefault(proyect => proyect.Id == request.Id);
            if (proyecto != null)
            {
                var user = _usuarioRepository.FindFirstOrDefault(doc => doc.Id == request.AsesorTematico.Id);
                if (user != null)
                {
                    var res = proyecto.AsignarAsesorTematico(request.AsesorTematico);
                    if (res.Equals($"Se ha asignado el Asesor Tematico {request.AsesorTematico.Nombres}"))
                    {
                        _unitOfWork.Commit();
                        return new AgregarAsesorTematicoResponse(res);
                    }
                    else
                    {
                        return new AgregarAsesorTematicoResponse(res);
                    }
                }
                else
                {
                    return new AgregarAsesorTematicoResponse($"No existe el Usuario: {proyecto.AsesorTematico.Nombres}");
                }
            }
            else
            {
                return new AgregarAsesorTematicoResponse($"No existe el Proyecto: {proyecto.Nombre}");
            }
        }

        public record AgregarAsesorTematicoReques
        (
            int Id,
            string Nombre,
            string Resumen,
            List<Observacion> Obsercion,
            Evaluacion Evaluacion,
            AsesorTematico AsesorTematico,
            AsesorMetodologico AsesorMetodologico
        );

        public record AgregarAsesorTematicoResponse(string Mensaje);
    }
}
