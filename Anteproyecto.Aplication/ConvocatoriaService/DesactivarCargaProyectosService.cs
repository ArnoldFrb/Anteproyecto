using Anteproyecto.Domain.Contracts;
using Anteproyecto.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anteproyecto.Aplication.ConvocatoriaService
{
    public class DesactivarCargaProyectosService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConvocatoriaRepository _convocatoriaRepository;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMailServer _mailServer;

        public DesactivarCargaProyectosService(IUnitOfWork unitOfWork, IConvocatoriaRepository convocatoriaRepository, IUsuarioRepository usuarioRepository, IMailServer mailServer)
        {
            _unitOfWork = unitOfWork;
            _convocatoriaRepository = convocatoriaRepository;
            _usuarioRepository = usuarioRepository;
            _mailServer = mailServer;
        }

        public DesactivarCargaProyectosResponse DesactivarCargaProyectos(DesactivarCargaProyectosRequest request)
        {
            var convocatoria = _convocatoriaRepository.FindFirstOrDefault(conv => conv.Id == request.Id);

            if (convocatoria != null)
            {
                var res = convocatoria.DesactivarCargaProyectos();

                if (res.Equals("Carga de proyectos desactivada."))
                {
                    _unitOfWork.Commit();

                    var users = _usuarioRepository.GetAll();
                    foreach (var doc in users)
                    {
                        if (doc.ToString().Equals("Anteproyecto.Domain.Entities.Estudiante"))
                        {
                            _mailServer.Send("arnold.fb16@gmail.com", "Se ha activado la carga de proyecot",
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

                    return new DesactivarCargaProyectosResponse(res);
                }
                else
                {
                    return new DesactivarCargaProyectosResponse(res);
                }
            }
            else
            {
                return new DesactivarCargaProyectosResponse("No existe la convocatoria");
            }
        }

        public record DesactivarCargaProyectosRequest
        (
            int Id
        );

        public record DesactivarCargaProyectosResponse(string Mensaje);
    }
}
