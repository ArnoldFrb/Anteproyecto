using Anteproyecto.Aplication.EstuduanteService;
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
using static Anteproyecto.Aplication.EstuduanteService.CargarProyectoService;

namespace Anteproyecto.Aplication.Test.DataBase.Estudiante
{
    public class CargarProyecto
    {
        private ProyectoContext _dbContext;
        private CargarProyectoService _proyectoService;

        [SetUp]
        public void Setup()
        {
            var optionsSqlite = new DbContextOptionsBuilder<ProyectoContext>()
           .UseSqlite(@"Data Source=C:\\BD\\AnteProyecto.db")
           .Options;

            _dbContext = new ProyectoContext(optionsSqlite);
            _dbContext.Database.EnsureDeleted();
            _dbContext.Database.EnsureCreated();

            _proyectoService = new CargarProyectoService(new UnitOfWork(_dbContext), new UsuarioRepository(_dbContext), new ProyectoRepository(_dbContext), new MailServerSpy());
        }

        [Test]
        public void CargarProyectoText()
        {

            //ARRANGE //PREPARAR // DADO // GIVEN
            var estudiante = UsuarioMother.crearUsuarioEstudiante("123456678");
            var proyecto = ProyectoMother.CrearProyecto();

            _dbContext.Usuarios.Add(estudiante);
            _dbContext.Proyectos.Add(proyecto);
            _dbContext.SaveChanges();

            // ACT // ACCION // CUANDO // WHEN
            var request = new CargarProyectoRequest(
                estudiante.Id,
                estudiante.Nombres,
                estudiante.Apellidos,
                estudiante.NumeroIdentificacion,
                estudiante.Correo,
                estudiante.Contraseña,
                proyecto
            );
            var response = _proyectoService.CargarProyecto(request);

            //ASSERT //AFIRMACION //ENTONCES //THEN
            Assert.AreEqual($"Operacion exitoza: Se ha cargado el proyecto {request.Proyecto.Nombre}", response.Mensaje);

            _dbContext.Usuarios.Remove(estudiante);
            _dbContext.Proyectos.Remove(proyecto);
            _dbContext.SaveChanges();
        }

        [Test]
        public void CargarCorrecionesDelProyectoText()
        {

            //ARRANGE //PREPARAR // DADO // GIVEN
            var estudiante = UsuarioMother.crearUsuarioEstudiante("123456678");
            var proyecto = ProyectoMother.CrearProyecto();
            var proyecto2 = ProyectoMother.CrearProyecto2();

            _dbContext.Usuarios.Add(estudiante);
            _dbContext.Proyectos.Add(proyecto);
            _dbContext.SaveChanges();

            // ACT // ACCION // CUANDO // WHEN
            var request = new CargarProyectoRequest(
                estudiante.Id,
                estudiante.Nombres,
                estudiante.Apellidos,
                estudiante.NumeroIdentificacion,
                estudiante.Correo,
                estudiante.Contraseña,
                proyecto
            );
            _proyectoService.CargarProyecto(request);

            var request2 = new CargarProyectoRequest(
                estudiante.Id,
                estudiante.Nombres,
                estudiante.Apellidos,
                estudiante.NumeroIdentificacion,
                estudiante.Correo,
                estudiante.Contraseña,
                proyecto2
            );
            var response = _proyectoService.CargarProyecto(request2);

            //ASSERT //AFIRMACION //ENTONCES //THEN
            Assert.AreEqual($"Operacion exitoza: Se ha cargado la correccion del proyecto {request.Proyecto.Nombre}", response.Mensaje);

            _dbContext.Usuarios.Remove(estudiante);
            _dbContext.Proyectos.Remove(proyecto);
            _dbContext.SaveChanges();
        }
    }
}
