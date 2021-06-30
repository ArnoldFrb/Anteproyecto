using Anteproyecto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
namespace Anteproyecto.Infrastructure.Data.ObjectMother
{
    public static class UsuarioMother
    {
       public static Estudiante crearUsuarioEstudiante(string NumeroIdentificacion)
        {

            return new Estudiante("Jose Carlo", "Santander Pimienta", NumeroIdentificacion, "hzzzzola@gmail.com", "1233448889444", 9, 23, true);
        }

        public static MiembroComite crearUsuarioMiembroComite(string NumeroIdentificacion)
        {

            return new MiembroComite("Jose Carlo", "Santander Pimienta", NumeroIdentificacion, "hola@gmail.com", "123344444", 9, 23, true);
        }
        public static AsesorMetodologico crearUsuarioAsesorMetodologico(string NumeroIdentificacion)
        {

            return new AsesorMetodologico("Jose Carlo", "Santander Pimienta", NumeroIdentificacion, "hola@gmail.com", "123344444",0,29,true);
        }

        public static AsesorTematico crearUsuarioAsesorTematico(string NumeroIdentificacion)
        {
            return new AsesorTematico("Jose Carlo", "Santander Pimienta", NumeroIdentificacion, "hola@gmail.com", "123344444", 0, 29, true);
        }

    }
}
