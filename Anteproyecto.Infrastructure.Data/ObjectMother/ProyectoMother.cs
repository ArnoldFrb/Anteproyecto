using Anteproyecto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anteproyecto.Infrastructure.Data.ObjectMother
{
    public static class ProyectoMother
    {
        public static Proyecto CrearProyecto()
        {
            return new Proyecto(
                "Aplicativo Web Para la Gestión, seguimiento y evaluación de los anteproyectos del programa de Psicología de la Universidad Popular del Cesar",
                "El aplicativo web a desarrollar tiene como objetivo ser una herramienta que permita gestionar y controlar de manera adecuada el seguimiento de los anteproyectos recibidos en la oficina de psicología en la Universidad Popular del Cesar, ubicada en la ciudad de Valledupar. Para esto se requiere que el sistema pueda"
                );
        }

        public static Proyecto CrearProyecto2()
        {
            return new Proyecto(
                "Aplicativo Web Para la Gestión, seguimiento y evaluación de los anteproyectos del programa de Psicología de la Universidad Popular del Cesar",
                "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum."
                );
        }

        public static Proyecto CrearProyecto_()
        {
            var list = new List<Observacion>();

            list.Add(new Observacion("What is Lorem Ipsum?", "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum."));

            var estudiante1 =  UsuarioMother.crearUsuarioEstudiante("122233233");
            var estudiante2 =  UsuarioMother.crearUsuarioEstudiante("122233211");

            var asesormetodologico =  UsuarioMother.crearUsuarioAsesorMetodologico("222233244");
            var asesortematico =  UsuarioMother.crearUsuarioAsesorTematico("222233111");

            return new Proyecto("Aaplicativo","resumenn","archivo/fef","focuss", 1 ,"lineaaa",DateTime.Now, 1,asesortematico, asesormetodologico);
          

            //return new Proyecto(
            //    "Aplicativo Web Para la Gestión, seguimiento y evaluación de los anteproyectos del programa de Psicología de la Universidad Popular del Cesar",
            //    "El aplicativo web a desarrollar tiene como objetivo ser una herramienta que permita gestionar y controlar de manera adecuada el seguimiento de los anteproyectos recibidos en la oficina de psicología en la Universidad Popular del Cesar, ubicada en la ciudad de Valledupar. Para esto se requiere que el sistema pueda",
            //    list,
            //    new Evaluacion("What is Lorem Ipsum?", "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", true),
            //    new AsesorTematico("Lorem", "Ipsum", "123456789", "help@lipsum.com", "123455356",0, 34, true),
            //    new AsesorMetodologico("Lorem", "Ipsum", "123456789", "help@lipsum.com", "123455356",0, 32, true)
            //);
        }

    }
}
