using Anteproyecto.Aplication.ProyectoService;
using Anteproyecto.Aplication.Test.Dobles;
using Anteproyecto.Infrastructure.Data.ObjectMother;
using Anteproyecto.Infrastructure.Data.Repositories;
using Infrastructure.Data;
using Infrastructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using static Anteproyecto.Aplication.ProyectoService.AgregarAsesorMetodoloficoService;

namespace Anteproyecto.Aplication.Test.DataBase
{
    class AgregarAsesorMetodolofico
    {
        private ProyectoContext _dbContext;
        private AgregarAsesorMetodoloficoService _agregarAsesor;

        [SetUp]
        public void Setup()
        {
            var optionsSqlite = new DbContextOptionsBuilder<ProyectoContext>()
           .UseSqlite(@"Data Source=C:\\BD\\AnteProyecto.db")
           .Options;

            _dbContext = new ProyectoContext(optionsSqlite);
            _dbContext.Database.EnsureDeleted();
            _dbContext.Database.EnsureCreated();

            _agregarAsesor = new AgregarAsesorMetodoloficoService(new UnitOfWork(_dbContext), new ProyectoRepository(_dbContext), new UsuarioRepository(_dbContext), new MailServerSpy());
        }

        [Test]
        public void AgregarAsesorMetodoloficoText()
        {

            //ARRANGE //PREPARAR // DADO // GIVEN
            var proyecto = ProyectoMother.CrearProyecto();
            var user = UsuarioMother.crearUsuarioAsesorMetodologico("123456789");

            _dbContext.Usuarios.Add(user);
            _dbContext.Proyectos.Add(proyecto);
            _dbContext.SaveChanges();

            // ACT // ACCION // CUANDO // WHEN
            var reques = new AgregarAsesorMetodoloficoReques(
                proyecto.Id,
                proyecto.Nombre,
                proyecto.Resumen,
                proyecto.Obsercion,
                proyecto.Evaluacion,
                proyecto.AsesorTematico,
                user
            );
            var response = _agregarAsesor.AgregarAsesor(reques);

            //ASSERT //AFIRMACION //ENTONCES //THEN
            Assert.AreEqual("Se ha asignado el Asesor Metodologico Jose Carlo", response.Mensaje);

            _dbContext.Usuarios.Remove(user);
            _dbContext.Proyectos.Remove(proyecto);
            _dbContext.SaveChanges();

        }
    }
}
