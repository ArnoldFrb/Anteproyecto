using Anteproyecto.Aplication.ProyectoService;
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

namespace Anteproyecto.Aplication.Test.DataBase.Estudiante
{
    class ListarEstudiantes
    {
        private ProyectoContext _dbContext;
        private ListarEstudiantesService _estudiantesService;

        [SetUp]
        public void Setup()
        {
            var optionsSqlite = new DbContextOptionsBuilder<ProyectoContext>()
           .UseSqlite(@"Data Source=C:\\BD\\AnteProyecto.db")
           .Options;

            _dbContext = new ProyectoContext(optionsSqlite);
            _dbContext.Database.EnsureDeleted();
            _dbContext.Database.EnsureCreated();

            _estudiantesService = new ListarEstudiantesService(new UnitOfWork(_dbContext), new UsuarioRepository(_dbContext), new MailServerSpy());
        }

        [Test]
        public void ListarEstudiantesTest()
        {
            //ARRANGE //PREPARAR // DADO // GIVEN
            var estudiante = UsuarioMother.crearUsuarioEstudiante("123456678");
            var estudiant1 = UsuarioMother.crearUsuarioAsesorTematico("123456678");
            var estudiant2 = UsuarioMother.crearUsuarioAsesorTematico("123456678");
            var estudiant3 = UsuarioMother.crearUsuarioEstudiante("123456678");

            _dbContext.Usuarios.Add(estudiante);
            _dbContext.Usuarios.Add(estudiant1);
            _dbContext.Usuarios.Add(estudiant2);
            _dbContext.Usuarios.Add(estudiant3);
            _dbContext.SaveChanges();

            // ACT // ACCION // CUANDO // WHEN
            
            var response = _estudiantesService.ListarEstudiantes();

            foreach (var doc in response.Estudiantes)
            {
                Console.WriteLine(doc.Apellidos);
            }
            //ASSERT //AFIRMACION //ENTONCES //THEN
            Assert.AreEqual("Lista de Usuarios", response.Mensaje);

            _dbContext.Usuarios.Remove(estudiante);
            _dbContext.Usuarios.Remove(estudiant1);
            _dbContext.Usuarios.Remove(estudiant2);
            _dbContext.Usuarios.Remove(estudiant3);
            _dbContext.SaveChanges();
        }

        [Test]
        public void NoSePudoEncontrarUsuariosEstudiantes()
        {
            //ARRANGE //PREPARAR // DADO // GIVEN
            var estudiant1 = UsuarioMother.crearUsuarioAsesorTematico("123456678");
            var estudiant2 = UsuarioMother.crearUsuarioAsesorTematico("123456678");

            _dbContext.Usuarios.Add(estudiant1);
            _dbContext.Usuarios.Add(estudiant2);
            _dbContext.SaveChanges();

            // ACT // ACCION // CUANDO // WHEN

            var response = _estudiantesService.ListarEstudiantes();

            if (response.Estudiantes != null)
            {
                foreach (var doc in response.Estudiantes)
                {
                    Console.WriteLine(doc.Apellidos);
                }
            }
            //ASSERT //AFIRMACION //ENTONCES //THEN
            Assert.AreEqual("No se ncontraron Estudiantes registrados", response.Mensaje);

            _dbContext.Usuarios.Remove(estudiant1);
            _dbContext.Usuarios.Remove(estudiant2);
            _dbContext.SaveChanges();
        }
    }
}
