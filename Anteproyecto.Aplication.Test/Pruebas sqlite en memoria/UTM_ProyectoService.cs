using Anteproyecto.Aplication.Test.Dobles;
using Anteproyecto.Domain.Entities;
using Anteproyecto.Infrastructure.Data.Repositories;
using Infrastructure.Data;
using Infrastructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using static Anteproyecto.Aplication.ValidarNombreProyectoService;

namespace Anteproyecto.Aplication.Test
{
    public class ProyectoInMemoryTest
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
        public void ValidarNombreInMemoryTest()
        {

            //Arrange
            var proyecto = new Proyecto("proyecto1", "Este proyecto es importane");

            _dbContext.Proyectos.Add(proyecto);
            _dbContext.SaveChanges(); 

             //Act
            var _proyecto = new ProyectoRequest {Id = proyecto.Id, Nombre="proyecto1", Resumen="Este es un proyecto"};
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
            var proyecto = new Proyecto("Aplicativo Web Para la Gestión, seguimiento y evaluación de los anteproyectos del programa de Psicología de la Universidad Popular del Cesar", "El aplicativo web a desarrollar tiene como objetivo ser una herramienta que permita gestionar y controlar de manera adecuada el seguimiento de los anteproyectos recibidos en la oficina de psicología en la Universidad Popular del Cesar, ubicada en la ciudad de Valledupar. Para esto se requiere que el sistema pueda");
             
            _dbContext.Proyectos.Add(proyecto);
            _dbContext.SaveChanges();
             
            //Act
            var _proyecto = new ProyectoRequest { Id = 1, Nombre = "proyecto8", Resumen = "El aplicativo web a desarrollar tiene como objetivo ser una herramienta que permita gestionar y controlar de manera adecuada el seguimiento de los anteproyectos recibidos en la oficina de psicología en la Universidad Popular del Cesar, ubicada en la ciudad de Valledupar. Para esto se requiere que el sistema pueda" };
            var response = _proyectoService.ValidarResumen(_proyecto);

            //Assert
            Assert.AreEqual("El resumen ingresado es correcto", response.Mensaje);

            _dbContext.Proyectos.Remove(proyecto);
            _dbContext.SaveChanges();

        }

    }
}