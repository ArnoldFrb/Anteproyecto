using Anteproyecto.Domain.Entities;
using NUnit.Framework;

namespace Anteproyecto.Domain.Test
{
    class UT_Evaluacion
    {
        [SetUp]
        public void Setup()
        {
        }

        /*
            Modificar Nombre 
            H1: Como Asesor quiero modificar el nombre de mi proyecto para actualizar la informacion de este en caso de cambios.
            Criterio de Aceptación:
            1.2 El nombre no puede estar vacio.
            Dado El estudiante tiene una proyecto cargado en el sistema 
            Id "101010"
            Nombres "Aplicativo Web Para la Gestión, seguimiento y evaluación de los anteproyectos del programa de Psicología de la Universidad Popular del Cesar"
            resumen "El aplicativo web a desarrollar tiene como objetivo ser una herramienta que permita gestionar y controlar de manera adecuada el seguimiento de los anteproyectos recibidos en la oficina de psicología en la Universidad Popular del Cesar, ubicada en la ciudad de Valledupar. Para esto se requiere que el sistema pueda"
            Cuando Ingresa un nombre vacio; Nombre ""
            Entonces El sistema presentará el mensaje. “Registro Fallido, El Dato recibido se encuantra vacio”
        */
        [Test]
        public void NoPuedeIngresarNombreVacio()
        {
            //ARRANGE //PREPARAR // DADO // GIVEN
            string nombre = "Aplicativo Web Para la Gestión";
            string comentario = "El aplicativo web a desarrollar tiene como objetivo ser una herramienta que permita gestionar y controlar de manera adecuada el seguimiento de los anteproyectos";
            var obsercion = new Evaluacion(nombre, comentario, true);
            // ACT // ACCION // CUANDO // WHEN
            var resultado = obsercion.ValidarNombre("");
            //ASSERT //AFIRMACION //ENTONCES //THEN
            Assert.AreEqual("Registro Fallido, El Dato recibido se encuantra vacio", resultado);
        }

        [Test]
        public void PuedeIngresarNombre()
        {
            //ARRANGE //PREPARAR // DADO // GIVEN
            string nombre = "Aplicativo Web Para la Gestión";
            string comentario = "El aplicativo web a desarrollar tiene como objetivo ser una herramienta que permita gestionar y controlar de manera adecuada el seguimiento de los anteproyectos";
            var obsercion = new Evaluacion(nombre, comentario, true);
            // ACT // ACCION // CUANDO // WHEN
            var resultado = obsercion.ValidarNombre("seguimiento y evaluación de los anteproyectos");
            //ASSERT //AFIRMACION //ENTONCES //THEN
            Assert.AreEqual("Registro Exitozo: seguimiento y evaluación de los anteproyectos", resultado);
        }

        [Test]
        public void NoPuedeIngresarComentarioVacio()
        {
            //ARRANGE //PREPARAR // DADO // GIVEN
            string nombre = "Aplicativo Web Para la Gestión";
            string comentario = "El aplicativo web a desarrollar tiene como objetivo ser una herramienta que permita gestionar y controlar de manera adecuada el seguimiento de los anteproyectos";
            var obsercion = new Evaluacion(nombre, comentario, true);
            // ACT // ACCION // CUANDO // WHEN
            var resultado = obsercion.ValidarComentario("");
            //ASSERT //AFIRMACION //ENTONCES //THEN
            Assert.AreEqual("Registro Fallido, El Dato recibido se encuantra vacio", resultado);
        }

        [Test]
        public void NoPuedeIngresarestadosIguales()
        {
            //ARRANGE //PREPARAR // DADO // GIVEN
            string nombre = "Aplicativo Web Para la Gestión";
            string comentario = "El aplicativo web a desarrollar tiene como objetivo ser una herramienta que permita gestionar y controlar de manera adecuada el seguimiento de los anteproyectos";
            var obsercion = new Evaluacion(nombre, comentario, true);
            // ACT // ACCION // CUANDO // WHEN
            var resultado = obsercion.Evaluar(true);
            //ASSERT //AFIRMACION //ENTONCES //THEN
            Assert.AreEqual("Registro Fallido, Este estado se encuentra registrado", resultado);
        }

        [Test]
        public void PuedeIngresarEstadosDiferentes()
        {
            //ARRANGE //PREPARAR // DADO // GIVEN
            string nombre = "Aplicativo Web Para la Gestión";
            string comentario = "El aplicativo web a desarrollar tiene como objetivo ser una herramienta que permita gestionar y controlar de manera adecuada el seguimiento de los anteproyectos";
            var obsercion = new Evaluacion(nombre, comentario, true);
            // ACT // ACCION // CUANDO // WHEN
            var resultado = obsercion.Evaluar(false);
            //ASSERT //AFIRMACION //ENTONCES //THEN
            Assert.AreEqual("Registro Exitozo, El estado a sido modificado", resultado);
        }
    }
}
