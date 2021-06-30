using Anteproyecto.Aplication.EstuduanteService;
using Anteproyecto.Aplication.Test.Dobles;
using Anteproyecto.Infrastructure.Data.ObjectMother;
using Infrastructure.Data;
using Infrastructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Anteproyecto.Aplication.EstuduanteService.ActualizarEstudianteService;

namespace Anteproyecto.Aplication.Test.DataBase.Estudiante
{
    class ActualizarEstudiante
    {
        private ProyectoContext _dbContext;
        private ActualizarEstudianteService _estudianteService;

        [SetUp]
        public void Setup()
        {
            var optionsSqlite = new DbContextOptionsBuilder<ProyectoContext>()
           .UseSqlite(@"Data Source=C:\\BD\\AnteProyecto.db")
           .Options;

            _dbContext = new ProyectoContext(optionsSqlite);
            _dbContext.Database.EnsureDeleted();
            _dbContext.Database.EnsureCreated();

            _estudianteService = new ActualizarEstudianteService(new UnitOfWork(_dbContext), new UsuarioRepository(_dbContext), new MailServerSpy());
        }

        [Test]
        public void ActualizarEstudianteTest()
        {
            //ARRANGE //PREPARAR // DADO // GIVEN 1222222212 1234566789
            var estudiante = UsuarioMother.crearUsuarioEstudiante("1234566789");

            _dbContext.Usuarios.Add(estudiante);
            _dbContext.SaveChanges();

            // ACT // ACCION // CUANDO // WHEN
            var request = new ActualizarEstudianteRequest(
                estudiante.Nombres,
                estudiante.Apellidos,
                estudiante.NumeroIdentificacion,
                estudiante.Correo,
                estudiante.Semestre,
                estudiante.Edad,
                false
            );

            var response = _estudianteService.ActualizarEstudiante(request);

            //ASSERT //AFIRMACION //ENTONCES //THEN
            Assert.AreEqual($"El Usuario {estudiante.Nombres} ha sido modificado correctamente", response.Mensaje);

            _dbContext.Usuarios.Remove(estudiante);
            _dbContext.SaveChanges();
        }
    }
}
