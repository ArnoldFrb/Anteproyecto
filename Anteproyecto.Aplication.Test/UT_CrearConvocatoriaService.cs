using Anteproyecto.Aplication.Test.Dobles;
using Anteproyecto.Domain.Entities;
using Anteproyecto.Infrastructure.Data.ObjectMother;
using Anteproyecto.Infrastructure.Data.Repositories;
using Infrastructure.Data;
using Infrastructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using static Anteproyecto.Aplication.CrearConvocatoriaService;

namespace Anteproyecto.Aplication.Test
{
    public class CrearConvocatoriaTest
    {

        private ProyectoContext _dbContext;
        private CrearConvocatoriaService _crearconvocatoriaService;

        [SetUp]
        public void Setup()
        {
            var optionsSqlite = new DbContextOptionsBuilder<ProyectoContext>()
           .UseSqlite(@"Data Source=C:\\BD\\AnteProyecto.db")
           .Options;
            _dbContext = new ProyectoContext(optionsSqlite);

            _crearconvocatoriaService = new CrearConvocatoriaService(new UnitOfWork(_dbContext), new ConvocatoriaRepository(_dbContext), new MailServerSpy());

        }

        [Test]
        public void crearConvocatoriaTest()
        {

            //Arrange
            var convocatoria = CrearConvocatoriaMother.CrearConvocatoria();
            
            _dbContext.Convocatorias.Add(convocatoria);
            _dbContext.SaveChanges();

            bool cargarProyectos = true;

            //Act
            var _convocatoria = new CrearConvocatoriaRequest { FechaInicio = convocatoria.FechaInicio, FechaCierre = convocatoria.FechaCierre, CargarProyectos = cargarProyectos };
            var response = _crearconvocatoriaService.CrearConvocatoria(_convocatoria);

            //Assert
          
            Assert.AreEqual("Se ha añadido la sigiente convocatoria, Inicio: 1/01/2021 12:00:00 a. m. / Fin: 1/03/2021 12:00:00 a. m..", response);

            _dbContext.Convocatorias.Remove(convocatoria);
            _dbContext.SaveChanges();
        } 
    }
}