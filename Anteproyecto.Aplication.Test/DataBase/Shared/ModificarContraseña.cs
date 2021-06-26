using Anteproyecto.Aplication.SharedService;
using Anteproyecto.Aplication.Test.Dobles;
using Anteproyecto.Infrastructure.Data.ObjectMother;
using Infrastructure.Data;
using Infrastructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using static Anteproyecto.Aplication.SharedService.ModificarContraseñaService;

namespace Anteproyecto.Aplication.Test.DataBase.Shared
{
    class ModificarContraseña
    {
        private ProyectoContext _dbContext;
        private ModificarContraseñaService _inicioDeSesionService;

        [SetUp]
        public void Setup()
        {
            var optionsSqlite = new DbContextOptionsBuilder<ProyectoContext>()
           .UseSqlite(@"Data Source=C:\\BD\\AnteProyecto.db")
           .Options;

            _dbContext = new ProyectoContext(optionsSqlite);
            _dbContext.Database.EnsureDeleted();
            _dbContext.Database.EnsureCreated();

            _inicioDeSesionService = new ModificarContraseñaService(new UnitOfWork(_dbContext), new UsuarioRepository(_dbContext), new MailServerSpy());
        }

        /// <summary>
        /// PRUEBAS PARA USUARIO ESTUDIANTE
        /// </summary>
        [Test]
        public void ESTUDIANTE_MoficarContraseConContraseñaIgualALaAnterior()
        {

            //ARRANGE //PREPARAR // DADO // GIVEN
            var estudiante = UsuarioMother.crearUsuarioEstudiante("123456678");

            _dbContext.Usuarios.Add(estudiante);
            _dbContext.SaveChanges();

            // ACT // ACCION // CUANDO // WHEN
            var request = new ModificarContraseñaRequest(
                estudiante.Id,
                estudiante.Contraseña
            );
            var response = _inicioDeSesionService.ModificarContraseña(request);

            //ASSERT //AFIRMACION //ENTONCES //THEN
            Assert.AreEqual("No puede ingresar una contraseña igual a la registrada, pruebe de nuevo", response.Mensaje);

            _dbContext.Usuarios.Remove(estudiante);
            _dbContext.SaveChanges();
        }

        [Test]
        public void ESTUDIANTE_MoficarContraseConContraseñaDiferenteALaAnterior()
        {

            //ARRANGE //PREPARAR // DADO // GIVEN
            var estudiante = UsuarioMother.crearUsuarioEstudiante("123456678");

            _dbContext.Usuarios.Add(estudiante);
            _dbContext.SaveChanges();

            // ACT // ACCION // CUANDO // WHEN
            var request = new ModificarContraseñaRequest(
                estudiante.Id,
                "54bfd5654r"
            );
            var response = _inicioDeSesionService.ModificarContraseña(request);

            //ASSERT //AFIRMACION //ENTONCES //THEN
            Assert.AreEqual("Su nueva contraseña es correcta", response.Mensaje);

            _dbContext.Usuarios.Remove(estudiante);
            _dbContext.SaveChanges();
        }

        [Test]
        public void ESTUDIANTE_MoficarContraseConContraseñaMenora10Caracteres()
        {

            //ARRANGE //PREPARAR // DADO // GIVEN
            var estudiante = UsuarioMother.crearUsuarioEstudiante("123456678");

            _dbContext.Usuarios.Add(estudiante);
            _dbContext.SaveChanges();

            // ACT // ACCION // CUANDO // WHEN
            var request = new ModificarContraseñaRequest(
                estudiante.Id,
                "54bfd5654"
            );
            var response = _inicioDeSesionService.ModificarContraseña(request);

            //ASSERT //AFIRMACION //ENTONCES //THEN
            Assert.AreEqual("Su nueva contraseña es muy corta, pruebe de nuevo", response.Mensaje);

            _dbContext.Usuarios.Remove(estudiante);
            _dbContext.SaveChanges();
        }

