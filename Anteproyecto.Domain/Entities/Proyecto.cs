using Anteproyecto.Domain.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Anteproyecto.Domain
{
    public class Proyecto : Entity<int>, IAggregateRoot
    {
        public string Nombre  { get; private set; }
        public string Resumen { get; private set; }

        private List<Obsercion> Obsercion;
        private Evaluacion Evaluacion;
        private AsesorTematico AsesorTematico;
        private AsesorMetodologico AsesorMetodologico;

        public Proyecto(string nombre, string resumen)
        {
            Nombre = nombre;
            Resumen = resumen;
        }

        public string ValidarNombre(string nombre)
        {
            if (nombre.Length == 0)
            {
                return "Registro Fallido, El Dato recibido se encuantra vacio";
            }
            if (nombre.Length > 0 && nombre.Length < 100)
            {
                return "Registro Fallido, El Nombre registrado es muy corto";
            }
            if (nombre.Length >= 100)
            {
                Nombre = nombre;
                return "Registro Exitozo, Se ha registrado el nuevo Nombre";
            }
            throw new NotImplementedException();
        }

        public string ValidarResumen(string resumen)
        {
            if (resumen.Length == 0)
            {
                return "Registro Fallido, El Dato recibido se encuantra vacio";
            }
            if (resumen.Length > 0 && resumen.Length < 300)
            {
                return "Registro Fallido, El Resumen registrado es muy corto";
            }
            if (resumen.Length >= 300)
            {
                Nombre = resumen;
                return "Registro Exitozo, Se ha registrado el nuevo Resumen";
            }
            throw new NotImplementedException();
        }

        public string Observar(List<Obsercion> obsercion)
        {
            Obsercion = obsercion;
            return "Nueva Observacon";
        }

        public string Evaluar(Evaluacion evaluacion)
        {
            Evaluacion = evaluacion;
            return "Nueva Evaluacion";
        }

        public string AsignarAsesorTematico()
        {
            throw new NotImplementedException();
        }

        public string AsignarAsesorMetodologico()
        {
            throw new NotImplementedException();
        }
    }
}
