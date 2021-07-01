using Anteproyecto.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anteproyecto.Domain.Entities
{
    public class Convocatoria : Entity<int>, IAggregateRoot
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

        public string CrearConvocatoria(DateTime fechaInicio, DateTime fechaCierre, bool cargarProyectos)
        {
            if (fechaInicio < fechaCierre)
            {
                FechaInicio = fechaInicio;
                FechaCierre = fechaCierre;
                CargarProyectos = cargarProyectos;
                return $"Se ha creado la convocatoria para las fechas: Inicio: {FechaInicio} / Cierre: {FechaCierre}";
            }
            return $"Error: fecha de inicio {FechaInicio} mayor a fecha de cierre {FechaCierre}";
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
            if (CargarProyectos == true)
            {
                return "La Carga de proyecto ya esta activada.";
            }
            if (FechaInicio < DateTime.Now)
            {
                CargarProyectos = true;
                return "Carga de proyectos activada.";
            }
            return "Error: No se pudo activar la carga de proyectos.";
        }

        public string DesactivarCargaProyectos()
        {
            if (CargarProyectos == false)
            {
                return "La Carga de proyecto ya esta desactivada.";
            }
            CargarProyectos = false;
            return "Carga de proyectos desactivada.";
        }
    }
}
