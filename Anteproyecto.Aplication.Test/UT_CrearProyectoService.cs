using Anteproyecto.Aplication.Test.Dobles;
using Anteproyecto.Domain.Entities;
using Anteproyecto.Infrastructure.Data.ObjectMother;
using Anteproyecto.Infrastructure.Data.Repositories;
using Infrastructure.Data;
using Infrastructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using static Anteproyecto.Aplication.CrearProyectoService;

namespace Anteproyecto.Aplication.Test
{
    public class CrearProyectoServiceTest
    {

        private ProyectoContext _dbContext;
        private CrearProyectoService _CrearProyectoService;

        [SetUp]
        public void Setup()
        {
            var optionsSqlite = new DbContextOptionsBuilder<ProyectoContext>()
           .UseSqlite(@"Data Source=C:\\BD\\AnteProyecto.db")
           .Options;
            _dbContext = new ProyectoContext(optionsSqlite);

            _CrearProyectoService = new CrearProyectoService(new UnitOfWork(_dbContext), new ProyectoRepository(_dbContext), new MailServerSpy());

        }

        [Test]
        public void CargaProyectosTest()
        {

            //Arrange
            var proyecto = ProyectoMother.crearProyecto("proyecto1");

            _dbContext.Proyectos.Add(proyecto);
            _dbContext.SaveChanges(); 

             //Act
            var _proyecto = new CrearProyectoRequest {Nombre = "proyecto6", Resumen = "Este es un proyecto" };
            var response = _CrearProyectoService.CrearProyecto(_proyecto);

            //Assert
            Assert.AreEqual("Se agrego con exito el proyecto: proyecto6.", response);

            _dbContext.Proyectos.Remove(proyecto);
            _dbContext.SaveChanges();

        } 
    }
}