using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Anteproyecto.Domain.Entities
{
    public class MiembroComite : Usuario
    {
        public MiembroComite(string nombres, string apellidos, string numeroIdentificacion, string correo, string contraseña, int semestre, int edad, bool estado) : base(nombres, apellidos, numeroIdentificacion, correo, contraseña, semestre, edad, estado)
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
                    Correo = correo;
                    return $"El correo ingresado es valido {correo}";
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
                || usuario.Semestre <= 0 || usuario.Edad == 0)
            {
                return "Digite los campos primordiales para el registro";
            }
            else
            {
                var res_1 = ModificarCorreo(usuario.Correo);
                var res_2 = ModificarContrasena(usuario.Correo);

                if (!res_1.Equals("El correo ingresado es valido"))
                {
                    return res_1;
                }
                if (!res_2.Equals("Su nueva contraseña es correcta"))
                {
                    return res_2;
                }
                return $"El Usuario {usuario.Nombres} ha sido registrado correctamente";
            }
        }

        public string Editar(Usuario usuario)
        {
            if (usuario.Nombres == null || usuario.Apellidos == null || usuario.NumeroIdentificacion == null || usuario.Correo == null || usuario.Contraseña == null
                || usuario.Semestre <= 0 || usuario.Edad == 0)
            {
                return "Digite los campos primordiales para el registro";
            }
            else
            {
                var res_1 = ModificarCorreo(usuario.Correo);
                var res_2 = ModificarContrasena(usuario.Correo);

                if (!res_1.Equals("El correo ingresado es valido"))
                {
                    return res_1;
                }
                if (!res_2.Equals("Su nueva contraseña es correcta"))
                {
                    return res_2;
                }

                Nombres = usuario.Nombres;
                Apellidos = usuario.Apellidos;
                NumeroIdentificacion = usuario.NumeroIdentificacion;
                Correo = usuario.Correo;
                Contraseña = usuario.Contraseña;
                Semestre = usuario.Semestre;
                Edad = usuario.Edad;

                return $"El Usuario {usuario.Nombres} ha sido modificado correctamente";
            }
        }
    }
}
