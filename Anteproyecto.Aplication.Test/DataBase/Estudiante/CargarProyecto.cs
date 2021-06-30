using Anteproyecto.Aplication.ProyectoService;
using Anteproyecto.Aplication.Test.Dobles;
using Anteproyecto.Infrastructure.Data.ObjectMother;
using Anteproyecto.Infrastructure.Data.Repositories;
using Infrastructure.Data;
using Infrastructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.IO;
using System.Reflection;
using static Anteproyecto.Aplication.ProyectoService.ActualizarProyectoService;
using static Anteproyecto.Aplication.ProyectoService.CargarProyectoService;

namespace Anteproyecto.Aplication.Test.DataBase.Estudiante
{
    public class CargarProyecto
    {
        private ProyectoContext _dbContext;
        private CargarProyectoService _proyectoService;
        private ConvocatoriasService _convocatoriaService;
        private ActualizarProyectoService _ActualizarProyectoService;
        private ConsultarProyectoService _ConsultarProyectoService;

        [SetUp]
        public void Setup()
        {
            var optionsSqlite = new DbContextOptionsBuilder<ProyectoContext>()
           .UseSqlite(@"Data Source=C:\\BD\\AnteProyecto.db")
           .Options;

            _dbContext = new ProyectoContext(optionsSqlite);
            _dbContext.Database.EnsureDeleted();
            _dbContext.Database.EnsureCreated();

            _proyectoService = new CargarProyectoService(new UnitOfWork(_dbContext), new UsuarioRepository(_dbContext), new ProyectoRepository(_dbContext), new ConvocatoriaRepository(_dbContext), new MailServerSpy());
            _ActualizarProyectoService = new ActualizarProyectoService(new UnitOfWork(_dbContext), new ProyectoRepository(_dbContext), new MailServerSpy());
            _convocatoriaService = new ConvocatoriasService(new UnitOfWork(_dbContext), new ConvocatoriaRepository(_dbContext), new MailServerSpy());
            
            _ConsultarProyectoService = new ConsultarProyectoService(new UnitOfWork(_dbContext), new ProyectoRepository(_dbContext));
        }

        [Test]
        public void CargarProyectoText()
        {
             
            //ARRANGE //PREPARAR // DADO // GIVEN
            var estudiante1 = UsuarioMother.crearUsuarioEstudiante("92345117");
            var estudiante2 = UsuarioMother.crearUsuarioEstudiante("913451118");
            var asesorTematico = UsuarioMother.crearUsuarioAsesorTematico("323456116");
            var asesorMetodologico = UsuarioMother.crearUsuarioAsesorMetodologico("456656116");

            var convocatoriaActiva = CrearConvocatoriaMother.CrearConvocatoria();
            convocatoriaActiva.ActivarCargaProyectos();
            string path = Path.GetFullPath("../../../../Anteproyecto.Infrastructure.WebApi/");
            var proyecto = ProyectoMother.CrearProyecto_();

            _dbContext.Usuarios.Add(estudiante1);
            _dbContext.Usuarios.Add(estudiante2);
            _dbContext.Usuarios.Add(asesorTematico);
            _dbContext.Usuarios.Add(asesorMetodologico);

            _dbContext.Convocatorias.Add(convocatoriaActiva);
            _dbContext.Proyectos.Add(proyecto);
             
            _dbContext.SaveChanges();

            var archivo = ProyectoMother.CrearArchivo();
            // ACT // ACCION // CUANDO // WHEN
            var request = new CargarProyectoRequest(
                proyecto.Nombre,
                proyecto.Resumen,
                proyecto.Focus,
                proyecto.Cut,
                proyecto.Line,
                archivo,
                estudiante1.NumeroIdentificacion,
                estudiante2.NumeroIdentificacion,
                asesorTematico.NumeroIdentificacion,
                asesorMetodologico.NumeroIdentificacion
            );
            var response = _proyectoService.CargarProyecto(request, path);

            //ASSERT //AFIRMACION //ENTONCES //THEN
            
            Assert.AreEqual($"Operacion Exitoza: Su proyecto {request.Nombre} ha sido cargado", response.Mensaje);

            _dbContext.Usuarios.Remove(estudiante1);
            _dbContext.Usuarios.Remove(estudiante2);
            _dbContext.Usuarios.Remove(asesorTematico);
            _dbContext.Usuarios.Remove(asesorMetodologico);

            _dbContext.Convocatorias.Remove(convocatoriaActiva);
            
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
            var asesorMetodologico = UsuarioMother.crearUsuarioAsesorMetodologico("444456118");

            var proyecto = ProyectoMother.CrearProyecto_();
            var convocatoriaActiva = CrearConvocatoriaMother.CrearConvocatoria();
            convocatoriaActiva.ActivarCargaProyectos();

            string path = Path.GetFullPath("../../../../Anteproyecto.Infrastructure.WebApi/");
            var proyecto2 = ProyectoMother.ActualizarProyecto_();

            _dbContext.Usuarios.Add(estudiante1);
            _dbContext.Usuarios.Add(estudiante2);
            _dbContext.Usuarios.Add(asesorTematico); 
            _dbContext.Usuarios.Add(asesorMetodologico);
            _dbContext.Convocatorias.Add(convocatoriaActiva);
            _dbContext.Proyectos.Add(proyecto);
            _dbContext.SaveChanges();

            var archivo = ProyectoMother.CrearArchivo();
            // ACT // ACCION // CUANDO // WHEN
            var request = new CargarProyectoRequest(
                proyecto.Nombre, proyecto.Resumen, proyecto.Focus, proyecto.Cut, proyecto.Line,
                archivo,
                estudiante1.NumeroIdentificacion,
                estudiante2.NumeroIdentificacion,
                asesorTematico.NumeroIdentificacion,
                asesorMetodologico.NumeroIdentificacion
            );
            _proyectoService.CargarProyecto(request,path);
           
            var request2 = new ActualizarProyectoRequest(
                proyecto.Id,
                proyecto2.Url_Archive
                
            );
            var response = _ActualizarProyectoService.ActualizarProyecto(request2);

            //ASSERT //AFIRMACION //ENTONCES //THEN
            Assert.AreEqual("Actualizo archivo del proyecto", response.Mensaje);

            _dbContext.Usuarios.Remove(estudiante1);
            _dbContext.Usuarios.Remove(estudiante2);
            _dbContext.Usuarios.Remove(asesorTematico);
            _dbContext.Usuarios.Remove(asesorMetodologico);
            _dbContext.Proyectos.Remove(proyecto);
          
            _dbContext.Convocatorias.Remove(convocatoriaActiva);
            _dbContext.SaveChanges();
        }
    }
}
