using System;
using System.Collections.Generic;
using System.Text;

namespace Anteproyecto.Domain
{
    public class Evaluacion
    {
        private string Nombre { get; set; }
        private string Comentario { get; set; }
        private bool Estado { get; set; }

        public Evaluacion(string nombre, string comentario, bool estado)
        {
            Nombre = nombre;
            Comentario = comentario;
            Estado = estado;
        }

        public string ValidarNombre(string nombre)
        {
            if (nombre.Length == 0)
            {
                return "Registro Fallido, El Dato recibido se encuantra vacio";
            }
            if (nombre.Length > 0 && nombre.Length >= 35)
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

    }
}
