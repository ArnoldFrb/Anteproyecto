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
    public class AgregarAsesorMetodoloficoService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProyectoRepository _proyectoRepository;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMailServer _mailServer;

        public AgregarAsesorMetodoloficoService(IUnitOfWork unitOfWork, IProyectoRepository proyectoRepository, IUsuarioRepository usuarioRepository, IMailServer mailServer)
        {
            _unitOfWork = unitOfWork;
            _proyectoRepository = proyectoRepository;
            _usuarioRepository = usuarioRepository;
            _mailServer = mailServer;
        }

        public AgregarAsesorMetodoloficoResponse AgregarAsesor(AgregarAsesorMetodoloficoRequest request)
        {
            var proyecto = _proyectoRepository.FindFirstOrDefault(proyect => proyect.Id == request.Id);
            if (proyecto != null)
            {
                var user = _usuarioRepository.FindFirstOrDefault(doc => doc.Id == request.AsesorMetodologico.Id);
                if (user != null)
                {
                    var res = proyecto.AsignarAsesorMetodologico(request.AsesorMetodologico);
                    if (res.Equals($"Se ha asignado el Asesor Metodologico {request.AsesorMetodologico.Nombres}"))
                    {
                        _unitOfWork.Commit();
                        return new AgregarAsesorMetodoloficoResponse(res);
                    }
                    else
                    {
                        return new AgregarAsesorMetodoloficoResponse(res);
                    }
                }
                else
                {
                    return new AgregarAsesorMetodoloficoResponse($"No existe el Usuario: {proyecto.AsesorMetodologico.Nombres}");
                }
            }
            else
            {
                return new AgregarAsesorMetodoloficoResponse($"No existe el Proyecto: {proyecto.Nombre}");
            }
        }

        public record AgregarAsesorMetodoloficoRequest
        (
            int Id,
            string Nombre,
            string Resumen,
            List<Observacion> Obsercion,
            Evaluacion Evaluacion,
            AsesorTematico AsesorTematico,
            AsesorMetodologico AsesorMetodologico
        );

        public record AgregarAsesorMetodoloficoResponse(string Mensaje);
    }
}
