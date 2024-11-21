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
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hermann", new DateTime(2024, 11, 21, 13, 17, 14, 995, DateTimeKind.Local).AddTicks(7397), "MinHacienda", "molestiae", "Patsy_Hermann@gmail.com", "Patsy" },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rolfson", new DateTime(2024, 11, 21, 13, 17, 14, 995, DateTimeKind.Local).AddTicks(7397), "MinHacienda", "ullam", "Myron63@yahoo.com", "Myron" },
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dicki", new DateTime(2024, 11, 21, 13, 17, 14, 995, DateTimeKind.Local).AddTicks(7397), "MinHacienda", "voluptatem", "Jennifer.Dicki7@yahoo.com", "Jennifer" },
                    { 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jakubowski", new DateTime(2024, 11, 21, 13, 17, 14, 995, DateTimeKind.Local).AddTicks(7397), "MinHacienda", "nemo", "Glenda.Jakubowski20@gmail.com", "Glenda" },
                    { 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Simonis", new DateTime(2024, 11, 21, 13, 17, 14, 995, DateTimeKind.Local).AddTicks(7397), "MinHacienda", "et", "Antonia.Simonis12@hotmail.com", "Antonia" },
                    { 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Baumbach", new DateTime(2024, 11, 21, 13, 17, 14, 995, DateTimeKind.Local).AddTicks(7397), "MinHacienda", "commodi", "Terry_Baumbach@yahoo.com", "Terry" },
                    { 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Howell", new DateTime(2024, 11, 21, 13, 17, 14, 995, DateTimeKind.Local).AddTicks(7397), "MinHacienda", "saepe", "Al.Howell61@gmail.com", "Al" },
                    { 8, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Schroeder", new DateTime(2024, 11, 21, 13, 17, 14, 995, DateTimeKind.Local).AddTicks(7397), "MinHacienda", "velit", "Lynne40@gmail.com", "Lynne" },
                    { 9, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Murphy", new DateTime(2024, 11, 21, 13, 17, 14, 995, DateTimeKind.Local).AddTicks(7397), "MinHacienda", "perspiciatis", "Tanya_Murphy@gmail.com", "Tanya" },
                    { 10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mueller", new DateTime(2024, 11, 21, 13, 17, 14, 995, DateTimeKind.Local).AddTicks(7397), "MinHacienda", "tempora", "Felicia_Mueller@gmail.com", "Felicia" },
                    { 11, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Swaniawski", new DateTime(2024, 11, 21, 13, 17, 14, 995, DateTimeKind.Local).AddTicks(7397), "MinHacienda", "laudantium", "Theodore.Swaniawski89@hotmail.com", "Theodore" },
                    { 12, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bednar", new DateTime(2024, 11, 21, 13, 17, 14, 995, DateTimeKind.Local).AddTicks(7397), "MinHacienda", "necessitatibus", "Sherman.Bednar@hotmail.com", "Sherman" },
                    { 13, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Reichel", new DateTime(2024, 11, 21, 13, 17, 14, 995, DateTimeKind.Local).AddTicks(7397), "MinHacienda", "harum", "Van.Reichel@yahoo.com", "Van" },
                    { 14, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bednar", new DateTime(2024, 11, 21, 13, 17, 14, 995, DateTimeKind.Local).AddTicks(7397), "MinHacienda", "nostrum", "Jerald.Bednar@hotmail.com", "Jerald" },
                    { 15, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hirthe", new DateTime(2024, 11, 21, 13, 17, 14, 995, DateTimeKind.Local).AddTicks(7397), "MinHacienda", "consectetur", "Abraham_Hirthe2@gmail.com", "Abraham" },
                    { 16, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Johnson", new DateTime(2024, 11, 21, 13, 17, 14, 995, DateTimeKind.Local).AddTicks(7397), "MinHacienda", "tempore", "Jeff_Johnson51@gmail.com", "Jeff" },
                    { 17, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kihn", new DateTime(2024, 11, 21, 13, 17, 14, 995, DateTimeKind.Local).AddTicks(7397), "MinHacienda", "ut", "Isabel.Kihn34@gmail.com", "Isabel" },
                    { 18, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hamill", new DateTime(2024, 11, 21, 13, 17, 14, 995, DateTimeKind.Local).AddTicks(7397), "MinHacienda", "consectetur", "Hazel_Hamill@yahoo.com", "Hazel" },
                    { 19, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Beahan", new DateTime(2024, 11, 21, 13, 17, 14, 995, DateTimeKind.Local).AddTicks(7397), "MinHacienda", "aliquid", "Drew.Beahan@hotmail.com", "Drew" },
                    { 20, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hayes", new DateTime(2024, 11, 21, 13, 17, 14, 995, DateTimeKind.Local).AddTicks(7397), "MinHacienda", "libero", "Sharon_Hayes@hotmail.com", "Sharon" },
                    { 21, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pfeffer", new DateTime(2024, 11, 21, 13, 17, 14, 995, DateTimeKind.Local).AddTicks(7397), "MinHacienda", "consequatur", "Eric47@yahoo.com", "Eric" },
                    { 22, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bruen", new DateTime(2024, 11, 21, 13, 17, 14, 995, DateTimeKind.Local).AddTicks(7397), "MinHacienda", "mollitia", "Angel.Bruen@hotmail.com", "Angel" },
                    { 23, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Reichel", new DateTime(2024, 11, 21, 13, 17, 14, 995, DateTimeKind.Local).AddTicks(7397), "MinHacienda", "deleniti", "Steve.Reichel1@yahoo.com", "Steve" },
                    { 24, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Schinner", new DateTime(2024, 11, 21, 13, 17, 14, 995, DateTimeKind.Local).AddTicks(7397), "MinHacienda", "quisquam", "Pearl75@gmail.com", "Pearl" },
                    { 25, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lesch", new DateTime(2024, 11, 21, 13, 17, 14, 995, DateTimeKind.Local).AddTicks(7397), "MinHacienda", "delectus", "Dominic.Lesch87@hotmail.com", "Dominic" },
                    { 26, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Wehner", new DateTime(2024, 11, 21, 13, 17, 14, 995, DateTimeKind.Local).AddTicks(7397), "MinHacienda", "praesentium", "Alonzo98@hotmail.com", "Alonzo" },
                    { 27, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Blick", new DateTime(2024, 11, 21, 13, 17, 14, 995, DateTimeKind.Local).AddTicks(7397), "MinHacienda", "omnis", "Carol12@gmail.com", "Carol" },
                    { 28, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Connelly", new DateTime(2024, 11, 21, 13, 17, 14, 995, DateTimeKind.Local).AddTicks(7397), "MinHacienda", "excepturi", "Herman.Connelly93@hotmail.com", "Herman" },
                    { 29, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Brakus", new DateTime(2024, 11, 21, 13, 17, 14, 995, DateTimeKind.Local).AddTicks(7397), "MinHacienda", "soluta", "Alberto_Brakus92@gmail.com", "Alberto" },
                    { 30, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hermann", new DateTime(2024, 11, 21, 13, 17, 14, 995, DateTimeKind.Local).AddTicks(7397), "MinHacienda", "sint", "Guadalupe.Hermann@hotmail.com", "Guadalupe" },
                    { 31, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rolfson", new DateTime(2024, 11, 21, 13, 17, 14, 995, DateTimeKind.Local).AddTicks(7397), "MinHacienda", "cumque", "Norma.Rolfson38@yahoo.com", "Norma" },
                    { 32, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hegmann", new DateTime(2024, 11, 21, 13, 17, 14, 995, DateTimeKind.Local).AddTicks(7397), "MinHacienda", "voluptate", "Clara_Hegmann@hotmail.com", "Clara" },
                    { 33, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Simonis", new DateTime(2024, 11, 21, 13, 17, 14, 995, DateTimeKind.Local).AddTicks(7397), "MinHacienda", "voluptas", "Willis_Simonis59@yahoo.com", "Willis" },
                    { 34, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Orn", new DateTime(2024, 11, 21, 13, 17, 14, 995, DateTimeKind.Local).AddTicks(7397), "MinHacienda", "quos", "Jasmine.Orn97@hotmail.com", "Jasmine" },
                    { 35, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Weissnat", new DateTime(2024, 11, 21, 13, 17, 14, 995, DateTimeKind.Local).AddTicks(7397), "MinHacienda", "voluptate", "Ernesto.Weissnat@gmail.com", "Ernesto" },
                    { 36, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Waters", new DateTime(2024, 11, 21, 13, 17, 14, 995, DateTimeKind.Local).AddTicks(7397), "MinHacienda", "quas", "Alyssa31@gmail.com", "Alyssa" },
                    { 37, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hammes", new DateTime(2024, 11, 21, 13, 17, 14, 995, DateTimeKind.Local).AddTicks(7397), "MinHacienda", "dolor", "Debra.Hammes32@gmail.com", "Debra" },
                    { 38, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Schinner", new DateTime(2024, 11, 21, 13, 17, 14, 995, DateTimeKind.Local).AddTicks(7397), "MinHacienda", "rerum", "Lula_Schinner1@yahoo.com", "Lula" },
                    { 39, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Spinka", new DateTime(2024, 11, 21, 13, 17, 14, 995, DateTimeKind.Local).AddTicks(7397), "MinHacienda", "illo", "Isabel_Spinka@yahoo.com", "Isabel" },
                    { 40, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Turner", new DateTime(2024, 11, 21, 13, 17, 14, 995, DateTimeKind.Local).AddTicks(7397), "MinHacienda", "animi", "Latoya.Turner@yahoo.com", "Latoya" },
                    { 41, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Luettgen", new DateTime(2024, 11, 21, 13, 17, 14, 995, DateTimeKind.Local).AddTicks(7397), "MinHacienda", "autem", "Marsha_Luettgen@gmail.com", "Marsha" },
                    { 42, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Quitzon", new DateTime(2024, 11, 21, 13, 17, 14, 995, DateTimeKind.Local).AddTicks(7397), "MinHacienda", "qui", "Elsa39@yahoo.com", "Elsa" },
                    { 43, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Boyle", new DateTime(2024, 11, 21, 13, 17, 14, 995, DateTimeKind.Local).AddTicks(7397), "MinHacienda", "quidem", "Randal59@hotmail.com", "Randal" },
                    { 44, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Doyle", new DateTime(2024, 11, 21, 13, 17, 14, 995, DateTimeKind.Local).AddTicks(7397), "MinHacienda", "modi", "Louise_Doyle@hotmail.com", "Louise" },
                    { 45, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Block", new DateTime(2024, 11, 21, 13, 17, 14, 995, DateTimeKind.Local).AddTicks(7397), "MinHacienda", "harum", "Herbert_Block14@yahoo.com", "Herbert" },
                    { 46, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cummerata", new DateTime(2024, 11, 21, 13, 17, 14, 995, DateTimeKind.Local).AddTicks(7397), "MinHacienda", "nostrum", "Bethany36@hotmail.com", "Bethany" },
                    { 47, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Adams", new DateTime(2024, 11, 21, 13, 17, 14, 995, DateTimeKind.Local).AddTicks(7397), "MinHacienda", "ut", "Lela_Adams38@gmail.com", "Lela" },
                    { 48, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Leannon", new DateTime(2024, 11, 21, 13, 17, 14, 995, DateTimeKind.Local).AddTicks(7397), "MinHacienda", "fugit", "Jamie18@hotmail.com", "Jamie" },
                    { 49, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Farrell", new DateTime(2024, 11, 21, 13, 17, 14, 995, DateTimeKind.Local).AddTicks(7397), "MinHacienda", "ipsam", "Erick.Farrell@hotmail.com", "Erick" },
                    { 50, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rogahn", new DateTime(2024, 11, 21, 13, 17, 14, 995, DateTimeKind.Local).AddTicks(7397), "MinHacienda", "nisi", "Tim17@hotmail.com", "Tim" }
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
