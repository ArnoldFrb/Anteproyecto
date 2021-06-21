using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;


namespace Anteproyecto.Domain.Entities
{
    public class AsesorMetodologico : Usuario
    {
        public AsesorMetodologico(string nombres, string apellidos, string numeroIdentificacion, string correo, string contraseña, int semestre, int edad, bool estado) : base(nombres, apellidos, numeroIdentificacion, correo, contraseña, semestre, edad, estado)
        {
        }

        public override string ModificarContrasena(string contraseña)
        {
            throw new System.NotImplementedException();
        }

        public override string ModificarCorreo(string correo)
        {
            throw new System.NotImplementedException();
        }

        public override string ValidarUsuario(Usuario usuario)
        {
            throw new NotImplementedException();
        }
    }
}