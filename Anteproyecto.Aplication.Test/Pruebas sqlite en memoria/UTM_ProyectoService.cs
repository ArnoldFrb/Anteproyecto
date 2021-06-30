using Anteproyecto.Aplication.Test.Dobles;
using Anteproyecto.Domain.Entities;
<<<<<<< HEAD
=======
using Anteproyecto.Infrastructure.Data.ObjectMother;
>>>>>>> Implementacion_cambios
using Anteproyecto.Infrastructure.Data.Repositories;
using Infrastructure.Data;
using Infrastructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
<<<<<<< HEAD
using static Anteproyecto.Aplication.ValidarNombreProyectoService;
=======
using static Anteproyecto.Aplication.ProyectoService;
>>>>>>> Implementacion_cambios

namespace Anteproyecto.Aplication.Test
{
    public class ProyectoInMemoryTest
    {

        private ProyectoContext _dbContext;
<<<<<<< HEAD
        private ValidarNombreProyectoService _proyectoService;
=======
        private ProyectoService _proyectoService;
>>>>>>> Implementacion_cambios

        [SetUp]
        public void Setup()
        {
            var optionsSqlite = new DbContextOptionsBuilder<ProyectoContext>()
           .UseSqlite(@"Data Source=C:\\BD\\AnteProyecto.db")
           .Options;
            _dbContext = new ProyectoContext(optionsSqlite);

<<<<<<< HEAD
            _proyectoService = new ValidarNombreProyectoService(new UnitOfWork(_dbContext), new ProyectoRepository(_dbContext), new MailServerSpy());
=======
            _proyectoService = new ProyectoService(new UnitOfWork(_dbContext), new ProyectoRepository(_dbContext), new MailServerSpy());
>>>>>>> Implementacion_cambios

        }

        [Test]
        public void ValidarNombreInMemoryTest()
        {

            //Arrange
<<<<<<< HEAD
            var proyecto = new Proyecto("proyecto1", "Este proyecto es importane");

            _dbContext.Proyectos.Add(proyecto);
            _dbContext.SaveChanges(); 

             //Act
            var _proyecto = new ProyectoRequest {Id = proyecto.Id, Nombre="proyecto1", Resumen="Este es un proyecto"};
=======
            var proyecto = ProyectoMother.crearProyecto("proyecto2");

            _dbContext.Proyectos.Add(proyecto);
            _dbContext.SaveChanges();
            string nombreDePrueba = "sistemas de informacion para la gestion del talento humano en el departmento del cesar colombia";

            //Act
            var _proyecto = new ProyectoRequest { Id = 2, Nombre = nombreDePrueba, Resumen = "Este es un proyecto" };
>>>>>>> Implementacion_cambios
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
<<<<<<< HEAD
            var proyecto = new Proyecto("Aplicativo Web Para la Gestión, seguimiento y evaluación de los anteproyectos del programa de Psicología de la Universidad Popular del Cesar", "El aplicativo web a desarrollar tiene como objetivo ser una herramienta que permita gestionar y controlar de manera adecuada el seguimiento de los anteproyectos recibidos en la oficina de psicología en la Universidad Popular del Cesar, ubicada en la ciudad de Valledupar. Para esto se requiere que el sistema pueda");
=======
            var proyecto = new Proyecto("Poryecto8", "Este es un resumen del proyecto para probar");
>>>>>>> Implementacion_cambios
             
            _dbContext.Proyectos.Add(proyecto);
            _dbContext.SaveChanges();
             
            //Act
<<<<<<< HEAD
            var _proyecto = new ProyectoRequest { Id = 1, Nombre = "proyecto8", Resumen = "El aplicativo web a desarrollar tiene como objetivo ser una herramienta que permita gestionar y controlar de manera adecuada el seguimiento de los anteproyectos recibidos en la oficina de psicología en la Universidad Popular del Cesar, ubicada en la ciudad de Valledupar. Para esto se requiere que el sistema pueda" };
=======
            var _proyecto = new ProyectoRequest { Id = 0001, Nombre = "proyecto8", Resumen = "Este es un resumen del proyecto para probar" };
>>>>>>> Implementacion_cambios
            var response = _proyectoService.ValidarResumen(_proyecto);

            //Assert
            Assert.AreEqual("El resumen ingresado es correcto", response.Mensaje);

            _dbContext.Proyectos.Remove(proyecto);
            _dbContext.SaveChanges();

        }

    }
}