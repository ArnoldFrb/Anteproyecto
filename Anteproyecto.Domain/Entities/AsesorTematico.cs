using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Anteproyecto.Domain.Entities
{
    public class AsesorTematico : Usuario
    {
        public AsesorTematico(string nombres, string apellidos, string numeroIdentificacion, string correo, string contraseña, int semestre, int edad, bool estado) : base(nombres, apellidos, numeroIdentificacion, correo, contraseña, semestre, edad, estado)
        {
        }

        public override string enviarPlantillaCorreo()
        {
            string contenido = "<html>Cordial saludo  " + Nombres + " " + Apellidos + "," + "<br><br>"
                        + " El registro en el sistema de Valoracion de anteproyecto se realizo satifactoriamente " + "<br><br>"
                        + " Atentamente:" + "<br>" + "<br>"
                        + " Universidad Popular del Cesar." + "<br>"
                        + " Correo: 1234@unicesar.edu.co - Celular (Whatsapp): 3042065930" + "<br><br></html>";

            return contenido;
        }

        public override string ModificarContrasena(string contraseña)
        {
            if (Contraseña.Equals(contraseña))
            {
                return "No puede ingresar una contraseña igual a la registrada, pruebe de nuevo";
            }
            if (!Contraseña.Equals(contraseña) && contraseña.Length < 10)
            {
                return "Su nueva contraseña es muy corta, pruebe de nuevo";
            }
            if (!Contraseña.Equals(contraseña) && contraseña.Length >= 10)
            {
                return "Su nueva contraseña es correcta";
            }
            throw new NotImplementedException();
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