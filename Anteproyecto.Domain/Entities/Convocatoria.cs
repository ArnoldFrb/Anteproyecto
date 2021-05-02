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
            CargarProyectos = true;
            return "Carga de proyectos activada";
        }

        public string DesactivarCargaProyectos()
        {
            if (PuedeActivarCargaProyectos().Any())
            {
                throw new ConvocatoriaActivacionDeCargaException("No es posible realizar el Retiro, Supera el tope mínimo permitido de retiro");
            }
            CargarProyectos = false;
            return "Carga de proyectos desactivada";
        }

        public List<string> PuedeActivarCargaProyectos()
        {
            List<string> errors = new List<string>();
            if (FechaInicio > DateTime.Now)
            {
                errors.Add("Error: Las fechas de inicio no concuerda con la fecha actual");
            }
            return errors;
        }

        [Serializable]
        public class ConvocatoriaActivacionDeCargaException : Exception
        {
            public ConvocatoriaActivacionDeCargaException() { }
            public ConvocatoriaActivacionDeCargaException(string message) : base(message) { }
            public ConvocatoriaActivacionDeCargaException(string message, Exception inner) : base(message, inner) { }
            protected ConvocatoriaActivacionDeCargaException(
              System.Runtime.Serialization.SerializationInfo info,
              System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
        }
    }
}
