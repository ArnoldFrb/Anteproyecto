using Anteproyecto.Aplication.Test.Dobles;
using Anteproyecto.Domain;
using Anteproyecto.Infrastructure.Data.Base;
using Infrastructure.Data;
using Infrastructure.Data.Repositories;
using NUnit.Framework;
using static Anteproyecto.Aplication.UsuarioService;

namespace Anteproyecto.Aplication.Test
{
    public class Tests
    {

        DbContextBase _context;

        [SetUp]
        public void Setup()
        {
            //Proximamente aplicar con WEBAPI

           //var optionsSqlServer = new DbContextOptionsBuilder<ProyectoContext>()
           //  .UseSqlite(@"Data Source=C:\Users\Andres\Documents\Aprendiendo\TestSqllite\BD\Test.db").Options;
           // _context = new DbContextBase(optionsSqlServer);
        }

        [Test]
        public void ModificarContraseñaTest()
        {

            //Arrange
            //var user = new UsuarioRequest{Id = "101010",Nombres = "Jose Carlo",Apellidos = "Santander Pimienta",NumeroIdentificacion = "0123456789",Correo = "hola@gmail.com",Contraseña = "123344444"};
            var user = new Estudiante("Jose Carlo","Santander Pimienta","0123456789","hola@gmail.com","123344444");
            ProyectoContext _contex = new ProyectoContext();

            _contex.Usuarios.Add(user);
            _contex.SaveChanges();

            var service = new UsuarioService(new UnitOfWork(_contex), new UsuarioRepository(_contex), new MailServerSpy());

             //Act
            var _user = new UsuarioRequest { Id = "00110", Nombres = "Jose Carlo", Apellidos = "Santander Pimienta", NumeroIdentificacion = "0123456789", Correo = "hola@gmail.com", Contraseña = "cambieperro" };
            var response = service.ModificarContraseña(_user);

            //Assert
            Assert.AreEqual("La contraseña a sido modificada satifctoriamente", response.Mensaje);

            _contex.Usuarios.Remove(user);
            _contex.SaveChanges();

        }

        [Test]
        public void ModificarCorreoTest()
        {

            //Arrange
            //var user = new UsuarioRequest{Id = "101010",Nombres = "Jose Carlo",Apellidos = "Santander Pimienta",NumeroIdentificacion = "0123456789",Correo = "hola@gmail.com",Contraseña = "123344444"};
            var user = new Estudiante("Jose Carlo", "Santander Pimienta", "0123456789", "hola@gmail.com", "123344444");
            ProyectoContext _contex = new ProyectoContext();

            _contex.Usuarios.Add(user);
            _contex.SaveChanges();

            var service = new UsuarioService(new UnitOfWork(_contex), new UsuarioRepository(_contex), new MailServerSpy());

            //Act
            var _user = new UsuarioRequest { Id = "200", Nombres = "Jose Carlo", Apellidos = "Santander Pimienta", NumeroIdentificacion = "0123456789", Correo = "Comoestaspedro@gmail.com", Contraseña = "cambieperro" };
            var response = service.ModificarCorreo(_user);

            //Assert
            Assert.AreEqual("El correo a sido modificada satifctoriamente", response.Mensaje);

            _contex.Usuarios.Remove(user);
            _contex.SaveChanges();

        }

    }
}