using Anteproyecto.Aplication.Test.Dobles;
using Anteproyecto.Infrastructure.Data.ObjectMother;
using Infrastructure.Data;
using Infrastructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using static Anteproyecto.Aplication.CrearUsuarioServicio;

namespace Anteproyecto.Aplication.Test.TesUsaurio
{

    public class UT_crearUsuarioService
    {

        private ProyectoContext _dbContext;
        private CrearUsuarioServicio _crearusuarioService;

        [SetUp]
        public void Setup()
        {
            var optionsSqlite = new DbContextOptionsBuilder<ProyectoContext>()
           .UseSqlite(@"Data Source=C:\\BD\\AnteProyecto.db")
           .Options;
            _dbContext = new ProyectoContext(optionsSqlite);
            _dbContext.Database.EnsureDeleted();
            _dbContext.Database.EnsureCreated();

            _crearusuarioService = new CrearUsuarioServicio(new UnitOfWork(_dbContext), new UsuarioRepository(_dbContext), new MailServerSpy());
        }

        [Test]
        public void validarUsuarioYaExisteEnlaBDTest()
        {

            //Arrange
            var user = UsuarioMother.crearUsuarioEstudiante("0123456780");

            _dbContext.Usuarios.Add(user);
            _dbContext.SaveChanges();

            //Act
            var _user = new crearUsuarioRequest { Nombres = user.Nombres, Apellidos = user.Apellidos, NumeroIdentificacion = user.NumeroIdentificacion, Correo = user.NumeroIdentificacion, Contraseña = user.Contraseña };
            var response = _crearusuarioService.CrearCuentaBancaria(_user);

            //Assert
            Assert.AreEqual("El estudiante con ese numero de cedula ya esta registrado", response.Mensaje);

            _dbContext.Usuarios.Remove(user);
            _dbContext.SaveChanges();

        }

        [Test]
        public void validarDatosUsuarioDeNuevoUsuariosTest()
        {

            //Arrange
            var user = UsuarioMother.crearUsuarioEstudiante("0123456780");
              
            //Act
            var _user = new crearUsuarioRequest { Nombres = user.Nombres, Apellidos = null, NumeroIdentificacion = user.NumeroIdentificacion, Correo = user.NumeroIdentificacion, Contraseña = user.Contraseña };
            var response = _crearusuarioService.CrearCuentaBancaria(_user);

            //Assert
            Assert.AreEqual("Digite los campos primordiales para su registro", response.Mensaje);

           
        }

    }
}
