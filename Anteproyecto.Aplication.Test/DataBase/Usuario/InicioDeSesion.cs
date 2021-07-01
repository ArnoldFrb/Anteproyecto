using Anteproyecto.Aplication.UsuarioService;
using Anteproyecto.Aplication.Test.Dobles;
using Anteproyecto.Infrastructure.Data.ObjectMother;
using Infrastructure.Data;
using Infrastructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using static Anteproyecto.Aplication.UsuarioService.InicioDeSesionService;

namespace Anteproyecto.Aplication.Test.DataBase.Usuario
{
    public class InicioDeSesion
    {
        private ProyectoContext _dbContext;
        private InicioDeSesionService _inicioDeSesionService;

        [SetUp]
        public void Setup()
        {
            var optionsSqlite = new DbContextOptionsBuilder<ProyectoContext>()
           .UseSqlite(@"Data Source=C:\\BD\\AnteProyecto.db")
           .Options;

            _dbContext = new ProyectoContext(optionsSqlite);
            _dbContext.Database.EnsureDeleted();
            _dbContext.Database.EnsureCreated();

            _inicioDeSesionService = new InicioDeSesionService(new UnitOfWork(_dbContext), new UsuarioRepository(_dbContext), new MailServerSpy());
        }

        [Test]
        public void IniciarSesionConCorreoIncorrecto()
        {
            //ARRANGE //PREPARAR // DADO // GIVEN
            var estudiante = UsuarioMother.crearUsuarioEstudiante("123456678");

            _dbContext.Usuarios.Add(estudiante);
            _dbContext.SaveChanges();

            // ACT // ACCION // CUANDO // WHEN
            var request = new InicioDeSesionRequest(
                "H" + estudiante.Correo,
                estudiante.Contraseña
            );
            var response = _inicioDeSesionService.IniciosDeSesion(request);

            //ASSERT //AFIRMACION //ENTONCES //THEN
            Assert.AreEqual($"El correo {request.Correo} no fue encontrado", response.Message);

            _dbContext.Usuarios.Remove(estudiante);
            _dbContext.SaveChanges();
        }

        [Test]
        public void IniciarSesionConContraseñaIncorrecta()
        {

            //ARRANGE //PREPARAR // DADO // GIVEN
            var estudiante = UsuarioMother.crearUsuarioEstudiante("123456678");

            _dbContext.Usuarios.Add(estudiante);
            _dbContext.SaveChanges();

            // ACT // ACCION // CUANDO // WHEN
            var request = new InicioDeSesionRequest(
                estudiante.Correo,
                "H" + estudiante.Contraseña
            );
            var response = _inicioDeSesionService.IniciosDeSesion(request);

            //ASSERT //AFIRMACION //ENTONCES //THEN
            Assert.AreEqual($"Contrasena Incorrecta.", response.Message);

            _dbContext.Usuarios.Remove(estudiante);
            _dbContext.SaveChanges();
        }

        [Test]
        public void IniciarSesionExitoso()
        {

            //ARRANGE //PREPARAR // DADO // GIVEN
            var estudiante = UsuarioMother.crearUsuarioEstudiante("123456678");

            _dbContext.Usuarios.Add(estudiante);
            _dbContext.SaveChanges();

            // ACT // ACCION // CUANDO // WHEN
            var request = new InicioDeSesionRequest(
                estudiante.Correo,
                estudiante.Contraseña
            );
            var response = _inicioDeSesionService.IniciosDeSesion(request);

            //ASSERT //AFIRMACION //ENTONCES //THEN
            Assert.AreEqual("Inicio de Seción existoso.", response.Message);

            _dbContext.Usuarios.Remove(estudiante);
            _dbContext.SaveChanges();
        }
    }
}
