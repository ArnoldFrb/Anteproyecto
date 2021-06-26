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
            var estudiante1 = UsuarioMother.crearUsuarioEstudiante("92345117");
            var estudiante2 = UsuarioMother.crearUsuarioEstudiante("913451118");
            var asesorTematico = UsuarioMother.crearUsuarioAsesorTematico("323456116");
            var asesorMetodologico = UsuarioMother.crearUsuarioAsesorMetodologico("456656116");

            var proyecto = ProyectoMother.CrearProyecto_();

            _dbContext.Usuarios.Add(estudiante1);
            _dbContext.Usuarios.Add(estudiante2);
            _dbContext.Usuarios.Add(asesorTematico);
            _dbContext.Usuarios.Add(asesorMetodologico);
            _dbContext.Proyectos.Add(proyecto);
            _dbContext.SaveChanges();

            // ACT // ACCION // CUANDO // WHEN
            var request = new CargarProyectoRequest(
                estudiante1.NumeroIdentificacion,
                estudiante2.NumeroIdentificacion,
                asesorTematico.NumeroIdentificacion,
                asesorMetodologico.NumeroIdentificacion,
                proyecto
            );
            var response = _proyectoService.CargarProyecto(request);

            //ASSERT //AFIRMACION //ENTONCES //THEN
            Assert.AreEqual($"Operacion exitoza: Se ha cargado el proyecto {request.Proyecto.Nombre}", response.Mensaje);

            _dbContext.Usuarios.Remove(estudiante1);
            _dbContext.Usuarios.Remove(estudiante2);
            _dbContext.Usuarios.Remove(asesorTematico);
            _dbContext.Usuarios.Remove(asesorMetodologico);
            _dbContext.Proyectos.Remove(proyecto);
            _dbContext.SaveChanges();
        }

        [Test]
        public void CargarCorrecionesDelProyectoText()
        {

            //ARRANGE //PREPARAR // DADO // GIVEN
            var estudiante1 = UsuarioMother.crearUsuarioEstudiante("923456678");
            var estudiante2 = UsuarioMother.crearUsuarioEstudiante("913456118");
            var asesorTematico = UsuarioMother.crearUsuarioAsesorTematico("333456118");
            var asesorMetodologico = UsuarioMother.crearUsuarioEstudiante("444456118");

            var proyecto = ProyectoMother.CrearProyecto();
            var proyecto2 = ProyectoMother.CrearProyecto2();

            _dbContext.Usuarios.Add(estudiante1);
            _dbContext.Usuarios.Add(estudiante2);
            _dbContext.Usuarios.Add(asesorTematico); 
            _dbContext.Usuarios.Add(asesorMetodologico);
            _dbContext.Proyectos.Add(proyecto);

            _dbContext.SaveChanges();

            // ACT // ACCION // CUANDO // WHEN
            var request = new CargarProyectoRequest(
                estudiante1.NumeroIdentificacion,
                estudiante2.NumeroIdentificacion,
                asesorTematico.NumeroIdentificacion,
                asesorMetodologico.NumeroIdentificacion,
                proyecto
            );
            _proyectoService.CargarProyecto(request);

            var request2 = new CargarProyectoRequest(
                estudiante1.NumeroIdentificacion,
                estudiante2.NumeroIdentificacion,
                asesorTematico.NumeroIdentificacion,
                asesorMetodologico.NumeroIdentificacion,
                proyecto2
            );
            var response = _proyectoService.CargarProyecto(request2);

            //ASSERT //AFIRMACION //ENTONCES //THEN
            Assert.AreEqual($"Operacion exitoza: Se ha cargado la correccion del proyecto {request.Proyecto.Nombre}", response.Mensaje);

            _dbContext.Usuarios.Remove(estudiante1);
            _dbContext.Usuarios.Remove(estudiante2);
            _dbContext.Usuarios.Remove(asesorTematico);
            _dbContext.Usuarios.Remove(asesorMetodologico);
            _dbContext.Proyectos.Remove(proyecto);
            _dbContext.SaveChanges();
        }
    }
}
