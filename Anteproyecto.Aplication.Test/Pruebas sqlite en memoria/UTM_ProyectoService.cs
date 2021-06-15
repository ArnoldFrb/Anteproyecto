using Anteproyecto.Aplication.Test.Dobles;
using Anteproyecto.Domain.Entities;
using Anteproyecto.Infrastructure.Data.ObjectMother;
using Anteproyecto.Infrastructure.Data.Repositories;
using Infrastructure.Data;
using Infrastructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using static Anteproyecto.Aplication.ProyectoService;

namespace Anteproyecto.Aplication.Test
{
    public class ProyectoInMemoryTest
    {

        private ProyectoContext _dbContext;
        private ProyectoService _proyectoService;

        [SetUp]
        public void Setup()
        {
            var optionsSqlite = new DbContextOptionsBuilder<ProyectoContext>()
           .UseSqlite(@"Data Source=C:\\BD\\AnteProyecto.db")
           .Options;
            _dbContext = new ProyectoContext(optionsSqlite);

            _proyectoService = new ProyectoService(new UnitOfWork(_dbContext), new ProyectoRepository(_dbContext), new MailServerSpy());

        }

        [Test]
        public void ValidarNombreInMemoryTest()
        {

            //Arrange
            var proyecto = ProyectoMother.crearProyecto("proyecto2");

            _dbContext.Proyectos.Add(proyecto);
            _dbContext.SaveChanges();
            string nombreDePrueba = "sistemas de informacion para la gestion del talento humano en el departmento del cesar colombia";

            //Act
            var _proyecto = new ProyectoRequest { Id = 2, Nombre = nombreDePrueba, Resumen = "Este es un proyecto" };
            var response = _proyectoService.ValidarNombre(_proyecto);

            //Assert
            Assert.AreEqual("El nombre ingresado es correcto", response.Mensaje);

            _dbContext.Proyectos.Remove(proyecto);
            _dbContext.SaveChanges();

        }

        [Test]
        public void ValidarResumenInMemoryTest()
        {

            //Arrange
            //var user = new UsuarioRequest{Id = "101010",Nombres = "Jose Carlo",Apellidos = "Santander Pimienta",NumeroIdentificacion = "0123456789",Correo = "hola@gmail.com",Contraseña = "123344444"};
            var proyecto = new Proyecto("Poryecto8", "Este es un resumen del proyecto para probar");
             
            _dbContext.Proyectos.Add(proyecto);
            _dbContext.SaveChanges();
             
            //Act
            var _proyecto = new ProyectoRequest { Id = 27, Nombre = "proyecto8", Resumen = "Este es un resumen del proyecto para probar" };
            var response = _proyectoService.ValidarResumen(_proyecto);

            //Assert
            Assert.AreEqual("El resumen ingresado es correcto", response.Mensaje);

            _dbContext.Proyectos.Remove(proyecto);
            _dbContext.SaveChanges();

        }

    }
}