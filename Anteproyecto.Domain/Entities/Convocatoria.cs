using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anteproyecto.Domain.Entities
{
    public class Convocatoria : Entity<int>
    {
        public DateTime FechaInicio { get; private set; }
        public DateTime FechaCierre { get; private set; }
        public bool CargarProyectos { get; private set; }

        public Convocatoria(DateTime fechaInicio, DateTime fechaCierre)
        {
            FechaInicio = fechaInicio;
            FechaCierre = fechaCierre;
            CargarProyectos = false;
        }

        public string ModificarConvocatoria(DateTime fechaInicio, DateTime fechaCierre)
        {
            if (fechaInicio < fechaCierre)
            {
                FechaInicio = fechaInicio;
                FechaCierre = fechaCierre;
                return "Fechas modificadas correctamente";
            }
            return "Error: fecha de inicio mayor a fecha de cierre";
        }

        public string ActivarCargaProyectos()
        {
            if (FechaInicio > DateTime.Now)
            {
                CargarProyectos = true;
                return "Carga de proyectos activada";
            }
            return "Error: Las fechas de inicio no concuerda con la fecha actual";
        }

        public string DesactivarCargaProyectos()
        {
            CargarProyectos = false;
            return "Carga de proyectos desactivada";
        }
    }
}
