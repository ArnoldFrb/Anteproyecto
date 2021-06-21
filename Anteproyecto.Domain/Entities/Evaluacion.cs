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

    }
}
