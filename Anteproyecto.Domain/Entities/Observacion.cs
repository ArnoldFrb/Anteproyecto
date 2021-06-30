using System;
using System.Collections.Generic;
using System.Text;

namespace Anteproyecto.Domain.Entities
{
    public class Observacion : Entity<int>
    {
        public string Nombre { get; private set; }
        public string Comentario { get; private set; }
        public Proyecto Proyecto { get; private set; }
        public DateTime Date { get; set; }
        public Observacion(string nombre, string comentario)
        {
            Nombre = nombre;
            Comentario = comentario;
        }

        public string ValidarNombre(string nombre)
        {
            if (nombre.Length == 0)
            {
                return "Registro Fallido, El Dato recibido se encuantra vacio";
            }
            if (nombre.Length > 0 && nombre.Length >= 15)
            {
                Nombre = nombre;
                return "Registro Exitozo, Se ha registrado el nuevo Nombre";
            }
            throw new NotImplementedException();
        }

        public string ValidarComentario(string comentario)
        {
            if (comentario.Length == 0)
            {
                return "Registro Fallido, El Dato recibido se encuantra vacio";
            }
            if (comentario.Length > 0 && comentario.Length >= 100)
            {
                Comentario = comentario;
                return "Registro Exitozo, Se ha registrado el nuevo Comentario";
            }
            throw new NotImplementedException();
        }

        public string AgregarObservacion(string nombre, string comentario, Proyecto proyecto)
        {
            var nombreResponse = ValidarNombre(nombre);
            var comentarioResponse = ValidarComentario(comentario);

            if (!nombreResponse.Equals("Registro Exitozo, Se ha registrado el nuevo Nombre"))
            {
                return nombreResponse;
            }
            if (!comentarioResponse.Equals("Registro Exitozo, Se ha registrado el nuevo Comentario"))
            {
                return nombreResponse;
            }

            Proyecto = proyecto;
            Date = DateTime.Now;
            return $"Nueva Observacon: {Nombre}";
        }


        public string enviarPlantillaCorreo()
        {
            string contenido = "<html>Cordial saludo  " + Proyecto.Estudiante1.Nombres  + "," + "<br><br>"
                       + " Se realizo una nueva observacion  al proyecto: "+ Proyecto.Nombre + "<br><br>"
                       + " Titulo de la observacion: " + Nombre + "<br><br>"
                       + " Observacion: " + Comentario + "<br><br>"
                       + " Atentamente:" + "<br>" + "<br>"
                       + " Universidad Popular del Cesar." + "<br>"
                       + " Correo: 1234@unicesar.edu.co - Celular (Whatsapp): 3042065930" + "<br><br></html>";

            return contenido;
        }

    }
}
