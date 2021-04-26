using Anteproyecto.Aplication.Test.Dobles;
using Anteproyecto.Domain;
using Anteproyecto.Domain.Entities;
using Anteproyecto.Infrastructure.Data.Base;
using Infrastructure.Data;
using Infrastructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using static Anteproyecto.Aplication.UsuarioService;

namespace Anteproyecto.Aplication.Test
{
    public class UsurioServiceTests
    {

        private ProyectoContext _dbContext;
        private UsuarioService _usuarioService;

        [SetUp]
        public void Setup()
        {
            var optionsSqlite = new DbContextOptionsBuilder<ProyectoContext>()
           .UseSqlite(@"Data Source=C:\\BD\\AnteProyecto.db")
           .Options;
            _dbContext = new ProyectoContext(optionsSqlite);

            _usuarioService = new UsuarioService(new UnitOfWork(_dbContext), new UsuarioRepository(_dbContext), new MailServerSpy());
        }

        [Test]
        public void ModificarContraseņaTest()
        {

            //Arrange
            //var user = new UsuarioRequest{Id = "101010",Nombres = "Jose Carlo",Apellidos = "Santander Pimienta",NumeroIdentificacion = "0123456789",Correo = "hola@gmail.com",Contraseņa = "123344444"};
            var user = new Estudiante("Jose Carlo","Santander Pimienta","0123456789","hola@gmail.com","123344444");

            _dbContext.Usuarios.Add(user);
            _dbContext.SaveChanges();

             //Act
            var _user = new UsuarioRequest {Nombres = "Jose Carlo", Apellidos = "Santander Pimienta", NumeroIdentificacion = "0123456789", Correo = "hola@gmail.com", Contraseņa = "cambieperro" };
            var response = _usuarioService.ModificarContraseņa(_user);

            //Assert
            Assert.AreEqual("La contraseņa a sido modificada satifctoriamente", response.Mensaje);

            _dbContext.Usuarios.Remove(user);
            _dbContext.SaveChanges();

        }

        [Test]
        public void ModificarCorreoTest()
        {

            //Arrange
            //var user = new UsuarioRequest{Id = "101010",Nombres = "Jose Carlo",Apellidos = "Santander Pimienta",NumeroIdentificacion = "0123456789",Correo = "hola@gmail.com",Contraseņa = "123344444"};
            var user = new Estudiante("Jose Carlo", "Santander Pimienta", "0123456789", "hola@gmail.com", "123344444");
            
            _dbContext.Usuarios.Add(user);
            _dbContext.SaveChanges();

            //Act
            var _user = new UsuarioRequest {Nombres = "Jose Carlo", Apellidos = "Santander Pimienta", NumeroIdentificacion = "0123456789", Correo = "Comoestaspedro@gmail.com", Contraseņa = "cambieperro" };
            var response = _usuarioService.ModificarCorreo(_user);

            //Assert
            Assert.AreEqual("El correo a sido modificada satifctoriamente", response.Mensaje);

            _dbContext.Usuarios.Remove(user);
            _dbContext.SaveChanges();

        }

    }
}