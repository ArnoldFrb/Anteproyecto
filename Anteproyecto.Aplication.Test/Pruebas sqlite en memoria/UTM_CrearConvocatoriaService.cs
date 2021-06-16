using Anteproyecto.Aplication.Test.Dobles;
using Anteproyecto.Domain.Entities;
using Anteproyecto.Infrastructure.Data.Repositories;
using Infrastructure.Data;
using Infrastructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using static Anteproyecto.Aplication.CrearConvocatoriaService;

namespace Anteproyecto.Aplication.Test
{
    public class CrearConvocatoriaInMemoryTest
    {

        private ProyectoContext _dbContext;
        private CrearConvocatoriaService _crearconvocatoriaService;

        [SetUp]
        public void Setup()
        {
            var optionsSqlite = new DbContextOptionsBuilder<ProyectoContext>()
            .UseSqlite(SqlLiteDatabaseInMemory.CreateConnection())
            .Options;
            _dbContext = new ProyectoContext(optionsSqlite);
            _dbContext.Database.EnsureCreated();

            _crearconvocatoriaService = new CrearConvocatoriaService(new UnitOfWork(_dbContext), new ConvocatoriaRepository(_dbContext), new MailServerSpy());

        }

        [Test]
        public void crearConvocatoriaInMemoryTest()
        {

            //Arrange
            var convocatoria = new Convocatoria(new DateTime(2021, 1, 1), new DateTime(2021, 3, 1));

            _dbContext.Convocatorias.Add(convocatoria);
            _dbContext.SaveChanges(); 

             //Act
            var _convocatoria = new CrearConvocatoriaRequest { FechaInicio= new DateTime(2021,1,1,12,0,0) , FechaCierre = new DateTime(2021,3,1,12,0,0), CargarProyectos = true };
            var response = _crearconvocatoriaService.CrearConvocatoria(_convocatoria);

            //Assert
          
            Assert.AreEqual("Se ha añadido la sigiente convocatoria, Inicio: 01/01/2021 12:00:00 p. m. / Fin: 01/03/2021 12:00:00 p. m..", response);

            _dbContext.Convocatorias.Remove(convocatoria);
            _dbContext.SaveChanges();

        } 
    }
}