using System;
using System.Collections.Generic;
using System.Text;

namespace Anteproyecto.Domain.Entities
{
    public class Evaluacion : Entity<int>
    {
        public string Nombre { get; private set; }
        public string Comentario { get; private set; }
        public bool Estado { get; private set; }
        public Proyecto Proyecto { get; private set; }
        public DateTime Date { get; set; }

        public Evaluacion(int id, string nombre, string comentario, bool estado)
        {
            Id = id;
            Nombre = nombre;
            Comentario = comentario;
            Estado = estado;
        }

        public Evaluacion(string nombre, string comentario, bool estado)
        {
            Nombre = nombre;
            Comentario = comentario;
            Estado = estado;
        }

        public Evaluacion() { }

        public string ValidarNombre(string nombre)
        {
            if (nombre.Length == 0)
            {
                return "Registro Fallido, El Dato recibido se encuantra vacio";
            }
            if (nombre.Length > 10)
            {
                Nombre = nombre;
                return $"Registro Exitozo: {Nombre}";
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
                return $"Registro Exitozo: {Comentario}";
            }
            throw new NotImplementedException();
        }

        public string Evaluar(bool estado)
        {
            if (Estado == estado)
            {
                return "Registro Fallido, Este estado se encuentra registrado";
            }
            if (Estado != estado)
            {
                return "Registro Exitozo, El estado a sido modificado";
            }
            throw new NotImplementedException();
        }

        public string AgregarEvaluacion(string nombre, string comentario, bool estado, Proyecto proyecto)
        {
            var nombreResponse = ValidarNombre(nombre);
            var comentarioResponse = ValidarComentario(comentario);

            if (!nombreResponse.Equals($"Registro Exitozo: {Nombre}"))
            {
                return nombreResponse;
            }
            if (!comentarioResponse.Equals($"Registro Exitozo: {Comentario}"))
            {
                return nombreResponse;
            }

            Proyecto = proyecto;
            Estado = estado;
            Date = DateTime.Now;
            return $"Nueva Evaluacion: {Nombre}";
        }

        public string enviarPlantillaCorreo()
        {
            string contenido = "<html>Cordial saludo  " + Proyecto.Estudiante1.Nombres + "," + "<br><br>"
                       + " Se realizo una nueva evaluacion  al proyecto" + Nombre + "<br><br>"
                       + " Atentamente:" + "<br>" + "<br>"
                       + " Universidad Popular del Cesar." + "<br>"
                       + " Correo: 1234@unicesar.edu.co - Celular (Whatsapp): 3042065930" + "<br><br></html>";

            return contenido;
        }


    }
}