        [Test]
        public void ESTUDIANTE_NoSeEncontroElUsuario()
        {

            //ARRANGE //PREPARAR // DADO // GIVEN
            var estudiante = UsuarioMother.crearUsuarioEstudiante("123456678");

            _dbContext.Usuarios.Add(estudiante);
            _dbContext.SaveChanges();

            // ACT // ACCION // CUANDO // WHEN
            var request = new ModificarContraseñaRequest(
                estudiante.Id + 1,
                estudiante.Contraseña
            );
            var response = _inicioDeSesionService.ModificarContraseña(request);

            //ASSERT //AFIRMACION //ENTONCES //THEN
            Assert.AreEqual("El Usuario no existe.", response.Mensaje);

            _dbContext.Usuarios.Remove(estudiante);
            _dbContext.SaveChanges();
        }

        /// <summary>
        /// PRUEBAS PARA USUARIO A. METODOLOGICO
        /// </summary>
        [Test]
        public void AMETODOLOGICO_MoficarContraseConContraseñaIgualALaAnterior()
        {

            //ARRANGE //PREPARAR // DADO // GIVEN
            var estudiante = UsuarioMother.crearUsuarioAsesorMetodologico("123456678");

            _dbContext.Usuarios.Add(estudiante);
            _dbContext.SaveChanges();

            // ACT // ACCION // CUANDO // WHEN
            var request = new ModificarContraseñaRequest(
                estudiante.Id,
                estudiante.Contraseña
            );
            var response = _inicioDeSesionService.ModificarContraseña(request);

            //ASSERT //AFIRMACION //ENTONCES //THEN
            Assert.AreEqual("No puede ingresar una contraseña igual a la registrada, pruebe de nuevo", response.Mensaje);

            _dbContext.Usuarios.Remove(estudiante);
            _dbContext.SaveChanges();
        }

        [Test]
        public void AMETODOLOGICO_MoficarContraseConContraseñaDiferenteALaAnterior()
        {

            //ARRANGE //PREPARAR // DADO // GIVEN
            var estudiante = UsuarioMother.crearUsuarioAsesorMetodologico("123456678");

            _dbContext.Usuarios.Add(estudiante);
            _dbContext.SaveChanges();

            // ACT // ACCION // CUANDO // WHEN
            var request = new ModificarContraseñaRequest(
                estudiante.Id,
                "54bfd5654r"
            );
            var response = _inicioDeSesionService.ModificarContraseña(request);

            //ASSERT //AFIRMACION //ENTONCES //THEN
            Assert.AreEqual("Su nueva contraseña es correcta", response.Mensaje);

            _dbContext.Usuarios.Remove(estudiante);
            _dbContext.SaveChanges();
        }

        [Test]
        public void AMETODOLOGICO_MoficarContraseConContraseñaMenora10Caracteres()
        {

            //ARRANGE //PREPARAR // DADO // GIVEN
            var estudiante = UsuarioMother.crearUsuarioAsesorMetodologico("123456678");

            _dbContext.Usuarios.Add(estudiante);
            _dbContext.SaveChanges();

            // ACT // ACCION // CUANDO // WHEN
            var request = new ModificarContraseñaRequest(
                estudiante.Id,
                "54bfd5654"
            );
            var response = _inicioDeSesionService.ModificarContraseña(request);

            //ASSERT //AFIRMACION //ENTONCES //THEN
            Assert.AreEqual("Su nueva contraseña es muy corta, pruebe de nuevo", response.Mensaje);

            _dbContext.Usuarios.Remove(estudiante);
            _dbContext.SaveChanges();
        }

