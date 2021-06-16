using Anteproyecto.Aplication.Test.Dobles;
using Anteproyecto.Domain.Entities;
using Anteproyecto.Infrastructure.Data.ObjectMother;
using Anteproyecto.Infrastructure.Data.Repositories;
using Infrastructure.Data;
using Infrastructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using static Anteproyecto.Aplication.ConvocatoriaService;
using static Anteproyecto.Aplication.ProyectoService;

namespace Anteproyecto.Aplication.Test
{
    public class ConvocatoriaTest
    {

        private ProyectoContext _dbContext;
        private ConvocatoriaService _convocatoriaService;

        [SetUp]
        public void Setup()
        {
            var optionsSqlite = new DbContextOptionsBuilder<ProyectoContext>()
           .UseSqlite(@"Data Source=C:\\BD\\AnteProyecto.db")
           .Options;
            _dbContext = new ProyectoContext(optionsSqlite);

            _convocatoriaService = new ConvocatoriaService(new UnitOfWork(_dbContext), new ConvocatoriaRepository(_dbContext), new MailServerSpy());

        }

        [Test]
        public void ActivarCargaProyectosTest()
        {

            //Arrange
            var convocatoria = CrearConvocatoriaMother.CrearConvocatoria();

            _dbContext.Convocatorias.Add(convocatoria);
            _dbContext.SaveChanges(); 

             //Act
            var _convocatoria = new ConvocatoriaRequest {Id = 2, FechaInicio= new DateTime(2021,1,1) , FechaCierre = new DateTime(2021, 3, 1) };
            var response = _convocatoriaService.ActivarCargaProyectos(_convocatoria);

            //Assert
            Assert.AreEqual("La carga de proyectos ha sido activada", response.Mensaje);

            _dbContext.Convocatorias.Remove(convocatoria);
            _dbContext.SaveChanges();

        }

        [Test]
        public void DesactivarCargaProyectosTest()
        {

            //Arrange
            //var user = new UsuarioRequest{Id = "101010",Nombres = "Jose Carlo",Apellidos = "Santander Pimienta",NumeroIdentificacion = "0123456789",Correo = "hola@gmail.com",Contraseña = "123344444"};
            var convocatoria = CrearConvocatoriaMother.CrearConvocatoria();

            _dbContext.Convocatorias.Add(convocatoria);
            _dbContext.SaveChanges();

            //Act
            var _convocatoria = new ConvocatoriaRequest { Id = 1, FechaInicio = new DateTime(2022, 1, 1), FechaCierre = new DateTime(2022, 3, 1) };
            var response = _convocatoriaService.DesactivarCargaProyectos(_convocatoria);

            //Assert
            Assert.AreEqual("La carga de proyectos ha sido desactivada", response.Mensaje);

            _dbContext.Convocatorias.Remove(convocatoria);
            _dbContext.SaveChanges();

        }

    }
}