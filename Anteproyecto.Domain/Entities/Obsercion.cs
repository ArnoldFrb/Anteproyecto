using System;
using System.Collections.Generic;
using System.Text;

namespace Anteproyecto.Domain
{
    public class Obsercion
    {
        private string Nombre { get; set; }
        private string Comentario { get; set; }

        public Obsercion(string nombre, string comentario)
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
    }
}
