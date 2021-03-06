using Anteproyecto.Domain;
using Anteproyecto.Domain.Entities;
using NUnit.Framework;
using static Anteproyecto.Aplication.UsuariosService;

namespace Anteproyecto.Aplication.Test.Dobles
{
    class UTFAKE_UsuarioService
    {

        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void ModificarContraseñaFakeTest()
        {
            var user = new Estudiante("Jose Carlo", "Santander Pimienta", "23456789", "hola@gmail.com", "123344444",9,23,true);
            var service = new UsuariosService(new UnitOfWorkFake(), new CuentaRepositoryFake(), new MailServerSpy());
             
            //Act 
            var _user = new UsuarioRequest { 
                Id = 10, 
                Nombres = "Jose Carlo", Apellidos = "Santander Pimienta", NumeroIdentificacion = "0123456789", Correo = "hola@gmail.com", Contraseña = "cambieperro" };
            
            var response = service.ModificarContraseña(_user);

            //Assert
            Assert.AreEqual("La contraseña a sido modificada satifctoriamente", response.Mensaje);
             
        }
     }
}
