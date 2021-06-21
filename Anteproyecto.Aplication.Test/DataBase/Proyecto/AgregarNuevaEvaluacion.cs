using Anteproyecto.Aplication.ProyectoService;
using Anteproyecto.Aplication.Test.Dobles;
using Anteproyecto.Domain.Entities;
using Anteproyecto.Infrastructure.Data.ObjectMother;
using Anteproyecto.Infrastructure.Data.Repositories;
using Infrastructure.Data;
using Infrastructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using static Anteproyecto.Aplication.ProyectoService.AgregarEvaluacionAProyectoService;

namespace Anteproyecto.Aplication.Test.DataBase
{
    class AgregarNuevaEvaluacion
    {
        private ProyectoContext _dbContext;
        private AgregarEvaluacionAProyectoService _agregarEvaluacion;

        [SetUp]
        public void Setup()
        {
            var optionsSqlite = new DbContextOptionsBuilder<ProyectoContext>()
           .UseSqlite(@"Data Source=C:\\BD\\AnteProyecto.db")
           .Options;

            _dbContext = new ProyectoContext(optionsSqlite);
            _dbContext.Database.EnsureDeleted();
            _dbContext.Database.EnsureCreated();

            _agregarEvaluacion = new AgregarEvaluacionAProyectoService(new UnitOfWork(_dbContext), new ProyectoRepository(_dbContext), new MailServerSpy());
        }

        [Test]
        public void AgregarNuevaEvaluacionText()
        {

            //ARRANGE //PREPARAR // DADO // GIVEN
            var proyecto = ProyectoMother.CrearProyecto();
            var evaluacion = new Evaluacion("Where does it come from?", "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", false);

            _dbContext.Evaluacion.Add(evaluacion);
            _dbContext.Proyectos.Add(proyecto);
            _dbContext.SaveChanges();

            // ACT // ACCION // CUANDO // WHEN
            var reques = new AgregarEvaluacionAProyectoReques(
                proyecto.Id,
                proyecto.Nombre,
                proyecto.Resumen,
                proyecto.Obsercion,
                evaluacion,
                proyecto.AsesorTematico,
                proyecto.AsesorMetodologico
            );
            var response = _agregarEvaluacion.AgregarEvaluacion(reques);

            //ASSERT //AFIRMACION //ENTONCES //THEN
            Assert.AreEqual("Nueva Evaluacion: Where does it come from?", response.Mensaje);

            _dbContext.Evaluacion.Remove(evaluacion);
            _dbContext.Proyectos.Remove(proyecto);
            _dbContext.SaveChanges();

        }
    }
}
