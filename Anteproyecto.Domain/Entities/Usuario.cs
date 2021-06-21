using System;
using Anteproyecto.Domain.Contracts;
using Anteproyecto.Domain.Entities;

namespace Anteproyecto.Domain.Entities
{
    public abstract class Usuario : Entity<int>, IServicioUsuario
    {
        public string Nombres { get; protected set; }
        public string Apellidos { get; protected set; }
        public string NumeroIdentificacion { get; protected set; }
        public string Correo { get; protected set; }
        public string Contraseña { get; protected set; }

        protected Usuario(string nombres, string apellidos, string numeroIdentificacion, string correo, string contraseña)
        {
            Nombres = nombres;
            Apellidos = apellidos;
            NumeroIdentificacion = numeroIdentificacion;
            Correo = correo;
            Contraseña = contraseña;
        }

        public abstract string ModificarCorreo(string correo);
        public abstract string ModificarContrasena(string contraseña);

        public abstract string ValidarUsuario(Usuario usuario);
        
    }
}