        [Test]
        public void AMETODOLOGICO_NoSeEncontroElUsuario()
        {

            //ARRANGE //PREPARAR // DADO // GIVEN
            var estudiante = UsuarioMother.crearUsuarioAsesorMetodologico("123456678");

            _dbContext.Usuarios.Add(estudiante);
            _dbContext.SaveChanges();

            // ACT // ACCION // CUANDO // WHEN
            var request = new ModificarContraseñaRequest(
                estudiante.Id + 1,
                estudiante.Contraseña
            );
            var response = _inicioDeSesionService.ModificarContraseña(request);

            //ASSERT //AFIRMACION //ENTONCES //THEN
            Assert.AreEqual("El Usuario no existe.", response.Mensaje);

            _dbContext.Usuarios.Remove(estudiante);
            _dbContext.SaveChanges();
        }

        /// <summary>
        /// PRUEBAS PARA USUARIO A. TEMATICO
        /// </summary>
        [Test]
        public void ATEMATICO_MoficarContraseConContraseñaIgualALaAnterior()
        {

            //ARRANGE //PREPARAR // DADO // GIVEN
            var estudiante = UsuarioMother.crearUsuarioAsesorTematico("123456678");

            _dbContext.Usuarios.Add(estudiante);
            _dbContext.SaveChanges();

            // ACT // ACCION // CUANDO // WHEN
            var request = new ModificarContraseñaRequest(
                estudiante.Id,
                estudiante.Contraseña
            );
            var response = _inicioDeSesionService.ModificarContraseña(request);

            //ASSERT //AFIRMACION //ENTONCES //THEN
            Assert.AreEqual("No puede ingresar una contraseña igual a la registrada, pruebe de nuevo", response.Mensaje);

            _dbContext.Usuarios.Remove(estudiante);
            _dbContext.SaveChanges();
        }

        [Test]
        public void ATEMATICO_MoficarContraseConContraseñaDiferenteALaAnterior()
        {

            //ARRANGE //PREPARAR // DADO // GIVEN
            var estudiante = UsuarioMother.crearUsuarioAsesorTematico("123456678");

            _dbContext.Usuarios.Add(estudiante);
            _dbContext.SaveChanges();

            // ACT // ACCION // CUANDO // WHEN
            var request = new ModificarContraseñaRequest(
                estudiante.Id,
                "54bfd5654r"
            );
            var response = _inicioDeSesionService.ModificarContraseña(request);

            //ASSERT //AFIRMACION //ENTONCES //THEN
            Assert.AreEqual("Su nueva contraseña es correcta", response.Mensaje);

            _dbContext.Usuarios.Remove(estudiante);
            _dbContext.SaveChanges();
        }

        [Test]
        public void ATEMATICO_MoficarContraseConContraseñaMenora10Caracteres()
        {

            //ARRANGE //PREPARAR // DADO // GIVEN
            var estudiante = UsuarioMother.crearUsuarioAsesorTematico("123456678");

            _dbContext.Usuarios.Add(estudiante);
            _dbContext.SaveChanges();

            // ACT // ACCION // CUANDO // WHEN
            var request = new ModificarContraseñaRequest(
                estudiante.Id,
                "54bfd5654"
            );
            var response = _inicioDeSesionService.ModificarContraseña(request);

            //ASSERT //AFIRMACION //ENTONCES //THEN
            Assert.AreEqual("Su nueva contraseña es muy corta, pruebe de nuevo", response.Mensaje);

            _dbContext.Usuarios.Remove(estudiante);
            _dbContext.SaveChanges();
        }

        [Test]
        public void ATEMATICO_NoSeEncontroElUsuario()
        {

            //ARRANGE //PREPARAR // DADO // GIVEN
            var estudiante = UsuarioMother.crearUsuarioAsesorTematico("123456678");

            _dbContext.Usuarios.Add(estudiante);
            _dbContext.SaveChanges();

            // ACT // ACCION // CUANDO // WHEN
            var request = new ModificarContraseñaRequest(
                estudiante.Id + 1,
                estudiante.Contraseña
            );
            var response = _inicioDeSesionService.ModificarContraseña(request);

            //ASSERT //AFIRMACION //ENTONCES //THEN
            Assert.AreEqual("El Usuario no existe.", response.Mensaje);

            _dbContext.Usuarios.Remove(estudiante);
            _dbContext.SaveChanges();
        }

