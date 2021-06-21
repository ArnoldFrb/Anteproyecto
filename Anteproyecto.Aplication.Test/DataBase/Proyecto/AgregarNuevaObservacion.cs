using Anteproyecto.Aplication.ProyectoService;
using Anteproyecto.Aplication.Test.Dobles;
using Anteproyecto.Infrastructure.Data.ObjectMother;
using Anteproyecto.Infrastructure.Data.Repositories;
using Infrastructure.Data;
using Infrastructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Anteproyecto.Aplication.ProyectoService.AgregarObservacionAProyectoService;

namespace Anteproyecto.Aplication.Test.DataBase
{
    public class AgregarNuevaObservacion
    {
        private ProyectoContext _dbContext;
        private AgregarObservacionAProyectoService _agregarObservacion;

        [SetUp]
        public void Setup()
        {
            var optionsSqlite = new DbContextOptionsBuilder<ProyectoContext>()
           .UseSqlite(@"Data Source=C:\\BD\\AnteProyecto.db")
           .Options;

            _dbContext = new ProyectoContext(optionsSqlite);
            _dbContext.Database.EnsureDeleted();
            _dbContext.Database.EnsureCreated();

            _agregarObservacion = new AgregarObservacionAProyectoService(new UnitOfWork(_dbContext), new ProyectoRepository(_dbContext), new ObservacionRepository(_dbContext), new MailServerSpy());
        }

        [Test]
        public void AgregarNuevaEvaluacionText()
        {

            //ARRANGE //PREPARAR // DADO // GIVEN
            var proyecto = ProyectoMother.CrearProyecto();
            var observacion = ObservacionMother.Observacion();

            _dbContext.Observacion.Add(observacion);
            _dbContext.Proyectos.Add(proyecto);
            _dbContext.SaveChanges();

            // ACT // ACCION // CUANDO // WHEN
            var reques = new AgregarObservacionAProyectoReques(
                proyecto.Id,
                proyecto.Nombre,
                proyecto.Resumen,
                observacion,
                proyecto.Evaluacion,
                proyecto.AsesorTematico,
                proyecto.AsesorMetodologico
            );
            var response = _agregarObservacion.AgregarObservacion(reques);

            //ASSERT //AFIRMACION //ENTONCES //THEN
            Assert.AreEqual("Nueva Observacon: Where does it come from?", response.Mensaje);

            _dbContext.Observacion.Remove(observacion);
            _dbContext.Proyectos.Remove(proyecto);
            _dbContext.SaveChanges();

        }
    }
}
