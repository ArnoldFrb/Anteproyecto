using Anteproyecto.Domain.Contracts;
using Anteproyecto.Domain.Entities;
using Anteproyecto.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anteproyecto.Aplication.EstuduanteService
{
    public class CargarProyectoService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IProyectoRepository _proyectoRepository;
        private readonly IMailServer _mailServer;

        public CargarProyectoService(IUnitOfWork unitOfWork, IUsuarioRepository usuarioRepository, IProyectoRepository proyectoRepository, IMailServer mailServer)
        {
            _unitOfWork = unitOfWork;
            _usuarioRepository = usuarioRepository;
            _proyectoRepository = proyectoRepository;
            _mailServer = mailServer;
        }

        public CargarProyectoResponse CargarProyecto(CargarProyectoRequest request)
        {
            var user = (Estudiante)_usuarioRepository.FindFirstOrDefault(t => t.NumeroIdentificacion == request.NumeroIdentificacion.ToString());
            if (user != null)
            {
                var res = user.CargarProyecto(request.Proyecto);
                if (res.Equals($"Operacion exitoza: Se ha cargado el proyecto {request.Proyecto.Nombre}")
                    || res.Equals($"Operacion exitoza: Se ha cargado la correccion del proyecto {request.Proyecto.Nombre}"))
                {
                    _unitOfWork.Commit();
                    return new CargarProyectoResponse(res);
                }
                else
                {
                    return new CargarProyectoResponse(res);
                }
            }
            else
            {
                return new CargarProyectoResponse($"El Usuario {request.Nombres} no existe.");
            }
        }

        public record CargarProyectoRequest
        (
            int Id,
            string Nombres,
            string Apellidos,
            string NumeroIdentificacion,
            string Correo,
            string Contraseña,
            Proyecto Proyecto
        );


        public record CargarProyectoResponse(string Mensaje);
    }
}
