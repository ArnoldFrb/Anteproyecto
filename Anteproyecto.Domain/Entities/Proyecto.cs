﻿using Anteproyecto.Domain.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Anteproyecto.Domain.Entities
{
    public class Proyecto : Entity<int>, IAggregateRoot
    {

        public string Nombre  { get; private set; }
        public string Resumen { get; private set; }
        public string Url_Archive { get; set; }
        public string Focus { get; set; }
        public int Cut { get; set; }
        public string Line { get; set; }
        public DateTime Date { get; set; }
        public int State { get; set; }
        public AsesorTematico AsesorTematico { get; private set; }
        public AsesorMetodologico AsesorMetodologico { get; private set; }
        public Estudiante estudiante1 { get; private set; }
        public Estudiante estudiante2 { get; private set; }

        public Proyecto(string nombre, string resumen)
        {
            Nombre = nombre;
            Resumen = resumen;
        }

        public Proyecto(string nombre, string resumen, string url_Archive, string focus, int cut, string line, DateTime date, int state, AsesorTematico asesorTematico, AsesorMetodologico asesorMetodologico, Estudiante estudiante1, Estudiante estudiante2) : this(nombre, resumen)
        {
            Url_Archive = url_Archive;
            Focus = focus;
            Cut = cut;
            Line = line;
            Date = date;
            State = state;
            AsesorTematico = asesorTematico;
            AsesorMetodologico = asesorMetodologico;
            this.estudiante1 = estudiante1;
            this.estudiante2 = estudiante2;
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
                return $"Registro Exitozo: {Nombre}";
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
                Resumen = resumen;
                return $"Registro Exitozo: {Resumen}";
            }
            throw new NotImplementedException();
        }

        //public string AgregarObservar(List<Observacion> obsercion)
        //{
        //    Obsercion = obsercion;
        //    return $"Se han agregado las op";
        //}

        //public string Observar(Observacion obsercion)
        //{
        //    Obsercion.Add(obsercion);
        //    return $"Nueva Observacon: {obsercion.Nombre}";
        //}

        //public string Evaluar(Evaluacion evaluacion)
        //{
        //    Evaluacion = evaluacion;
        //    return $"Nueva Evaluacion: {Evaluacion.Nombre}";
        //}

        public string AsignarAsesorTematico(AsesorTematico asesorTematico)
        {
            AsesorTematico = asesorTematico;
            return $"Se ha asignado el Asesor Tematico {AsesorTematico.Nombres}";
        }

        public string AsignarAsesorMetodologico(AsesorMetodologico asesorMetodologico)
        {
            AsesorMetodologico = asesorMetodologico;
            return $"Se ha asignado el Asesor Metodologico {AsesorMetodologico.Nombres}";
        }
    }
}
