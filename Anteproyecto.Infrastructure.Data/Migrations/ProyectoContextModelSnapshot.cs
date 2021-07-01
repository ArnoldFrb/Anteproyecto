﻿// <auto-generated />
using System;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Anteproyecto.Infrastructure.Data.Migrations
{
    [DbContext(typeof(ProyectoContext))]
    partial class ProyectoContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.7");

            modelBuilder.Entity("Anteproyecto.Domain.Entities.Convocatoria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("CargarProyectos")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("FechaCierre")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("FechaInicio")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Convocatorias");
                });

            modelBuilder.Entity("Anteproyecto.Domain.Entities.Evaluacion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Comentario")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<bool>("Estado")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nombre")
                        .HasColumnType("TEXT");

                    b.Property<int?>("ProyectoId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ProyectoId");

                    b.ToTable("Evaluacion");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Comentario = "holaa mudnooo aqui",
                            Date = new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Local),
                            Estado = true,
                            Nombre = "Correccion de objetivos",
                            ProyectoId = 1
                        });
                });

            modelBuilder.Entity("Anteproyecto.Domain.Entities.Observacion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Comentario")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nombre")
                        .HasColumnType("TEXT");

                    b.Property<int?>("ProyectoId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ProyectoId");

                    b.ToTable("Observacion");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Comentario = "holaa mudnooo aqui",
                            Date = new DateTime(2021, 7, 1, 9, 9, 17, 721, DateTimeKind.Local).AddTicks(4808),
                            Nombre = "Correccion de objetivos",
                            ProyectoId = 1
                        });
                });

            modelBuilder.Entity("Anteproyecto.Domain.Entities.Proyecto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("AsesorMetodologicoId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("AsesorTematicoId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Cut")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<int?>("Estudiante1Id")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("Estudiante2Id")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Focus")
                        .HasColumnType("TEXT");

                    b.Property<string>("Line")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nombre")
                        .HasColumnType("TEXT");

                    b.Property<string>("Resumen")
                        .HasColumnType("TEXT");

                    b.Property<int>("State")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Url_Archive")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("AsesorMetodologicoId");

                    b.HasIndex("AsesorTematicoId");

                    b.HasIndex("Estudiante1Id");

                    b.HasIndex("Estudiante2Id");

                    b.ToTable("Proyectos");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AsesorMetodologicoId = 9,
                            AsesorTematicoId = 12,
                            Cut = 2,
                            Date = new DateTime(2021, 7, 1, 9, 9, 17, 719, DateTimeKind.Local).AddTicks(2915),
                            Estudiante1Id = 1,
                            Estudiante2Id = 2,
                            Focus = "arriva",
                            Line = "investigacion",
                            Nombre = "El proyecto de ley",
                            Resumen = "resumen del proyecto",
                            State = 1,
                            Url_Archive = "arriba/pero"
                        });
                });

            modelBuilder.Entity("Anteproyecto.Domain.Entities.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Apellidos")
                        .HasColumnType("TEXT");

                    b.Property<string>("Contraseña")
                        .HasColumnType("TEXT");

                    b.Property<string>("Correo")
                        .HasColumnType("TEXT");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Edad")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Estado")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nombres")
                        .HasColumnType("TEXT");

                    b.Property<string>("NumeroIdentificacion")
                        .HasColumnType("TEXT");

                    b.Property<int>("Semestre")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Usuarios");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Usuario");
                });

            modelBuilder.Entity("Anteproyecto.Domain.Entities.AsesorMetodologico", b =>
                {
                    b.HasBaseType("Anteproyecto.Domain.Entities.Usuario");

                    b.HasDiscriminator().HasValue("AsesorMetodologico");

                    b.HasData(
                        new
                        {
                            Id = 9,
                            Apellidos = "Santander Pimienta",
                            Contraseña = "123344444",
                            Correo = "AsesorM1@gmail.com",
                            Edad = 23,
                            Estado = false,
                            Nombres = "Santiago ramirez",
                            NumeroIdentificacion = "3222233299",
                            Semestre = 9
                        },
                        new
                        {
                            Id = 10,
                            Apellidos = "Santander Pimienta",
                            Contraseña = "123344444",
                            Correo = "AsesorM2@gmail.com",
                            Edad = 23,
                            Estado = true,
                            Nombres = "velen lopez",
                            NumeroIdentificacion = "3222233200",
                            Semestre = 9
                        },
                        new
                        {
                            Id = 11,
                            Apellidos = "Santander Pimienta",
                            Contraseña = "123344444",
                            Correo = "AsesorM3@gmail.com",
                            Edad = 23,
                            Estado = true,
                            Nombres = "rico rico domingo",
                            NumeroIdentificacion = "3222233012",
                            Semestre = 9
                        });
                });

            modelBuilder.Entity("Anteproyecto.Domain.Entities.AsesorTematico", b =>
                {
                    b.HasBaseType("Anteproyecto.Domain.Entities.Usuario");

                    b.HasDiscriminator().HasValue("AsesorTematico");

                    b.HasData(
                        new
                        {
                            Id = 12,
                            Apellidos = "Santander Pimienta",
                            Contraseña = "123344444",
                            Correo = "AsesorTm1@gmail.com",
                            Edad = 23,
                            Estado = false,
                            Nombres = "pedro ramirez",
                            NumeroIdentificacion = "5222232229",
                            Semestre = 9
                        },
                        new
                        {
                            Id = 13,
                            Apellidos = "Santander Pimienta",
                            Contraseña = "123344444",
                            Correo = "AsesorT2@gmail.com",
                            Edad = 23,
                            Estado = true,
                            Nombres = "reminro lopez",
                            NumeroIdentificacion = "5222221200",
                            Semestre = 9
                        },
                        new
                        {
                            Id = 14,
                            Apellidos = "Santander Pimienta",
                            Contraseña = "123344444",
                            Correo = "AsesorT3@gmail.com",
                            Edad = 23,
                            Estado = true,
                            Nombres = "osvaldo  domingo",
                            NumeroIdentificacion = "5211233012",
                            Semestre = 9
                        });
                });

            modelBuilder.Entity("Anteproyecto.Domain.Entities.Estudiante", b =>
                {
                    b.HasBaseType("Anteproyecto.Domain.Entities.Usuario");

                    b.HasDiscriminator().HasValue("Estudiante");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Apellidos = "Santander Pimienta",
                            Contraseña = "123344444",
                            Correo = "estudiante1@gmail.com",
                            Edad = 13,
                            Estado = false,
                            Nombres = "Jose Carlo",
                            NumeroIdentificacion = "1222222212",
                            Semestre = 5
                        },
                        new
                        {
                            Id = 2,
                            Apellidos = "espinosa Pimienta",
                            Contraseña = "123344444",
                            Correo = "estudiante2@gmail.com",
                            Edad = 13,
                            Estado = false,
                            Nombres = "Andres alejandro",
                            NumeroIdentificacion = "1222222231",
                            Semestre = 2
                        },
                        new
                        {
                            Id = 3,
                            Apellidos = "romulo salamandra",
                            Contraseña = "123344444",
                            Correo = "estudiante3@gmail.com",
                            Edad = 43,
                            Estado = true,
                            Nombres = "Pedro pepi",
                            NumeroIdentificacion = "1222222246",
                            Semestre = 5
                        },
                        new
                        {
                            Id = 4,
                            Apellidos = "papeleta Piña",
                            Contraseña = "123344444",
                            Correo = "hoestudiante4la@gmail.com",
                            Edad = 53,
                            Estado = true,
                            Nombres = "rodoldo pepi",
                            NumeroIdentificacion = "3556222246",
                            Semestre = 4
                        },
                        new
                        {
                            Id = 5,
                            Apellidos = "pepe de la hoz",
                            Contraseña = "123344444",
                            Correo = "estudiante5@gmail.com",
                            Edad = 33,
                            Estado = true,
                            Nombres = "san francisco",
                            NumeroIdentificacion = "2346222246",
                            Semestre = 3
                        });
                });

            modelBuilder.Entity("Anteproyecto.Domain.Entities.MiembroComite", b =>
                {
                    b.HasBaseType("Anteproyecto.Domain.Entities.Usuario");

                    b.HasDiscriminator().HasValue("MiembroComite");

                    b.HasData(
                        new
                        {
                            Id = 6,
                            Apellidos = "Santander Pimienta",
                            Contraseña = "123344444",
                            Correo = "Miembroc1@gmail.com",
                            Edad = 23,
                            Estado = false,
                            Nombres = "Santiago ramirez",
                            NumeroIdentificacion = "2222233233",
                            Semestre = 9
                        },
                        new
                        {
                            Id = 7,
                            Apellidos = "Santander Pimienta",
                            Contraseña = "123344444",
                            Correo = "Miembroc2@gmail.com",
                            Edad = 23,
                            Estado = true,
                            Nombres = "ivan lopez",
                            NumeroIdentificacion = "2222233222",
                            Semestre = 9
                        },
                        new
                        {
                            Id = 8,
                            Apellidos = "Santander Pimienta",
                            Contraseña = "123344444",
                            Correo = "Miembroc3@gmail.com",
                            Edad = 23,
                            Estado = true,
                            Nombres = "felipe domingo",
                            NumeroIdentificacion = "2222233345",
                            Semestre = 9
                        });
                });

            modelBuilder.Entity("Anteproyecto.Domain.Entities.Evaluacion", b =>
                {
                    b.HasOne("Anteproyecto.Domain.Entities.Proyecto", "Proyecto")
                        .WithMany()
                        .HasForeignKey("ProyectoId");

                    b.Navigation("Proyecto");
                });

            modelBuilder.Entity("Anteproyecto.Domain.Entities.Observacion", b =>
                {
                    b.HasOne("Anteproyecto.Domain.Entities.Proyecto", "Proyecto")
                        .WithMany()
                        .HasForeignKey("ProyectoId");

                    b.Navigation("Proyecto");
                });

            modelBuilder.Entity("Anteproyecto.Domain.Entities.Proyecto", b =>
                {
                    b.HasOne("Anteproyecto.Domain.Entities.AsesorMetodologico", "AsesorMetodologico")
                        .WithMany()
                        .HasForeignKey("AsesorMetodologicoId");

                    b.HasOne("Anteproyecto.Domain.Entities.AsesorTematico", "AsesorTematico")
                        .WithMany()
                        .HasForeignKey("AsesorTematicoId");

                    b.HasOne("Anteproyecto.Domain.Entities.Usuario", "Estudiante1")
                        .WithMany()
                        .HasForeignKey("Estudiante1Id");

                    b.HasOne("Anteproyecto.Domain.Entities.Usuario", "Estudiante2")
                        .WithMany()
                        .HasForeignKey("Estudiante2Id");

                    b.Navigation("AsesorMetodologico");

                    b.Navigation("AsesorTematico");

                    b.Navigation("Estudiante1");

                    b.Navigation("Estudiante2");
                });
#pragma warning restore 612, 618
        }
    }
}
