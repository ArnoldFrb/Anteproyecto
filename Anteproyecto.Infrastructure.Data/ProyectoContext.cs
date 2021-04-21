using System;
using System.Collections.Generic;
using System.Text;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Anteproyecto.Domain;
using Infrastructure.Data.Base;
using Anteproyecto.Infrastructure.Data.Base;

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
        public DbSet<Estudiante> Estudiantes { get; set; }

        public DbSet<Proyecto> Proyectos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>().HasKey(c => c.Id);
            modelBuilder.Entity<Proyecto>().HasKey(c => c.Id);

            base.OnModelCreating(modelBuilder);
        }

    }
}
