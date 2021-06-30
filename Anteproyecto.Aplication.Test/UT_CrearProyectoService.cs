
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
            _dbContext.Database.EnsureDeleted();
            _dbContext.Database.EnsureCreated();

            _CrearProyectoService = new CrearProyectoService(new UnitOfWork(_dbContext), new ProyectoRepository(_dbContext), new MailServerSpy());

        }

        [Test]
        public void verificarProyectosCargadosTest()
        {

            //ARRANGE //PREPARAR // DADO // GIVEN
            var proyecto = ProyectoMother.CrearProyecto();

            _dbContext.Proyectos.Add(proyecto);
            _dbContext.SaveChanges();

            // ACT // ACCION // CUANDO // WHEN
            var _proyecto = new CrearProyectoRequest {Nombre = proyecto.Nombre, Resumen = proyecto.Resumen };
            var response = _CrearProyectoService.CrearProyecto(_proyecto);

            //ASSERT //AFIRMACION //ENTONCES //THEN
            Assert.AreEqual("El Nombre del proyecto ya ha sido registrado", response);

            _dbContext.Proyectos.Remove(proyecto);
            _dbContext.SaveChanges();

        }
         
    }
}