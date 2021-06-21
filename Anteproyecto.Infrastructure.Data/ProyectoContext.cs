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
        }

    }
}
