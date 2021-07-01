using Anteproyecto.Aplication.ConvocatoriaService;
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
using static Anteproyecto.Aplication.ConvocatoriaService.CrearConvocatoriaService;

namespace Anteproyecto.Aplication.Test.DataBase
{
    class Convocatoria
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

             //Act
            var _convocatoria = new CrearConvocatoriaRequest (convocatoria.FechaInicio, convocatoria.FechaCierre, convocatoria.CargarProyectos);
            var response = _crearconvocatoriaService.CrearConvocatoria(_convocatoria);

            //Assert 01 / 01 / 2021 12:00:00 p.m.

            Assert.AreEqual($"Se ha creado la convocatoria para las fechas: Inicio: {convocatoria.FechaInicio} / Cierre: {convocatoria.FechaCierre}", response.Mensaje);

        } 
    }
}
