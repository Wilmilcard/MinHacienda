using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MinHaciendaDomain.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cursos",
                columns: table => new
                {
                    CursoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Codigo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Creditos = table.Column<int>(type: "int", nullable: false),
                    Creado = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreadoPor = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Actualizado = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cursos", x => x.CursoId);
                });

            migrationBuilder.CreateTable(
                name: "Estudiantes",
                columns: table => new
                {
                    EstudianteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Genero = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Creado = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreadoPor = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Actualizado = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estudiantes", x => x.EstudianteId);
                });

            migrationBuilder.CreateTable(
                name: "Profesores",
                columns: table => new
                {
                    ProfesorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Departamento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Creado = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreadoPor = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Actualizado = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profesores", x => x.ProfesorId);
                });

            migrationBuilder.CreateTable(
                name: "Inscripciones",
                columns: table => new
                {
                    InscripcionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EstudianteId = table.Column<int>(type: "int", nullable: false),
                    CursoId = table.Column<int>(type: "int", nullable: false),
                    FechaInscripcion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Creado = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreadoPor = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Actualizado = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inscripciones", x => x.InscripcionId);
                    table.ForeignKey(
                        name: "FK_Inscripciones_Cursos_CursoId",
                        column: x => x.CursoId,
                        principalTable: "Cursos",
                        principalColumn: "CursoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Inscripciones_Estudiantes_EstudianteId",
                        column: x => x.EstudianteId,
                        principalTable: "Estudiantes",
                        principalColumn: "EstudianteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Asignaciones",
                columns: table => new
                {
                    AsignacionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProfesorId = table.Column<int>(type: "int", nullable: false),
                    CursoId = table.Column<int>(type: "int", nullable: false),
                    Semestre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Creado = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreadoPor = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Actualizado = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Asignaciones", x => x.AsignacionId);
                    table.ForeignKey(
                        name: "FK_Asignaciones_Cursos_CursoId",
                        column: x => x.CursoId,
                        principalTable: "Cursos",
                        principalColumn: "CursoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Asignaciones_Profesores_ProfesorId",
                        column: x => x.ProfesorId,
                        principalTable: "Profesores",
                        principalColumn: "ProfesorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Asignaciones_CursoId",
                table: "Asignaciones",
                column: "CursoId");

            migrationBuilder.CreateIndex(
                name: "IX_Asignaciones_ProfesorId",
                table: "Asignaciones",
                column: "ProfesorId");

            migrationBuilder.CreateIndex(
                name: "IX_Inscripciones_CursoId",
                table: "Inscripciones",
                column: "CursoId");

            migrationBuilder.CreateIndex(
                name: "IX_Inscripciones_EstudianteId",
                table: "Inscripciones",
                column: "EstudianteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Asignaciones");

            migrationBuilder.DropTable(
                name: "Inscripciones");

            migrationBuilder.DropTable(
                name: "Profesores");

            migrationBuilder.DropTable(
                name: "Cursos");

            migrationBuilder.DropTable(
                name: "Estudiantes");
        }
    }
}