        /// <summary>
        /// PRUEBAS PARA USUARIO MIEMBRODELCOMITE
        /// </summary>
        [Test]
        public void MIEMBRODELCOMITE_MoficarContraseConContraseñaIgualALaAnterior()
        {

            //ARRANGE //PREPARAR // DADO // GIVEN
            var estudiante = UsuarioMother.crearUsuarioMiembroComite("123456678");

            _dbContext.Usuarios.Add(estudiante);
            _dbContext.SaveChanges();

            // ACT // ACCION // CUANDO // WHEN
            var request = new ModificarContraseñaRequest(
                estudiante.Id,
                estudiante.Contraseña
            );
            var response = _inicioDeSesionService.ModificarContraseña(request);

            //ASSERT //AFIRMACION //ENTONCES //THEN
            Assert.AreEqual("No puede ingresar una contraseña igual a la registrada, pruebe de nuevo", response.Mensaje);

            _dbContext.Usuarios.Remove(estudiante);
            _dbContext.SaveChanges();
        }

        [Test]
        public void MIEMBRODELCOMITE_MoficarContraseConContraseñaDiferenteALaAnterior()
        {

            //ARRANGE //PREPARAR // DADO // GIVEN
            var estudiante = UsuarioMother.crearUsuarioMiembroComite("123456678");

            _dbContext.Usuarios.Add(estudiante);
            _dbContext.SaveChanges();

            // ACT // ACCION // CUANDO // WHEN
            var request = new ModificarContraseñaRequest(
                estudiante.Id,
                "54bfd5654r"
            );
            var response = _inicioDeSesionService.ModificarContraseña(request);

            //ASSERT //AFIRMACION //ENTONCES //THEN
            Assert.AreEqual("Su nueva contraseña es correcta", response.Mensaje);

            _dbContext.Usuarios.Remove(estudiante);
            _dbContext.SaveChanges();
        }

        [Test]
        public void MIEMBRODELCOMITE_MoficarContraseConContraseñaMenora10Caracteres()
        {

            //ARRANGE //PREPARAR // DADO // GIVEN
            var estudiante = UsuarioMother.crearUsuarioMiembroComite("123456678");

            _dbContext.Usuarios.Add(estudiante);
            _dbContext.SaveChanges();

            // ACT // ACCION // CUANDO // WHEN
            var request = new ModificarContraseñaRequest(
                estudiante.Id,
                "54bfd5654"
            );
            var response = _inicioDeSesionService.ModificarContraseña(request);

            //ASSERT //AFIRMACION //ENTONCES //THEN
            Assert.AreEqual("Su nueva contraseña es muy corta, pruebe de nuevo", response.Mensaje);

            _dbContext.Usuarios.Remove(estudiante);
            _dbContext.SaveChanges();
        }

        [Test]
        public void MIEMBRODELCOMITE_NoSeEncontroElUsuario()
        {

            //ARRANGE //PREPARAR // DADO // GIVEN
            var estudiante = UsuarioMother.crearUsuarioMiembroComite("123456678");

            _dbContext.Usuarios.Add(estudiante);
            _dbContext.SaveChanges();

            // ACT // ACCION // CUANDO // WHEN
            var request = new ModificarContraseñaRequest(
                estudiante.Id + 1,
                estudiante.Contraseña
            );
            var response = _inicioDeSesionService.ModificarContraseña(request);

            //ASSERT //AFIRMACION //ENTONCES //THEN
            Assert.AreEqual("El Usuario no existe.", response.Mensaje);

            _dbContext.Usuarios.Remove(estudiante);
            _dbContext.SaveChanges();
        }
    }
}
