using System;
using System.Collections.Generic;
using System.Text;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Data.Base;
using Anteproyecto.Infrastructure.Data.Base;
using Anteproyecto.Domain.Entities;

namespace Infrastructure.Data
{
    public class ProyectoContext : DbContextBase
    {

        public ProyectoContext() : base()
        {
        }
        public ProyectoContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Convocatoria> Convocatorias { get; set; }
        public DbSet<Proyecto> Proyectos { get; set; }
        public DbSet<Observacion> Observacion { get; set; }
        public DbSet<Evaluacion> Evaluacion { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>().HasKey(c => c.Id);
            modelBuilder.Entity<Proyecto>().HasKey(c => c.Id);
            modelBuilder.Entity<Convocatoria>().HasKey(c => c.Id);
            modelBuilder.Entity<Observacion>().HasKey(c => c.Id);
            modelBuilder.Entity<Evaluacion>().HasKey(c => c.Id);

            base.OnModelCreating(modelBuilder);
            SemillasUsuario(modelBuilder);
            SemillasProyecto(modelBuilder);
            SemillasObservacion(modelBuilder);
            SemillasEvaluacion(modelBuilder);
        }


        protected void SemillasUsuario(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Estudiante>().HasData(
                    new { Id = 1, Nombres = "Jose Carlo", Apellidos = "Santander Pimienta", NumeroIdentificacion = "1222222212", Correo = "hola@gmail.com", Contraseña = "123344444", Semestre = 9, Edad = 23, Estado = false},
                    new { Id = 2, Nombres = "Andres alejandro", Apellidos = "espinosa Pimienta", NumeroIdentificacion = "1222222231", Correo = "hola@gmail.com", Contraseña = "123344444", Semestre = 9, Edad = 23, Estado = false},
                    new { Id = 3, Nombres = "Pedro pepi", Apellidos = "romulo salamandra", NumeroIdentificacion = "1222222246", Correo = "hola@gmail.com", Contraseña = "123344444", Semestre = 9, Edad = 23, Estado = true },
                    new { Id = 4, Nombres = "rodoldo pepi", Apellidos = "papeleta Piña", NumeroIdentificacion = "3556222246", Correo = "hola@gmail.com", Contraseña = "123344444", Semestre = 9, Edad = 23, Estado = true },
                    new { Id = 5, Nombres = "san francisco", Apellidos = "pepe de la hoz", NumeroIdentificacion = "2346222246", Correo = "hola@gmail.com", Contraseña = "123344444", Semestre = 9, Edad = 23, Estado = true }
           );


            modelBuilder.Entity<MiembroComite>().HasData(
                   new { Id = 6, Nombres = "Santiago ramirez", Apellidos = "Santander Pimienta", NumeroIdentificacion = "2222233233", Correo = "hola@gmail.com", Contraseña = "123344444", Semestre = 9, Edad = 23, Estado = true },
                   new { Id = 7, Nombres = "ivan lopez", Apellidos = "Santander Pimienta", NumeroIdentificacion = "2222233222", Correo = "hola@gmail.com", Contraseña = "123344444", Semestre = 9, Edad = 23, Estado = true },
                   new { Id = 8, Nombres = "felipe domingo", Apellidos = "Santander Pimienta", NumeroIdentificacion = "2222233345", Correo = "hola@gmail.com", Contraseña = "123344444", Semestre = 9, Edad = 23, Estado = true }
          );

            modelBuilder.Entity<AsesorMetodologico>().HasData(
              new { Id = 9, Nombres = "Santiago ramirez", Apellidos = "Santander Pimienta", NumeroIdentificacion = "3222233299", Correo = "hola@gmail.com", Contraseña = "123344444", Semestre = 9, Edad = 23, Estado = false },
              new { Id = 10, Nombres = "ivan lopez", Apellidos = "Santander Pimienta", NumeroIdentificacion = "3222233200", Correo = "hola@gmail.com", Contraseña = "123344444", Semestre = 9, Edad = 23, Estado = true },
              new { Id = 11, Nombres = "felipe domingo", Apellidos = "Santander Pimienta", NumeroIdentificacion = "3222233012", Correo = "hola@gmail.com", Contraseña = "123344444", Semestre = 9, Edad = 23, Estado = true }

                );

            modelBuilder.Entity<AsesorTematico>().HasData(
            new { Id = 12, Nombres = "Santiago ramirez", Apellidos = "Santander Pimienta", NumeroIdentificacion = "5222232229", Correo = "hola@gmail.com", Contraseña = "123344444", Semestre = 9, Edad = 23, Estado = false},
            new { Id = 13, Nombres = "ivan lopez", Apellidos = "Santander Pimienta", NumeroIdentificacion = "5222221200", Correo = "hola@gmail.com", Contraseña = "123344444", Semestre = 9, Edad = 23, Estado = true },
            new { Id = 14, Nombres = "felipe domingo", Apellidos = "Santander Pimienta", NumeroIdentificacion = "5211233012", Correo = "hola@gmail.com", Contraseña = "123344444", Semestre = 9, Edad = 23, Estado = true }
              );
        }

        protected void SemillasProyecto(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Proyecto>().HasData(
                new { Id = 1, Nombre = "El proyecto de ley", Resumen = "resumen del proyecto", Url_Archive = "arriba/pero" , Focus= "arriva", Cut =2, Line= "investigacion" ,Date = DateTime.Now, State = 1 , AsesorTematicoId = 12, AsesorMetodologicoId = 9, estudiante1Id = 1 , estudiante2Id = 2 }
             );
        }

        protected void SemillasObservacion(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Observacion>().HasData(
                new { Id = 1, Nombre = "Correccion de objetivos", Comentario = "holaa mudnooo aqui", ProyectoId = 1 , Date = DateTime.Now }
             );
        }

        protected void SemillasEvaluacion(ModelBuilder modelBuilder)
        { 
            modelBuilder.Entity<Evaluacion>().HasData(
                new { Id = 1, Nombre = "Correccion de objetivos", Comentario = "holaa mudnooo aqui",Estado = true, ProyectoId = 1, Date = DateTime.Today }
             );
        }

    }

}
