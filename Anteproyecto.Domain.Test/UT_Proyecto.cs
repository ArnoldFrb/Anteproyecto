using Anteproyecto.Domain.Entities;
using NUnit.Framework;

namespace Anteproyecto.Domain.Test
{
    class UT_Proyecto
    {
        [SetUp]
        public void Setup()
        {
        }

        /*
         Modificar Nombre 
            H1: Como Estudiante quiero modificar el nombre de mi proyecto para actualizar la informacion de este en caso de cambios.
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
            string nombre = "Aplicativo Web Para la Gestión, seguimiento y evaluación de los anteproyectos del programa de Psicología de la Universidad Popular del Cesar";
            string resumen = "El aplicativo web a desarrollar tiene como objetivo ser una herramienta que permita gestionar y controlar de manera adecuada el seguimiento de los anteproyectos recibidos en la oficina de psicología en la Universidad Popular del Cesar, ubicada en la ciudad de Valledupar. Para esto se requiere que el sistema pueda";
            var proyecto = new Proyecto(nombre, resumen);
            // ACT // ACCION // CUANDO // WHEN
            var resultado = proyecto.ValidarNombre("");
            //ASSERT //AFIRMACION //ENTONCES //THEN
            Assert.AreEqual("Registro Fallido, El Dato recibido se encuantra vacio", resultado);
        }

        /*
         Modificar Nombre 
            H1: Como Estudiante quiero modificar el nombre de mi proyecto para actualizar la informacion de este en caso de cambios.
            Criterio de Aceptación:
            1.2 El nombre no puede estar vacio.
            Dado El estudiante tiene una proyecto cargado en el sistema 
            Id "101010"
            Nombres "Aplicativo Web Para la Gestión, seguimiento y evaluación de los anteproyectos del programa de Psicología de la Universidad Popular del Cesar"
            resumen "El aplicativo web a desarrollar tiene como objetivo ser una herramienta que permita gestionar y controlar de manera adecuada el seguimiento de los anteproyectos recibidos en la oficina de psicología en la Universidad Popular del Cesar, ubicada en la ciudad de Valledupar. Para esto se requiere que el sistema pueda"
            Cuando Ingresa un nombre vacio; Nombre ""
            Entonces El sistema presentará el mensaje. “Registro Fallido, El Nombre registrado es muy pequeño”
        */
        [Test]
        public void NoPuedeIngresarNombreCortos()
        {
            //ARRANGE //PREPARAR // DADO // GIVEN
            string nombre = "Aplicativo Web Para la Gestión, seguimiento y evaluación de los anteproyectos del programa de Psicología de la Universidad Popular del Cesar";
            string resumen = "El aplicativo web a desarrollar tiene como objetivo ser una herramienta que permita gestionar y controlar de manera adecuada el seguimiento de los anteproyectos recibidos en la oficina de psicología en la Universidad Popular del Cesar, ubicada en la ciudad de Valledupar. Para esto se requiere que el sistema pueda";
            var proyecto = new Proyecto(nombre, resumen);
            // ACT // ACCION // CUANDO // WHEN
            var resultado = proyecto.ValidarNombre("evaluación de los anteproyectos");
            //ASSERT //AFIRMACION //ENTONCES //THEN
            Assert.AreEqual("Registro Fallido, El Nombre registrado es muy corto", resultado);
        }

        /*
         Modificar Nombre 
            H1: Como Estudiante quiero modificar el nombre de mi proyecto para actualizar la informacion de este en caso de cambios.
            Criterio de Aceptación:
            1.2 El nombre no puede estar vacio.
            Dado El estudiante tiene una proyecto cargado en el sistema 
            Id "101010"
            Nombres "Aplicativo Web Para la Gestión, seguimiento y evaluación de los anteproyectos del programa de Psicología de la Universidad Popular del Cesar"
            resumen "El aplicativo web a desarrollar tiene como objetivo ser una herramienta que permita gestionar y controlar de manera adecuada el seguimiento de los anteproyectos recibidos en la oficina de psicología en la Universidad Popular del Cesar, ubicada en la ciudad de Valledupar. Para esto se requiere que el sistema pueda"
            Cuando Ingresa un nombre vacio; Nombre ""
            Entonces El sistema presentará el mensaje. “Registro Exitozo, Se ha registrado el nuevo Nombre”
        */
        [Test]
        public void PuedeIngresarNombreLargo()
        {
            //ARRANGE //PREPARAR // DADO // GIVEN
            string nombre = "Aplicativo Web Para la Gestión, seguimiento y evaluación de los anteproyectos del programa de Psicología de la Universidad Popular del Cesar";
            string resumen = "El aplicativo web a desarrollar tiene como objetivo ser una herramienta que permita gestionar y controlar de manera adecuada el seguimiento de los anteproyectos recibidos en la oficina de psicología en la Universidad Popular del Cesar, ubicada en la ciudad de Valledupar. Para esto se requiere que el sistema pueda";
            var proyecto = new Proyecto(nombre, resumen);
            // ACT // ACCION // CUANDO // WHEN
            var resultado = proyecto.ValidarNombre("Aplicativo Web Para la Gestión, seguimiento y evaluación de los anteproyectos del programa de Psicología");
            //ASSERT //AFIRMACION //ENTONCES //THEN
            Assert.AreEqual("Registro Exitozo: Aplicativo Web Para la Gestión, seguimiento y evaluación de los anteproyectos del programa de Psicología", resultado);
        }

