using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Anteproyecto.Domain.Entities
{
    public class AsesorTematico : Usuario
    {
        public AsesorTematico(string nombres, string apellidos, string numeroIdentificacion, string correo, string contraseña) : base(nombres, apellidos, numeroIdentificacion, correo, contraseña)
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