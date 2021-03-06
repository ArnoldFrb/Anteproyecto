using Anteproyecto.Aplication.Test.Dobles;
using Anteproyecto.Domain.Entities;
using Anteproyecto.Infrastructure.Data.ObjectMother;
using Anteproyecto.Infrastructure.Data.Repositories;
using Infrastructure.Data;
using Infrastructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using static Anteproyecto.Aplication.ValidarNombreProyectoService;

namespace Anteproyecto.Aplication.Test
{
    public class ProyectoTest
    {

        private ProyectoContext _dbContext;
        private ValidarNombreProyectoService _proyectoService;

        [SetUp]
        public void Setup()
        {
            var optionsSqlite = new DbContextOptionsBuilder<ProyectoContext>()
           .UseSqlite(@"Data Source=C:\\BD\\AnteProyecto.db")
           .Options;
            _dbContext = new ProyectoContext(optionsSqlite);

            _proyectoService = new ValidarNombreProyectoService(new UnitOfWork(_dbContext), new ProyectoRepository(_dbContext), new MailServerSpy());

        }

        [Test]
        public void ValidarNombreTest()
        {

            //Arrange
            var proyecto = ProyectoMother.CrearProyecto();
                 
            _dbContext.Proyectos.Add(proyecto);
            _dbContext.SaveChanges(); 

             //Act
            var _proyecto = new ProyectoRequest {Id = proyecto.Id, Nombre="proyecto2", Resumen="Este es un proyecto"};
            var response = _proyectoService.ValidarNombre(_proyecto);

            //Assert
            Assert.AreEqual("El nombre ingresado es correcto", response.Mensaje);

            _dbContext.Proyectos.Remove(proyecto);
            _dbContext.SaveChanges();

        }

        [Test]
        public void ValidarResumenTest()
        {

            //Arrange
            //var user = new UsuarioRequest{Id = "101010",Nombres = "Jose Carlo",Apellidos = "Santander Pimienta",NumeroIdentificacion = "0123456789",Correo = "hola@gmail.com",Contraseņa = "123344444"};
            var proyecto = ProyectoMother.CrearProyecto();

            _dbContext.Proyectos.Add(proyecto);
            _dbContext.SaveChanges();
             
            //Act
            var _proyecto = new ProyectoRequest { Id = 0001, Nombre = "proyecto8", Resumen = "Este es un proyecto" };
            var response = _proyectoService.ValidarResumen(_proyecto);

            //Assert
            Assert.AreEqual("El resumen ingresado es correcto", response.Mensaje);

            _dbContext.Proyectos.Remove(proyecto);
            _dbContext.SaveChanges();

        }

    }
}