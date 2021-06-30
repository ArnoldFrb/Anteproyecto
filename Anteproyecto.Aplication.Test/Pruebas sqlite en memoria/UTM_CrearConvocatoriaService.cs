using Anteproyecto.Aplication.Test.Dobles;
using Anteproyecto.Domain.Entities;
using Anteproyecto.Infrastructure.Data.Repositories;
using Infrastructure.Data;
using Infrastructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using static Anteproyecto.Aplication.ConvocatoriaService;
using static Anteproyecto.Aplication.CrearConvocatoriaService;


namespace Anteproyecto.Aplication.Test
{
    public class CrearConvocatoriaInMemoryTest
    {

        private ProyectoContext _dbContext;
        private CrearConvocatoriasService _crearconvocatoriaService;

        [SetUp]
        public void Setup()
        {
            var optionsSqlite = new DbContextOptionsBuilder<ProyectoContext>()
            .UseSqlite(SqlLiteDatabaseInMemory.CreateConnection())
            .Options;
            _dbContext = new ProyectoContext(optionsSqlite);
            _dbContext.Database.EnsureCreated();

            _crearconvocatoriaService = new CrearConvocatoriasService(new UnitOfWork(_dbContext), new ConvocatoriaRepository(_dbContext), new MailServerSpy());

        }

        [Test]
        public void crearConvocatoriaInMemoryTest()
        {

            //Arrange
            var convocatoria = new Convocatoria(new DateTime(2021, 1, 1, 12, 0, 0), new DateTime(2021, 3, 1, 12, 0, 0));

            _dbContext.Convocatorias.Add(convocatoria);
            _dbContext.SaveChanges(); 

             //Act
            var _convocatoria = new CrearConvocatoriaRequest { Id=1, FechaInicio= new DateTime(2021,1,1,12,0,0) , FechaCierre = new DateTime(2021,3,1,12,0,0), CargarProyectos = true };
            var response = _crearconvocatoriaService.CrearConvocatoria(_convocatoria);

            //Assert

            Assert.AreEqual("Se ha anadido la sigiente convocatoria, Inicio: viernes, 1 de enero de 2021 / Fin: lunes, 1 de marzo de 2021", response);

            _dbContext.Convocatorias.Remove(convocatoria);
            _dbContext.SaveChanges();

        } 
    }
}