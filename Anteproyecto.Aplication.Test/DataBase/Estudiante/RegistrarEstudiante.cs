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
using static Anteproyecto.Aplication.EstuduanteService.RegistrarEstudianteService;

namespace Anteproyecto.Aplication.Test.DataBase.Estudiante
{
    class RegistrarEstudiante
    {
        private ProyectoContext _dbContext;
        private RegistrarEstudianteService _estudianteService;

        [SetUp]
        public void Setup()
        {
            var optionsSqlite = new DbContextOptionsBuilder<ProyectoContext>()
           .UseSqlite(@"Data Source=C:\\BD\\AnteProyecto.db")
           .Options;

            _dbContext = new ProyectoContext(optionsSqlite);
            _dbContext.Database.EnsureDeleted();
            _dbContext.Database.EnsureCreated();

            _estudianteService = new RegistrarEstudianteService(new UnitOfWork(_dbContext), new UsuarioRepository(_dbContext), new MailServerSpy());
        }

        [Test]
        public void RegistrarEstudianteTest()
        {
            //ARRANGE //PREPARAR // DADO // GIVEN
            var estudiante = UsuarioMother.crearUsuarioEstudiante("1234566789");
            // ACT // ACCION // CUANDO // WHEN
            var request = new RegistrarEstudianteRequest(
                estudiante.Nombres,
                estudiante.Apellidos,
                estudiante.NumeroIdentificacion,
                estudiante.Correo,
                estudiante.Contraseña,
                estudiante.Semestre,
                estudiante.Edad,
                estudiante.Estado
            );

            var response = _estudianteService.RegistrarEstudiante(request);

            //ASSERT //AFIRMACION //ENTONCES //THEN
            Assert.AreEqual($"El Usuario {estudiante.Nombres} ha sido registrado correctamente", response.Mensaje);

        }
    }
}
