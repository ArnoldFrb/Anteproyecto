using NUnit.Framework;

namespace Anteproyecto.Domain.Test
{
    class UTMiembroComite
    {
        [SetUp]
        public void Setup()
        {
        }

        /*
         Modificar Contraseña 
            H1: Como Estudiante quiero modificar mi contraseña de acceso en el sistema para tener mayor seguridad.
            Criterio de Aceptación:
            1.2 La contraseña no puede ser igual a la anterior.
            Dado El estudiante tiene una cuenta en el sistema 
            Id "101010" Nombres "Jose Carlos" Apellidos "Santander Pimienta" NumeroIdentificacion "0123456789" Correo "hola@gmail.com" Contraseña "@#Hl1g2l34"
            Cuando Ingresa una contraseña igual a la anterior; Contraseña "@#Hl1g2l34"
            Entonces El sistema presentará el mensaje. “No puede ingresar una contraseña igual a la registrada, pruebe de nuevo”
        */
        [Test]
        public void NoPuedeIngresarContraseñaIgualALaAnterior()
        {
            //ARRANGE //PREPARAR // DADO // GIVEN
            var estudiante = new Estudiante("Jose Carlo", "Santander Pimienta", "0123456789", "hola@gmail.com", "@#Hl1g2l34");
            // ACT // ACCION // CUANDO // WHEN
            var resultado = estudiante.ModificarContrasena("@#Hl1g2l34");
            //ASSERT //AFIRMACION //ENTONCES //THEN
            Assert.Pass("No puede ingresar una contraseña igual a la registrada, pruebe de nuevo", resultado);
        }

        /*
         Modificar Contraseña 
            H1: Como Estudiante quiero modificar mi contraseña de acceso en el sistema para tener mayor seguridad.
            Criterio de Aceptación:
            1.2 La contraseña debe ser mayor a 10 caracteres.
            Dado El estudiante tiene una cuenta en el sistema 
            Id "101010" Nombres "Jose Carlos" Apellidos "Santander Pimienta" NumeroIdentificacion "0123456789" Correo "hola@gmail.com" Contraseña "@#Hl1g2l34"
            Cuando Ingresa una contraseña mayor o igual a 10 caracteres; Contraseña "g2l34@#Hl1"
            Entonces El sistema presentará el mensaje. “Su nueva contraseña es correcta”
        */
        [Test]
        public void PuedeIngresarContraseñaMayorOIgualA10Caracteres()
        {
            //ARRANGE //PREPARAR // DADO // GIVEN
            var estudiante = new Estudiante("Jose Carlo", "Santander Pimienta", "0123456789", "hola@gmail.com", "@#Hl1g2l34");
            // ACT // ACCION // CUANDO // WHEN
            var resultado = estudiante.ModificarContrasena("g2l34@#Hl1");
            //ASSERT //AFIRMACION //ENTONCES //THEN
            Assert.Pass("Su nueva contraseña es correcta", resultado);
        }

        /*
         Modificar Correo 
            H1: Como Estudiante quiero modificar mi correo de acceso en el sistema para mantener mi informacion actualizada.
            Criterio de Aceptación:
            1.2 El Correo no debe tener espacios o faltar el @.
            Dado El estudiante tiene una cuenta en el sistema 
            Id "101010" Nombres "Jose Carlos" Apellidos "Santander Pimienta" NumeroIdentificacion "0123456789" Correo "hola@gmail.com" Contraseña "@#Hl1g2l34"
            Cuando Ingresar el correo con espacio; correo "g2l34@#Hl1"
            Entonces El sistema presentará el mensaje. “Su nueva contraseña es correcta”
        */
        [Test]
        public void NoPuedeIngresarCorreosConEspacios()
        {
            //ARRANGE //PREPARAR // DADO // GIVEN
            var estudiante = new Estudiante("Jose Carlo", "Santander Pimienta", "0123456789", "hola@gmail.com", "@#Hl1g2l34");
            // ACT // ACCION // CUANDO // WHEN
            var resultado = estudiante.ModificarCorreo("hol @gmail.com");
            //ASSERT //AFIRMACION //ENTONCES //THEN
            Assert.Pass("El correo ingresado es invalido", resultado);
        }

        /*
         Modificar Correo 
            H1: Como Estudiante quiero modificar mi correo de acceso en el sistema para mantener mi informacion actualizada.
            Criterio de Aceptación:
            1.2 El Correo no debe tener espacios o faltar el @.
            Dado El estudiante tiene una cuenta en el sistema 
            Id "101010" Nombres "Jose Carlos" Apellidos "Santander Pimienta" NumeroIdentificacion "0123456789" Correo "hola@gmail.com" Contraseña "@#Hl1g2l34"
            Cuando Ingresar el correo con espacio; correo "g2l34@#Hl1"
            Entonces El sistema presentará el mensaje. “Su nueva contraseña es correcta”
        */
        [Test]
        public void NoPuedeIngresarCorreosSinArroba()
        {
            //ARRANGE //PREPARAR // DADO // GIVEN
            var estudiante = new Estudiante("Jose Carlo", "Santander Pimienta", "0123456789", "hola@gmail.com", "@#Hl1g2l34");
            // ACT // ACCION // CUANDO // WHEN
            var resultado = estudiante.ModificarCorreo("holagmail.com");
            //ASSERT //AFIRMACION //ENTONCES //THEN
            Assert.Pass("El correo ingresado es invalido", resultado);
        }

        /*
         Modificar Correo 
            H1: Como Estudiante quiero modificar mi correo de acceso en el sistema para mantener mi informacion actualizada.
            Criterio de Aceptación:
            1.2 El Correo no debe tener espacios o faltar el @.
            Dado El estudiante tiene una cuenta en el sistema 
            Id "101010" Nombres "Jose Carlos" Apellidos "Santander Pimienta" NumeroIdentificacion "0123456789" Correo "hola@gmail.com" Contraseña "@#Hl1g2l34"
            Cuando Ingresar el correo con espacio; correo "g2l34@#Hl1"
            Entonces El sistema presentará el mensaje. “Su nueva contraseña es correcta”
        */
        [Test]
        public void PuedeIngresarCorreosConEstructuraAdecuada()
        {
            //ARRANGE //PREPARAR // DADO // GIVEN
            var estudiante = new Estudiante("Jose Carlo", "Santander Pimienta", "0123456789", "hola@gmail.com", "@#Hl1g2l34");
            // ACT // ACCION // CUANDO // WHEN
            var resultado = estudiante.ModificarCorreo("mundo@gmail.com");
            //ASSERT //AFIRMACION //ENTONCES //THEN
            Assert.Pass("El correo ingresado es valido", resultado);
        }
    }
}