        /*
         Modificar Resumen 
            H1: Como Estudiante quiero modificar el nombre de mi proyecto para actualizar la informacion de este en caso de cambios.
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
        public void NoPuedeIngresarResumenVacio()
        {
            //ARRANGE //PREPARAR // DADO // GIVEN
            string nombre = "Aplicativo Web Para la Gestión, seguimiento y evaluación de los anteproyectos del programa de Psicología de la Universidad Popular del Cesar";
            string resumen = "El aplicativo web a desarrollar tiene como objetivo ser una herramienta que permita gestionar y controlar de manera adecuada el seguimiento de los anteproyectos recibidos en la oficina de psicología en la Universidad Popular del Cesar, ubicada en la ciudad de Valledupar. Para esto se requiere que el sistema pueda";
            var proyecto = new Proyecto(nombre, resumen);
            // ACT // ACCION // CUANDO // WHEN
            var resultado = proyecto.ValidarResumen("");
            //ASSERT //AFIRMACION //ENTONCES //THEN
            Assert.AreEqual("Registro Fallido, El Dato recibido se encuantra vacio", resultado);
        }

        /*
         Modificar Nombre 
            H1: Como Estudiante quiero modificar el nombre de mi proyecto para actualizar la informacion de este en caso de cambios.
            Criterio de Aceptación:
            1.2 El nombre no puede estar vacio.
            Dado El estudiante tiene una proyecto cargado en el sistema 
            Id "101010"
            Nombres "Aplicativo Web Para la Gestión, seguimiento y evaluación de los anteproyectos del programa de Psicología de la Universidad Popular del Cesar"
            resumen "El aplicativo web a desarrollar tiene como objetivo ser una herramienta que permita gestionar y controlar de manera adecuada el seguimiento de los anteproyectos recibidos en la oficina de psicología en la Universidad Popular del Cesar, ubicada en la ciudad de Valledupar. Para esto se requiere que el sistema pueda"
            Cuando Ingresa un nombre vacio; Nombre ""
            Entonces El sistema presentará el mensaje. “Registro Fallido, El Resumen registrado es muy pequeño”
        */
        [Test]
        public void NoPuedeIngresarResumenPequeños()
        {
            //ARRANGE //PREPARAR // DADO // GIVEN
            string nombre = "Aplicativo Web Para la Gestión, seguimiento y evaluación de los anteproyectos del programa de Psicología de la Universidad Popular del Cesar";
            string resumen = "El aplicativo web a desarrollar tiene como objetivo ser una herramienta que permita gestionar y controlar de manera adecuada el seguimiento de los anteproyectos recibidos en la oficina de psicología en la Universidad Popular del Cesar, ubicada en la ciudad de Valledupar. Para esto se requiere que el sistema pueda";
            var proyecto = new Proyecto(nombre, resumen);
            // ACT // ACCION // CUANDO // WHEN
            var resultado = proyecto.ValidarResumen("El aplicativo web a desarrollar tiene como objetivo ser una");
            //ASSERT //AFIRMACION //ENTONCES //THEN
            Assert.AreEqual("Registro Fallido, El Resumen registrado es muy corto", resultado);
        }

        /*
         Modificar Nombre 
            H1: Como Estudiante quiero modificar el nombre de mi proyecto para actualizar la informacion de este en caso de cambios.
            Criterio de Aceptación:
            1.2 El nombre no puede estar vacio.
            Dado El estudiante tiene una proyecto cargado en el sistema 
            Id "101010"
            Nombres "Aplicativo Web Para la Gestión, seguimiento y evaluación de los anteproyectos del programa de Psicología de la Universidad Popular del Cesar"
            resumen "El aplicativo web a desarrollar tiene como objetivo ser una herramienta que permita gestionar y controlar de manera adecuada el seguimiento de los anteproyectos recibidos en la oficina de psicología en la Universidad Popular del Cesar, ubicada en la ciudad de Valledupar. Para esto se requiere que el sistema pueda"
            Cuando Ingresa un nombre vacio; Nombre ""
            Entonces El sistema presentará el mensaje. “Registro Exitozo, Se ha registrado el nuevo Resumen”
        */
        [Test]
        public void PuedeIngresarResumenLargo()
        {
            //ARRANGE //PREPARAR // DADO // GIVEN
            string nombre = "Aplicativo Web Para la Gestión, seguimiento y evaluación de los anteproyectos del programa de Psicología de la Universidad Popular del Cesar";
            string resumen = "El aplicativo web a desarrollar tiene como objetivo ser una herramienta que permita gestionar y controlar de manera adecuada el seguimiento de los anteproyectos recibidos en la oficina de psicología en la Universidad Popular del Cesar, ubicada en la ciudad de Valledupar. Para esto se requiere que el sistema pueda";
            var proyecto = new Proyecto(nombre, resumen);
            // ACT // ACCION // CUANDO // WHEN
            var prueba = "El aplicativo web a desarrollar tiene como objetivo ser una herramienta que permita gestionar y controlar de manera adecuada el seguimiento de los anteproyectos recibidos en la oficina de psicología en la Universidad Popular del Cesar, ubicada en la ciudad de Valledupar. Para esto se requiere que el sistema pueda";
            var resultado = proyecto.ValidarResumen(prueba);
            //ASSERT //AFIRMACION //ENTONCES //THEN
            Assert.AreEqual("Registro Exitozo: El aplicativo web a desarrollar tiene como objetivo ser una herramienta que permita gestionar y controlar de manera adecuada el seguimiento de los anteproyectos recibidos en la oficina de psicología en la Universidad Popular del Cesar, ubicada en la ciudad de Valledupar. Para esto se requiere que el sistema pueda", resultado);
        }

