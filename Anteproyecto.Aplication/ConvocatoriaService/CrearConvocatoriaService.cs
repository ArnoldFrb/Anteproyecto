using Anteproyecto.Domain.Contracts;
using Anteproyecto.Domain.Entities;
using Anteproyecto.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anteproyecto.Aplication.ConvocatoriaService
{
    public class CrearConvocatoriaService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConvocatoriaRepository _convocatoriaRepository;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMailServer _mailServer;

        public CrearConvocatoriaService(IUnitOfWork unitOfWork, IConvocatoriaRepository convocatoriaRepository, IUsuarioRepository usuarioRepository, IMailServer mailServer)
        {
            _unitOfWork = unitOfWork;
            _convocatoriaRepository = convocatoriaRepository;
            _usuarioRepository = usuarioRepository;
            _mailServer = mailServer;
        }

        public CrearConvocatoriaResponse CrearConvocatoria(CrearConvocatoriaRequest request)
        {
            var convocatoria = new Convocatoria(request.FechaInicio, request.FechaCierre);
            var res = convocatoria.CrearConvocatoria(request.FechaInicio, request.FechaCierre, request.CargarProyectos);

            if (res.Equals($"Se ha creado la convocatoria para las fechas: Inicio: {convocatoria.FechaInicio} / Cierre: {convocatoria.FechaCierre}"))
            {
                _convocatoriaRepository.Add(convocatoria);

                var users = _usuarioRepository.GetAll();
                foreach (var doc in users)
                {
                    if (doc.ToString().Equals("Anteproyecto.Domain.Entities.Estudiante"))
                    {
                        _mailServer.Send(doc.Correo, "Se ha activado la carga de proyecto",
                            "<html>Cordial saludo Estudiantes de la UPC," + "<br><br>"
                            + " Este correo es con el fin de informar que ya esta habilitada la plataforma para cargar sus proyectos de grado." + "<br><br>"
                            + " Con las fechas estipuladas entre:" + "<br><br>"
                            + " Inicio: " + convocatoria.FechaInicio + "<br><br>"
                            + " Cierre: " + convocatoria.FechaCierre + "<br><br>"
                            + "<br><br>"
                            + " Atentamente:" + "<br>" + "<br>"
                            + " Universidad Popular del Cesar." + "<br>"
                            + " Correo: 1234@unicesar.edu.co - Celular (Whatsapp): 3042065930" + "<br><br></html>");
                    }
                }

                _unitOfWork.Commit();
                return new CrearConvocatoriaResponse(res);
            }
            else
            {
                return new CrearConvocatoriaResponse(res);
            }
        }

        public record CrearConvocatoriaRequest
        (
            DateTime FechaInicio,
            DateTime FechaCierre,
            bool CargarProyectos
        );

        public record CrearConvocatoriaResponse(string Mensaje);
    }
}
