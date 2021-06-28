using Anteproyecto.Aplication.Test.Dobles;
using Anteproyecto.Domain;
using Anteproyecto.Domain.Entities;
using Anteproyecto.Infrastructure.Data.Base;
using Infrastructure.Data;
using Infrastructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using static Anteproyecto.Aplication.UsuariosService;

namespace Anteproyecto.Aplication.Test
{
    public class UsurioServiceInMemoryTests
    {

        private ProyectoContext _dbContext;
        private UsuariosService _usuarioService;

        [SetUp]
        public void Setup()
        {
            var optionsSqlite = new DbContextOptionsBuilder<ProyectoContext>()
          .UseSqlite(@"Data Source=C:\\BD\\AnteProyecto.db")
          .Options;
            _dbContext = new ProyectoContext(optionsSqlite);

            _usuarioService = new UsuariosService(new UnitOfWork(_dbContext), new UsuarioRepository(_dbContext), new MailServerSpy());
        }

        [Test]
        public void ModificarContraseaInMemoryTest()
        {

            //Arrange
            //var user = new UsuarioRequest{Id = "101010",Nombres = "Jose Carlo",Apellidos = "Santander Pimienta",NumeroIdentificacion = "0123456789",Correo = "hola@gmail.com",Contrase�a = "123344444"};
            var user = new Estudiante("Jose Carlo","Santander Pimienta","0123456781","hola@gmail.com","123344444",8,23,true);

            _dbContext.Usuarios.Add(user);
            _dbContext.SaveChanges();

             //Act
            var _user = new UsuarioRequest {Id= 0003,Nombres = "Jose Carlo", Apellidos = "Santander Pimienta", NumeroIdentificacion = "0123456781", Correo = "hola@gmail.com", Contraseña = "cambieperro" };
            var response = _usuarioService.ModificarContraseña(_user);

            //Assert
            Assert.AreEqual("La contraseña a sido modificada satifctoriamente", response.Mensaje);

            _dbContext.Usuarios.Remove(user);
            _dbContext.SaveChanges();

        }

        [Test]
        public void ModificarCorreoInMemoryTest()
        {

            //Arrange
            //var user = new UsuarioRequest{Id = "101010",Nombres = "Jose Carlo",Apellidos = "Santander Pimienta",NumeroIdentificacion = "0123456789",Correo = "hola@gmail.com",Contrase�a = "123344444"};
            var user = new Estudiante("Jose Carlo", "Santander Pimienta", "0123456781", "hola@gmail.com", "123344444",8,24,true);
            
            _dbContext.Usuarios.Add(user);
            _dbContext.SaveChanges();

            //Act
            var _user = new UsuarioRequest {Id= 0003, Nombres = "Jose Carlo", Apellidos = "Santander Pimienta", NumeroIdentificacion = "0123456781", Correo = "Comoestaspedro@gmail.com", Contraseña = "cambieperro" };
            var response = _usuarioService.ModificarCorreo(_user);

            //Assert
            Assert.AreEqual("El correo a sido modificada satifctoriamente", response.Mensaje);

            _dbContext.Usuarios.Remove(user);
            _dbContext.SaveChanges();

        }

    }
}