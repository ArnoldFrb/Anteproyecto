using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;


namespace Anteproyecto.Domain.Entities
{
    public class Estudiante : Usuario
    {
        public Estudiante(string nombres, string apellidos, string numeroIdentificacion, string correo, string contraseña, int semestre, int edad, bool estado) : base(nombres, apellidos, numeroIdentificacion, correo, contraseña, semestre, edad, estado)
        {
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
                Contraseña = contraseña;
                return "Su nueva contraseña es correcta";
            }
            throw new NotImplementedException();
        }

        public override string ModificarCorreo(string correo)
        {
            string expresion = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            if (Regex.IsMatch(correo, expresion))
            {
                if (Regex.Replace(correo, expresion, String.Empty).Length == 0)
                {
                    return "El correo ingresado es valido";
                }
                else
                {
                    return "El correo ingresado es invalido";
                }
            }
            if (!Regex.IsMatch(correo, expresion))
            {
                return "El correo ingresado es invalido";
            }
            throw new NotImplementedException();
        }

        public override string ValidarUsuario(Usuario usuario)
        {
            if (usuario.Nombres == null || usuario.Apellidos == null || usuario.NumeroIdentificacion == null || usuario.Correo == null || usuario.Contraseña == null
                || usuario.Semestre <= 0 || usuario.Edad == 0 )
            {
                return "Digite los campos primordiales para el registro";
            }
            else
            {
                var res_1 = ModificarCorreo(usuario.Correo);

                if (!res_1.Equals("El correo ingresado es valido"))
                {
                    return res_1;
                }
                return $"El Usuario {usuario.Nombres} ha sido registrado correctamente";
            }
        }    

        public string Editar(string nombres, string apellidos, string numeroIdentificacion, string correo, int semestre, int edad, bool estado)
        {
            if (nombres == null || apellidos == null || numeroIdentificacion == null || correo == null || semestre <= 0 || edad == 0)
            {
                return "Digite los campos primordiales para el registro";
            }
            else
            {
                var res_1 = ModificarCorreo(correo);

                if (!res_1.Equals("El correo ingresado es valido"))
                {
                    return res_1;
                }

                Nombres = nombres;
                Apellidos = apellidos;
                NumeroIdentificacion = numeroIdentificacion;
                Semestre = semestre;
                Edad = edad;
                Estado = estado;

                return $"El Usuario {Nombres} ha sido modificado correctamente";
            }
        }

        public override string enviarPlantillaCorreo()
        {
            string contenido = "<html>Cordial saludo  " + Nombres +" " + Apellidos  + "," + "<br><br>"
                       + " El registro en el sistema de Valoracion de anteproyecto se realizo satifactoriamente " + "<br><br>"
                       + " Atentamente:" + "<br>" + "<br>"
                       + " Universidad Popular del Cesar." + "<br>"
                       + " Correo: 1234@unicesar.edu.co - Celular (Whatsapp): 3042065930" + "<br><br></html>";

            return contenido;
        }

        public string CambiarEstado(bool estado)
        {
            Estado = estado;
            return "El estado del estudiante fue cambiado";
        }


    }
}
