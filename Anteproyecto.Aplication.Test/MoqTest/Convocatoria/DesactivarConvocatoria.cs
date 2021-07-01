using Anteproyecto.Aplication.ConvocatoriaService;
using Anteproyecto.Aplication.Test.Dobles;
using Anteproyecto.Domain.Contracts;
using Anteproyecto.Infrastructure.Data.ObjectMother;
using Anteproyecto.Infrastructure.Data.Repositories;
using Infrastructure.Data;
using Infrastructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Anteproyecto.Aplication.ConvocatoriaService.ActivarCargaProyectosService;
using static Anteproyecto.Aplication.ConvocatoriaService.DesactivarCargaProyectosService;

namespace Anteproyecto.Aplication.Test.MoqTest.Convocatoria
{
    class DesactivarConvocatoria
    {
        private ProyectoContext _dbContext;
        private DesactivarCargaProyectosService _convocatoriaService1;
        private ActivarCargaProyectosService _convocatoriaService2;

        [SetUp]
        public void Setup()
        {
            var optionsSqlite = new DbContextOptionsBuilder<ProyectoContext>()
          .UseSqlite(SqlLiteDatabaseInMemory.CreateConnection())
          .Options;

            _dbContext = new ProyectoContext(optionsSqlite);
            _dbContext.Database.EnsureCreated();
        }

        [Test]
        public void ActualizarEstudianteTest()
        {
            //ARRANGE //PREPARAR // DADO // GIVEN
            var convocatoria = CrearConvocatoriaMother.CrearConvocatoria();

            _dbContext.Convocatorias.Add(convocatoria);
            _dbContext.SaveChanges();

            var mockEmailServer = new Mock<IMailServer>();
            mockEmailServer.Setup(emailServer =>
               emailServer.Send(
                   It.IsAny<string>(),
                   It.IsAny<string>(),
                   It.IsAny<string>())
                ).Returns(Task.CompletedTask);

            _convocatoriaService1 = new DesactivarCargaProyectosService(new UnitOfWork(_dbContext), new ConvocatoriaRepository(_dbContext), new UsuarioRepository(_dbContext), mockEmailServer.Object);
            _convocatoriaService2 = new ActivarCargaProyectosService(new UnitOfWork(_dbContext), new ConvocatoriaRepository(_dbContext), new UsuarioRepository(_dbContext), mockEmailServer.Object);

            // ACT // ACCION // CUANDO // WHEN
            var request1 = new DesactivarCargaProyectosRequest(1);
            var request2 = new ActivarCargaProyectosRequest(1);

            _convocatoriaService2.ActivarCargaProyectos(request2);
            var response = _convocatoriaService1.DesactivarCargaProyectos(request1);

            //ASSERT //AFIRMACION //ENTONCES //THEN
            Assert.AreEqual("Carga de proyectos desactivada.", response.Mensaje);

            _dbContext.Convocatorias.Remove(convocatoria);
            _dbContext.SaveChanges();
        }
    }
}
