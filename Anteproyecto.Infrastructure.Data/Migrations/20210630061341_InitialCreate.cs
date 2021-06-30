using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Anteproyecto.Infrastructure.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Convocatorias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FechaInicio = table.Column<DateTime>(type: "TEXT", nullable: false),
                    FechaCierre = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CargarProyectos = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Convocatorias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombres = table.Column<string>(type: "TEXT", nullable: true),
                    Apellidos = table.Column<string>(type: "TEXT", nullable: true),
                    NumeroIdentificacion = table.Column<string>(type: "TEXT", nullable: true),
                    Correo = table.Column<string>(type: "TEXT", nullable: true),
                    Contraseña = table.Column<string>(type: "TEXT", nullable: true),
                    Semestre = table.Column<int>(type: "INTEGER", nullable: false),
                    Edad = table.Column<int>(type: "INTEGER", nullable: false),
                    Estado = table.Column<bool>(type: "INTEGER", nullable: false),
                    Discriminator = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Proyectos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "TEXT", nullable: true),
                    Resumen = table.Column<string>(type: "TEXT", nullable: true),
                    Url_Archive = table.Column<string>(type: "TEXT", nullable: true),
                    Focus = table.Column<string>(type: "TEXT", nullable: true),
                    Cut = table.Column<int>(type: "INTEGER", nullable: false),
                    Line = table.Column<string>(type: "TEXT", nullable: true),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    State = table.Column<int>(type: "INTEGER", nullable: false),
                    AsesorTematicoId = table.Column<int>(type: "INTEGER", nullable: true),
                    AsesorMetodologicoId = table.Column<int>(type: "INTEGER", nullable: true),
                    Estudiante1Id = table.Column<int>(type: "INTEGER", nullable: true),
                    Estudiante2Id = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proyectos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Proyectos_Usuarios_AsesorMetodologicoId",
                        column: x => x.AsesorMetodologicoId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Proyectos_Usuarios_AsesorTematicoId",
                        column: x => x.AsesorTematicoId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Proyectos_Usuarios_Estudiante1Id",
                        column: x => x.Estudiante1Id,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Proyectos_Usuarios_Estudiante2Id",
                        column: x => x.Estudiante2Id,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Evaluacion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "TEXT", nullable: true),
                    Comentario = table.Column<string>(type: "TEXT", nullable: true),
                    Estado = table.Column<bool>(type: "INTEGER", nullable: false),
                    ProyectoId = table.Column<int>(type: "INTEGER", nullable: true),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Evaluacion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Evaluacion_Proyectos_ProyectoId",
                        column: x => x.ProyectoId,
                        principalTable: "Proyectos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Observacion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "TEXT", nullable: true),
                    Comentario = table.Column<string>(type: "TEXT", nullable: true),
                    ProyectoId = table.Column<int>(type: "INTEGER", nullable: true),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Observacion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Observacion_Proyectos_ProyectoId",
                        column: x => x.ProyectoId,
                        principalTable: "Proyectos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "Apellidos", "Contraseña", "Correo", "Discriminator", "Edad", "Estado", "Nombres", "NumeroIdentificacion", "Semestre" },
                values: new object[] { 9, "Santander Pimienta", "123344444", "hola@gmail.com", "AsesorMetodologico", 23, true, "Santiago ramirez", "3222233299", 9 });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "Apellidos", "Contraseña", "Correo", "Discriminator", "Edad", "Estado", "Nombres", "NumeroIdentificacion", "Semestre" },
                values: new object[] { 10, "Santander Pimienta", "123344444", "hola@gmail.com", "AsesorMetodologico", 23, true, "ivan lopez", "3222233200", 9 });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "Apellidos", "Contraseña", "Correo", "Discriminator", "Edad", "Estado", "Nombres", "NumeroIdentificacion", "Semestre" },
                values: new object[] { 11, "Santander Pimienta", "123344444", "hola@gmail.com", "AsesorMetodologico", 23, true, "felipe domingo", "3222233012", 9 });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "Apellidos", "Contraseña", "Correo", "Discriminator", "Edad", "Estado", "Nombres", "NumeroIdentificacion", "Semestre" },
                values: new object[] { 12, "Santander Pimienta", "123344444", "hola@gmail.com", "AsesorTematico", 23, true, "Santiago ramirez", "5222232229", 9 });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "Apellidos", "Contraseña", "Correo", "Discriminator", "Edad", "Estado", "Nombres", "NumeroIdentificacion", "Semestre" },
                values: new object[] { 13, "Santander Pimienta", "123344444", "hola@gmail.com", "AsesorTematico", 23, true, "ivan lopez", "5222221200", 9 });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "Apellidos", "Contraseña", "Correo", "Discriminator", "Edad", "Estado", "Nombres", "NumeroIdentificacion", "Semestre" },
                values: new object[] { 14, "Santander Pimienta", "123344444", "hola@gmail.com", "AsesorTematico", 23, true, "felipe domingo", "5211233012", 9 });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "Apellidos", "Contraseña", "Correo", "Discriminator", "Edad", "Estado", "Nombres", "NumeroIdentificacion", "Semestre" },
                values: new object[] { 1, "Santander Pimienta", "123344444", "hola@gmail.com", "Estudiante", 23, true, "Jose Carlo", "1222222212", 9 });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "Apellidos", "Contraseña", "Correo", "Discriminator", "Edad", "Estado", "Nombres", "NumeroIdentificacion", "Semestre" },
                values: new object[] { 2, "espinosa Pimienta", "123344444", "hola@gmail.com", "Estudiante", 23, true, "Andres alejandro", "1222222231", 9 });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "Apellidos", "Contraseña", "Correo", "Discriminator", "Edad", "Estado", "Nombres", "NumeroIdentificacion", "Semestre" },
                values: new object[] { 3, "romulo salamandra", "123344444", "hola@gmail.com", "Estudiante", 23, true, "Pedro pepi", "1222222246", 9 });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "Apellidos", "Contraseña", "Correo", "Discriminator", "Edad", "Estado", "Nombres", "NumeroIdentificacion", "Semestre" },
                values: new object[] { 4, "papeleta Piña", "123344444", "hola@gmail.com", "Estudiante", 23, true, "rodoldo pepi", "3556222246", 9 });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "Apellidos", "Contraseña", "Correo", "Discriminator", "Edad", "Estado", "Nombres", "NumeroIdentificacion", "Semestre" },
                values: new object[] { 5, "pepe de la hoz", "123344444", "hola@gmail.com", "Estudiante", 23, true, "san francisco", "2346222246", 9 });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "Apellidos", "Contraseña", "Correo", "Discriminator", "Edad", "Estado", "Nombres", "NumeroIdentificacion", "Semestre" },
                values: new object[] { 6, "Santander Pimienta", "123344444", "hola@gmail.com", "MiembroComite", 23, true, "Santiago ramirez", "2222233233", 9 });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "Apellidos", "Contraseña", "Correo", "Discriminator", "Edad", "Estado", "Nombres", "NumeroIdentificacion", "Semestre" },
                values: new object[] { 7, "Santander Pimienta", "123344444", "hola@gmail.com", "MiembroComite", 23, true, "ivan lopez", "2222233222", 9 });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "Apellidos", "Contraseña", "Correo", "Discriminator", "Edad", "Estado", "Nombres", "NumeroIdentificacion", "Semestre" },
                values: new object[] { 8, "Santander Pimienta", "123344444", "hola@gmail.com", "MiembroComite", 23, true, "felipe domingo", "2222233345", 9 });

            migrationBuilder.InsertData(
                table: "Proyectos",
                columns: new[] { "Id", "AsesorMetodologicoId", "AsesorTematicoId", "Cut", "Date", "Estudiante1Id", "Estudiante2Id", "Focus", "Line", "Nombre", "Resumen", "State", "Url_Archive" },
                values: new object[] { 1, 9, 12, 2, new DateTime(2021, 6, 30, 1, 13, 39, 670, DateTimeKind.Local).AddTicks(5778), null, null, "arriva", "investigacion", "El proyecto de ley", "resumen del proyecto", 1, "arriba/pero" });

            migrationBuilder.InsertData(
                table: "Evaluacion",
                columns: new[] { "Id", "Comentario", "Date", "Estado", "Nombre", "ProyectoId" },
                values: new object[] { 1, "holaa mudnooo aqui", new DateTime(2021, 6, 30, 0, 0, 0, 0, DateTimeKind.Local), true, "Correccion de objetivos", 1 });

            migrationBuilder.InsertData(
                table: "Observacion",
                columns: new[] { "Id", "Comentario", "Date", "Nombre", "ProyectoId" },
                values: new object[] { 1, "holaa mudnooo aqui", new DateTime(2021, 6, 30, 1, 13, 39, 674, DateTimeKind.Local).AddTicks(5010), "Correccion de objetivos", 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Evaluacion_ProyectoId",
                table: "Evaluacion",
                column: "ProyectoId");

            migrationBuilder.CreateIndex(
                name: "IX_Observacion_ProyectoId",
                table: "Observacion",
                column: "ProyectoId");

            migrationBuilder.CreateIndex(
                name: "IX_Proyectos_AsesorMetodologicoId",
                table: "Proyectos",
                column: "AsesorMetodologicoId");

            migrationBuilder.CreateIndex(
                name: "IX_Proyectos_AsesorTematicoId",
                table: "Proyectos",
                column: "AsesorTematicoId");

            migrationBuilder.CreateIndex(
                name: "IX_Proyectos_Estudiante1Id",
                table: "Proyectos",
                column: "Estudiante1Id");

            migrationBuilder.CreateIndex(
                name: "IX_Proyectos_Estudiante2Id",
                table: "Proyectos",
                column: "Estudiante2Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Convocatorias");

            migrationBuilder.DropTable(
                name: "Evaluacion");

            migrationBuilder.DropTable(
                name: "Observacion");

            migrationBuilder.DropTable(
                name: "Proyectos");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
