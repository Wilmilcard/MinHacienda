using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MinHaciendaDomain.Migrations
{
    /// <inheritdoc />
    public partial class CrearBD : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "cursos",
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
                    table.PrimaryKey("PK_cursos", x => x.CursoId);
                });

            migrationBuilder.CreateTable(
                name: "estudiantes",
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
                    table.PrimaryKey("PK_estudiantes", x => x.EstudianteId);
                });

            migrationBuilder.CreateTable(
                name: "profesores",
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
                    table.PrimaryKey("PK_profesores", x => x.ProfesorId);
                });

            migrationBuilder.CreateTable(
                name: "inscripciones",
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
                    table.PrimaryKey("PK_inscripciones", x => x.InscripcionId);
                    table.ForeignKey(
                        name: "FK_inscripciones_cursos_CursoId",
                        column: x => x.CursoId,
                        principalTable: "cursos",
                        principalColumn: "CursoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_inscripciones_estudiantes_EstudianteId",
                        column: x => x.EstudianteId,
                        principalTable: "estudiantes",
                        principalColumn: "EstudianteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "asignaciones",
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
                    table.PrimaryKey("PK_asignaciones", x => x.AsignacionId);
                    table.ForeignKey(
                        name: "FK_asignaciones_cursos_CursoId",
                        column: x => x.CursoId,
                        principalTable: "cursos",
                        principalColumn: "CursoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_asignaciones_profesores_ProfesorId",
                        column: x => x.ProfesorId,
                        principalTable: "profesores",
                        principalColumn: "ProfesorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "profesores",
                columns: new[] { "ProfesorId", "Actualizado", "Apellido", "Creado", "CreadoPor", "Departamento", "Email", "Nombre" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bradtke", new DateTime(2024, 11, 20, 14, 42, 31, 220, DateTimeKind.Local).AddTicks(2573), "MinHacienda", "quia", "Marion.Bradtke59@gmail.com", "Marion" },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rutherford", new DateTime(2024, 11, 20, 14, 42, 31, 220, DateTimeKind.Local).AddTicks(2573), "MinHacienda", "quaerat", "Delbert23@hotmail.com", "Delbert" },
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Moen", new DateTime(2024, 11, 20, 14, 42, 31, 220, DateTimeKind.Local).AddTicks(2573), "MinHacienda", "beatae", "Brooke.Moen9@yahoo.com", "Brooke" },
                    { 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Smith", new DateTime(2024, 11, 20, 14, 42, 31, 220, DateTimeKind.Local).AddTicks(2573), "MinHacienda", "cupiditate", "Teresa.Smith89@hotmail.com", "Teresa" },
                    { 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gutmann", new DateTime(2024, 11, 20, 14, 42, 31, 220, DateTimeKind.Local).AddTicks(2573), "MinHacienda", "architecto", "Inez_Gutmann82@gmail.com", "Inez" },
                    { 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Treutel", new DateTime(2024, 11, 20, 14, 42, 31, 220, DateTimeKind.Local).AddTicks(2573), "MinHacienda", "inventore", "Olivia23@yahoo.com", "Olivia" },
                    { 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Senger", new DateTime(2024, 11, 20, 14, 42, 31, 220, DateTimeKind.Local).AddTicks(2573), "MinHacienda", "autem", "Lionel74@gmail.com", "Lionel" },
                    { 8, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kihn", new DateTime(2024, 11, 20, 14, 42, 31, 220, DateTimeKind.Local).AddTicks(2573), "MinHacienda", "ea", "Erick34@yahoo.com", "Erick" },
                    { 9, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cartwright", new DateTime(2024, 11, 20, 14, 42, 31, 220, DateTimeKind.Local).AddTicks(2573), "MinHacienda", "enim", "Kim_Cartwright@yahoo.com", "Kim" },
                    { 10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dickinson", new DateTime(2024, 11, 20, 14, 42, 31, 220, DateTimeKind.Local).AddTicks(2573), "MinHacienda", "quis", "Pete_Dickinson@yahoo.com", "Pete" },
                    { 11, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Braun", new DateTime(2024, 11, 20, 14, 42, 31, 220, DateTimeKind.Local).AddTicks(2573), "MinHacienda", "eum", "Lamar.Braun82@gmail.com", "Lamar" },
                    { 12, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hand", new DateTime(2024, 11, 20, 14, 42, 31, 220, DateTimeKind.Local).AddTicks(2573), "MinHacienda", "laboriosam", "Taylor.Hand44@gmail.com", "Taylor" },
                    { 13, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Reinger", new DateTime(2024, 11, 20, 14, 42, 31, 220, DateTimeKind.Local).AddTicks(2573), "MinHacienda", "esse", "Joel59@hotmail.com", "Joel" },
                    { 14, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Feil", new DateTime(2024, 11, 20, 14, 42, 31, 220, DateTimeKind.Local).AddTicks(2573), "MinHacienda", "eum", "Toby_Feil@yahoo.com", "Toby" },
                    { 15, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Howell", new DateTime(2024, 11, 20, 14, 42, 31, 220, DateTimeKind.Local).AddTicks(2573), "MinHacienda", "in", "Ebony.Howell@hotmail.com", "Ebony" },
                    { 16, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Langworth", new DateTime(2024, 11, 20, 14, 42, 31, 220, DateTimeKind.Local).AddTicks(2573), "MinHacienda", "sed", "Randall.Langworth41@yahoo.com", "Randall" },
                    { 17, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rohan", new DateTime(2024, 11, 20, 14, 42, 31, 220, DateTimeKind.Local).AddTicks(2573), "MinHacienda", "autem", "Paula23@hotmail.com", "Paula" },
                    { 18, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hoppe", new DateTime(2024, 11, 20, 14, 42, 31, 220, DateTimeKind.Local).AddTicks(2573), "MinHacienda", "vel", "Stuart.Hoppe@gmail.com", "Stuart" },
                    { 19, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Walter", new DateTime(2024, 11, 20, 14, 42, 31, 220, DateTimeKind.Local).AddTicks(2573), "MinHacienda", "placeat", "Rhonda82@yahoo.com", "Rhonda" },
                    { 20, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Christiansen", new DateTime(2024, 11, 20, 14, 42, 31, 220, DateTimeKind.Local).AddTicks(2573), "MinHacienda", "nemo", "Josephine_Christiansen36@yahoo.com", "Josephine" },
                    { 21, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hammes", new DateTime(2024, 11, 20, 14, 42, 31, 220, DateTimeKind.Local).AddTicks(2573), "MinHacienda", "eveniet", "Aubrey13@gmail.com", "Aubrey" },
                    { 22, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Schmitt", new DateTime(2024, 11, 20, 14, 42, 31, 220, DateTimeKind.Local).AddTicks(2573), "MinHacienda", "qui", "Lorena_Schmitt@yahoo.com", "Lorena" },
                    { 23, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pfeffer", new DateTime(2024, 11, 20, 14, 42, 31, 220, DateTimeKind.Local).AddTicks(2573), "MinHacienda", "voluptatem", "Camille.Pfeffer43@hotmail.com", "Camille" },
                    { 24, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dibbert", new DateTime(2024, 11, 20, 14, 42, 31, 220, DateTimeKind.Local).AddTicks(2573), "MinHacienda", "quo", "Ana48@yahoo.com", "Ana" },
                    { 25, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Larkin", new DateTime(2024, 11, 20, 14, 42, 31, 220, DateTimeKind.Local).AddTicks(2573), "MinHacienda", "enim", "Bruce_Larkin61@gmail.com", "Bruce" },
                    { 26, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Wiza", new DateTime(2024, 11, 20, 14, 42, 31, 220, DateTimeKind.Local).AddTicks(2573), "MinHacienda", "debitis", "Irene_Wiza@gmail.com", "Irene" },
                    { 27, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Farrell", new DateTime(2024, 11, 20, 14, 42, 31, 220, DateTimeKind.Local).AddTicks(2573), "MinHacienda", "veniam", "Gary_Farrell55@hotmail.com", "Gary" },
                    { 28, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Raynor", new DateTime(2024, 11, 20, 14, 42, 31, 220, DateTimeKind.Local).AddTicks(2573), "MinHacienda", "omnis", "Jody88@gmail.com", "Jody" },
                    { 29, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jaskolski", new DateTime(2024, 11, 20, 14, 42, 31, 220, DateTimeKind.Local).AddTicks(2573), "MinHacienda", "dolores", "Patsy_Jaskolski@yahoo.com", "Patsy" },
                    { 30, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Schumm", new DateTime(2024, 11, 20, 14, 42, 31, 220, DateTimeKind.Local).AddTicks(2573), "MinHacienda", "recusandae", "Billie77@gmail.com", "Billie" },
                    { 31, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kutch", new DateTime(2024, 11, 20, 14, 42, 31, 220, DateTimeKind.Local).AddTicks(2573), "MinHacienda", "iusto", "Ervin_Kutch4@yahoo.com", "Ervin" },
                    { 32, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Parisian", new DateTime(2024, 11, 20, 14, 42, 31, 220, DateTimeKind.Local).AddTicks(2573), "MinHacienda", "sed", "Alice.Parisian61@hotmail.com", "Alice" },
                    { 33, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Padberg", new DateTime(2024, 11, 20, 14, 42, 31, 220, DateTimeKind.Local).AddTicks(2573), "MinHacienda", "eum", "Sherri8@yahoo.com", "Sherri" },
                    { 34, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Donnelly", new DateTime(2024, 11, 20, 14, 42, 31, 220, DateTimeKind.Local).AddTicks(2573), "MinHacienda", "saepe", "Mercedes48@hotmail.com", "Mercedes" },
                    { 35, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Becker", new DateTime(2024, 11, 20, 14, 42, 31, 220, DateTimeKind.Local).AddTicks(2573), "MinHacienda", "est", "Jose54@hotmail.com", "Jose" },
                    { 36, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Stanton", new DateTime(2024, 11, 20, 14, 42, 31, 220, DateTimeKind.Local).AddTicks(2573), "MinHacienda", "eum", "Todd76@hotmail.com", "Todd" },
                    { 37, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Maggio", new DateTime(2024, 11, 20, 14, 42, 31, 220, DateTimeKind.Local).AddTicks(2573), "MinHacienda", "recusandae", "Peter.Maggio@hotmail.com", "Peter" },
                    { 38, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Roberts", new DateTime(2024, 11, 20, 14, 42, 31, 220, DateTimeKind.Local).AddTicks(2573), "MinHacienda", "omnis", "Virginia_Roberts@hotmail.com", "Virginia" },
                    { 39, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Donnelly", new DateTime(2024, 11, 20, 14, 42, 31, 220, DateTimeKind.Local).AddTicks(2573), "MinHacienda", "quia", "Wesley.Donnelly65@yahoo.com", "Wesley" },
                    { 40, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Runte", new DateTime(2024, 11, 20, 14, 42, 31, 220, DateTimeKind.Local).AddTicks(2573), "MinHacienda", "consequatur", "Lena85@yahoo.com", "Lena" },
                    { 41, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lockman", new DateTime(2024, 11, 20, 14, 42, 31, 220, DateTimeKind.Local).AddTicks(2573), "MinHacienda", "aut", "Ora_Lockman18@gmail.com", "Ora" },
                    { 42, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Wiza", new DateTime(2024, 11, 20, 14, 42, 31, 220, DateTimeKind.Local).AddTicks(2573), "MinHacienda", "unde", "Jenna59@yahoo.com", "Jenna" },
                    { 43, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "D'Amore", new DateTime(2024, 11, 20, 14, 42, 31, 220, DateTimeKind.Local).AddTicks(2573), "MinHacienda", "iste", "Elisa37@gmail.com", "Elisa" },
                    { 44, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Moen", new DateTime(2024, 11, 20, 14, 42, 31, 220, DateTimeKind.Local).AddTicks(2573), "MinHacienda", "et", "Zachary.Moen45@yahoo.com", "Zachary" },
                    { 45, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hamill", new DateTime(2024, 11, 20, 14, 42, 31, 220, DateTimeKind.Local).AddTicks(2573), "MinHacienda", "voluptatum", "Hilda_Hamill87@gmail.com", "Hilda" },
                    { 46, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kilback", new DateTime(2024, 11, 20, 14, 42, 31, 220, DateTimeKind.Local).AddTicks(2573), "MinHacienda", "ut", "Kevin.Kilback@yahoo.com", "Kevin" },
                    { 47, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Conn", new DateTime(2024, 11, 20, 14, 42, 31, 220, DateTimeKind.Local).AddTicks(2573), "MinHacienda", "necessitatibus", "Simon54@yahoo.com", "Simon" },
                    { 48, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jakubowski", new DateTime(2024, 11, 20, 14, 42, 31, 220, DateTimeKind.Local).AddTicks(2573), "MinHacienda", "nostrum", "Lynda_Jakubowski51@hotmail.com", "Lynda" },
                    { 49, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lueilwitz", new DateTime(2024, 11, 20, 14, 42, 31, 220, DateTimeKind.Local).AddTicks(2573), "MinHacienda", "nam", "Cory_Lueilwitz@yahoo.com", "Cory" },
                    { 50, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Wunsch", new DateTime(2024, 11, 20, 14, 42, 31, 220, DateTimeKind.Local).AddTicks(2573), "MinHacienda", "est", "Vincent_Wunsch23@yahoo.com", "Vincent" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_asignaciones_CursoId",
                table: "asignaciones",
                column: "CursoId");

            migrationBuilder.CreateIndex(
                name: "IX_asignaciones_ProfesorId",
                table: "asignaciones",
                column: "ProfesorId");

            migrationBuilder.CreateIndex(
                name: "IX_inscripciones_CursoId",
                table: "inscripciones",
                column: "CursoId");

            migrationBuilder.CreateIndex(
                name: "IX_inscripciones_EstudianteId",
                table: "inscripciones",
                column: "EstudianteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "asignaciones");

            migrationBuilder.DropTable(
                name: "inscripciones");

            migrationBuilder.DropTable(
                name: "profesores");

            migrationBuilder.DropTable(
                name: "cursos");

            migrationBuilder.DropTable(
                name: "estudiantes");
        }
    }
}