        [Test]
        public void PruedeIngresarEvaluacion()
        {
            //ARRANGE //PREPARAR // DADO // GIVEN
            string nombre = "La justificacion no concuerda con el tema";
            string resumen = "El aplicativo web a desarrollar tiene como objetivo ser una herramienta que permita gestionar y controlar de manera adecuada el seguimiento de los anteproyectos recibidos en la oficina de psicología en la Universidad Popular del Cesar, ubicada en la ciudad de Valledupar. Para esto se requiere que el sistema pueda";
            var proyecto = new Proyecto(nombre, resumen);
            // ACT // ACCION // CUANDO // WHEN
            var resultado = proyecto.Evaluar(new Evaluacion(nombre, resumen, true));
            //ASSERT //AFIRMACION //ENTONCES //THEN
            Assert.AreEqual("Nueva Evaluacion: La justificacion no concuerda con el tema", resultado);
        }

        [Test]
        public void PruedeIngresarObservacion()
        {
            //ARRANGE //PREPARAR // DADO // GIVEN
            string nombre = "La justificacion no concuerda con el tema";
            string resumen = "El aplicativo web a desarrollar tiene como objetivo ser una herramienta que permita gestionar y controlar de manera adecuada el seguimiento de los anteproyectos recibidos en la oficina de psicología en la Universidad Popular del Cesar, ubicada en la ciudad de Valledupar. Para esto se requiere que el sistema pueda";
            var proyecto = new Proyecto(nombre, resumen);
            // ACT // ACCION // CUANDO // WHEN
            var resultado = proyecto.Observar(new Observacion(nombre, resumen));
            //ASSERT //AFIRMACION //ENTONCES //THEN
            Assert.AreEqual("Nueva Observacon: La justificacion no concuerda con el tema", resultado);
        }

        [Test]
        public void PruedeAsignarAsesorTematico()
        {
            //ARRANGE //PREPARAR // DADO // GIVEN
            string nombre = "La justificacion no concuerda con el tema";
            string resumen = "El aplicativo web a desarrollar tiene como objetivo ser una herramienta que permita gestionar y controlar de manera adecuada el seguimiento de los anteproyectos recibidos en la oficina de psicología en la Universidad Popular del Cesar, ubicada en la ciudad de Valledupar. Para esto se requiere que el sistema pueda";
            var proyecto = new Proyecto(nombre, resumen);
            // ACT // ACCION // CUANDO // WHEN
            var resultado = proyecto.AsignarAsesorTematico(new AsesorTematico("Lorem", "Ipsum", "123456789", "help@lipsum.com", "123455356",0,23,true));
            //ASSERT //AFIRMACION //ENTONCES //THEN
            Assert.AreEqual("Se ha asignado el Asesor Tematico Lorem", resultado);
        }

        [Test]
        public void PruedeAsignarAsesorMetodologico()
        {
            //ARRANGE //PREPARAR // DADO // GIVEN
            string nombre = "La justificacion no concuerda con el tema";
            string resumen = "El aplicativo web a desarrollar tiene como objetivo ser una herramienta que permita gestionar y controlar de manera adecuada el seguimiento de los anteproyectos recibidos en la oficina de psicología en la Universidad Popular del Cesar, ubicada en la ciudad de Valledupar. Para esto se requiere que el sistema pueda";
            var proyecto = new Proyecto(nombre, resumen);
            // ACT // ACCION // CUANDO // WHEN
            var resultado = proyecto.AsignarAsesorMetodologico(new AsesorMetodologico("Lorem", "Ipsum", "123456789", "help@lipsum.com", "123455356",0,23,true));
            //ASSERT //AFIRMACION //ENTONCES //THEN
            Assert.AreEqual("Se ha asignado el Asesor Metodologico Lorem", resultado);
        }
    }
}
