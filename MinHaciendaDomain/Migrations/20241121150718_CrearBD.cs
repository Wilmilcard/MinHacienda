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
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Upton", new DateTime(2024, 11, 21, 10, 7, 16, 575, DateTimeKind.Local).AddTicks(2515), "MinHacienda", "accusamus", "Damon_Upton68@yahoo.com", "Damon" },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fay", new DateTime(2024, 11, 21, 10, 7, 16, 575, DateTimeKind.Local).AddTicks(2515), "MinHacienda", "voluptates", "Robin_Fay@gmail.com", "Robin" },
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Abernathy", new DateTime(2024, 11, 21, 10, 7, 16, 575, DateTimeKind.Local).AddTicks(2515), "MinHacienda", "accusamus", "Marlene72@yahoo.com", "Marlene" },
                    { 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "McCullough", new DateTime(2024, 11, 21, 10, 7, 16, 575, DateTimeKind.Local).AddTicks(2515), "MinHacienda", "quos", "George.McCullough@hotmail.com", "George" },
                    { 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Heathcote", new DateTime(2024, 11, 21, 10, 7, 16, 575, DateTimeKind.Local).AddTicks(2515), "MinHacienda", "nihil", "Viola77@hotmail.com", "Viola" },
                    { 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bashirian", new DateTime(2024, 11, 21, 10, 7, 16, 575, DateTimeKind.Local).AddTicks(2515), "MinHacienda", "ea", "Patsy.Bashirian54@yahoo.com", "Patsy" },
                    { 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Erdman", new DateTime(2024, 11, 21, 10, 7, 16, 575, DateTimeKind.Local).AddTicks(2515), "MinHacienda", "possimus", "Gilbert_Erdman@yahoo.com", "Gilbert" },
                    { 8, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mills", new DateTime(2024, 11, 21, 10, 7, 16, 575, DateTimeKind.Local).AddTicks(2515), "MinHacienda", "ut", "Beth47@gmail.com", "Beth" },
                    { 9, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rau", new DateTime(2024, 11, 21, 10, 7, 16, 575, DateTimeKind.Local).AddTicks(2515), "MinHacienda", "in", "Greg13@gmail.com", "Greg" },
                    { 10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kub", new DateTime(2024, 11, 21, 10, 7, 16, 575, DateTimeKind.Local).AddTicks(2515), "MinHacienda", "in", "Nettie_Kub@hotmail.com", "Nettie" },
                    { 11, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Schuster", new DateTime(2024, 11, 21, 10, 7, 16, 575, DateTimeKind.Local).AddTicks(2515), "MinHacienda", "ut", "Tracy.Schuster11@gmail.com", "Tracy" },
                    { 12, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Prosacco", new DateTime(2024, 11, 21, 10, 7, 16, 575, DateTimeKind.Local).AddTicks(2515), "MinHacienda", "sint", "Lionel_Prosacco28@yahoo.com", "Lionel" },
                    { 13, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mertz", new DateTime(2024, 11, 21, 10, 7, 16, 575, DateTimeKind.Local).AddTicks(2515), "MinHacienda", "deleniti", "Delbert_Mertz14@gmail.com", "Delbert" },
                    { 14, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lesch", new DateTime(2024, 11, 21, 10, 7, 16, 575, DateTimeKind.Local).AddTicks(2515), "MinHacienda", "tenetur", "Derek.Lesch71@hotmail.com", "Derek" },
                    { 15, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lind", new DateTime(2024, 11, 21, 10, 7, 16, 575, DateTimeKind.Local).AddTicks(2515), "MinHacienda", "dolorem", "Ashley44@hotmail.com", "Ashley" },
                    { 16, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Willms", new DateTime(2024, 11, 21, 10, 7, 16, 575, DateTimeKind.Local).AddTicks(2515), "MinHacienda", "illum", "Cindy_Willms83@yahoo.com", "Cindy" },
                    { 17, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hauck", new DateTime(2024, 11, 21, 10, 7, 16, 575, DateTimeKind.Local).AddTicks(2515), "MinHacienda", "laudantium", "Florence.Hauck70@hotmail.com", "Florence" },
                    { 18, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Schmidt", new DateTime(2024, 11, 21, 10, 7, 16, 575, DateTimeKind.Local).AddTicks(2515), "MinHacienda", "animi", "Bryant.Schmidt34@yahoo.com", "Bryant" },
                    { 19, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gorczany", new DateTime(2024, 11, 21, 10, 7, 16, 575, DateTimeKind.Local).AddTicks(2515), "MinHacienda", "a", "Cora_Gorczany55@gmail.com", "Cora" },
                    { 20, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Grady", new DateTime(2024, 11, 21, 10, 7, 16, 575, DateTimeKind.Local).AddTicks(2515), "MinHacienda", "non", "Roland_Grady52@gmail.com", "Roland" },
                    { 21, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Braun", new DateTime(2024, 11, 21, 10, 7, 16, 575, DateTimeKind.Local).AddTicks(2515), "MinHacienda", "quisquam", "Stacy_Braun@gmail.com", "Stacy" },
                    { 22, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Satterfield", new DateTime(2024, 11, 21, 10, 7, 16, 575, DateTimeKind.Local).AddTicks(2515), "MinHacienda", "voluptatem", "Verna_Satterfield88@yahoo.com", "Verna" },
                    { 23, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Auer", new DateTime(2024, 11, 21, 10, 7, 16, 575, DateTimeKind.Local).AddTicks(2515), "MinHacienda", "molestias", "Sammy29@gmail.com", "Sammy" },
                    { 24, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rutherford", new DateTime(2024, 11, 21, 10, 7, 16, 575, DateTimeKind.Local).AddTicks(2515), "MinHacienda", "hic", "Kim41@hotmail.com", "Kim" },
                    { 25, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rice", new DateTime(2024, 11, 21, 10, 7, 16, 575, DateTimeKind.Local).AddTicks(2515), "MinHacienda", "rerum", "Patrick65@hotmail.com", "Patrick" },
                    { 26, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Schroeder", new DateTime(2024, 11, 21, 10, 7, 16, 575, DateTimeKind.Local).AddTicks(2515), "MinHacienda", "id", "Ricardo.Schroeder@yahoo.com", "Ricardo" },
                    { 27, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mayer", new DateTime(2024, 11, 21, 10, 7, 16, 575, DateTimeKind.Local).AddTicks(2515), "MinHacienda", "sed", "Angelo.Mayer55@gmail.com", "Angelo" },
                    { 28, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fritsch", new DateTime(2024, 11, 21, 10, 7, 16, 575, DateTimeKind.Local).AddTicks(2515), "MinHacienda", "est", "Maxine43@gmail.com", "Maxine" },
                    { 29, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hammes", new DateTime(2024, 11, 21, 10, 7, 16, 575, DateTimeKind.Local).AddTicks(2515), "MinHacienda", "beatae", "Brittany57@gmail.com", "Brittany" },
                    { 30, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kub", new DateTime(2024, 11, 21, 10, 7, 16, 575, DateTimeKind.Local).AddTicks(2515), "MinHacienda", "neque", "Beverly_Kub@hotmail.com", "Beverly" },
                    { 31, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dickens", new DateTime(2024, 11, 21, 10, 7, 16, 575, DateTimeKind.Local).AddTicks(2515), "MinHacienda", "incidunt", "Santos.Dickens@yahoo.com", "Santos" },
                    { 32, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cole", new DateTime(2024, 11, 21, 10, 7, 16, 575, DateTimeKind.Local).AddTicks(2515), "MinHacienda", "eaque", "Alfred_Cole@hotmail.com", "Alfred" },
                    { 33, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mills", new DateTime(2024, 11, 21, 10, 7, 16, 575, DateTimeKind.Local).AddTicks(2515), "MinHacienda", "iusto", "Lillian.Mills16@hotmail.com", "Lillian" },
                    { 34, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Runolfsson", new DateTime(2024, 11, 21, 10, 7, 16, 575, DateTimeKind.Local).AddTicks(2515), "MinHacienda", "saepe", "Melanie.Runolfsson3@gmail.com", "Melanie" },
                    { 35, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Wilderman", new DateTime(2024, 11, 21, 10, 7, 16, 575, DateTimeKind.Local).AddTicks(2515), "MinHacienda", "deserunt", "Brandon.Wilderman67@hotmail.com", "Brandon" },
                    { 36, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Wintheiser", new DateTime(2024, 11, 21, 10, 7, 16, 575, DateTimeKind.Local).AddTicks(2515), "MinHacienda", "sed", "Shawn58@gmail.com", "Shawn" },
                    { 37, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Koch", new DateTime(2024, 11, 21, 10, 7, 16, 575, DateTimeKind.Local).AddTicks(2515), "MinHacienda", "rerum", "Christopher14@gmail.com", "Christopher" },
                    { 38, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Zemlak", new DateTime(2024, 11, 21, 10, 7, 16, 575, DateTimeKind.Local).AddTicks(2515), "MinHacienda", "alias", "Paula_Zemlak78@gmail.com", "Paula" },
                    { 39, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lang", new DateTime(2024, 11, 21, 10, 7, 16, 575, DateTimeKind.Local).AddTicks(2515), "MinHacienda", "quidem", "Amanda_Lang@hotmail.com", "Amanda" },
                    { 40, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Schimmel", new DateTime(2024, 11, 21, 10, 7, 16, 575, DateTimeKind.Local).AddTicks(2515), "MinHacienda", "at", "Fred_Schimmel52@gmail.com", "Fred" },
                    { 41, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hoppe", new DateTime(2024, 11, 21, 10, 7, 16, 575, DateTimeKind.Local).AddTicks(2515), "MinHacienda", "cumque", "Kenny_Hoppe@yahoo.com", "Kenny" },
                    { 42, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Daniel", new DateTime(2024, 11, 21, 10, 7, 16, 575, DateTimeKind.Local).AddTicks(2515), "MinHacienda", "tempore", "Herbert_Daniel78@yahoo.com", "Herbert" },
                    { 43, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Herman", new DateTime(2024, 11, 21, 10, 7, 16, 575, DateTimeKind.Local).AddTicks(2515), "MinHacienda", "aperiam", "Curtis.Herman34@yahoo.com", "Curtis" },
                    { 44, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Little", new DateTime(2024, 11, 21, 10, 7, 16, 575, DateTimeKind.Local).AddTicks(2515), "MinHacienda", "sed", "Earnest.Little@gmail.com", "Earnest" },
                    { 45, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Little", new DateTime(2024, 11, 21, 10, 7, 16, 575, DateTimeKind.Local).AddTicks(2515), "MinHacienda", "alias", "Gina_Little@yahoo.com", "Gina" },
                    { 46, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Robel", new DateTime(2024, 11, 21, 10, 7, 16, 575, DateTimeKind.Local).AddTicks(2515), "MinHacienda", "officia", "Amanda.Robel67@hotmail.com", "Amanda" },
                    { 47, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pacocha", new DateTime(2024, 11, 21, 10, 7, 16, 575, DateTimeKind.Local).AddTicks(2515), "MinHacienda", "fugit", "Tonya95@yahoo.com", "Tonya" },
                    { 48, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bailey", new DateTime(2024, 11, 21, 10, 7, 16, 575, DateTimeKind.Local).AddTicks(2515), "MinHacienda", "fuga", "Celia.Bailey39@hotmail.com", "Celia" },
                    { 49, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Morar", new DateTime(2024, 11, 21, 10, 7, 16, 575, DateTimeKind.Local).AddTicks(2515), "MinHacienda", "modi", "Lyle_Morar73@yahoo.com", "Lyle" },
                    { 50, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Wolff", new DateTime(2024, 11, 21, 10, 7, 16, 575, DateTimeKind.Local).AddTicks(2515), "MinHacienda", "et", "Morris.Wolff@yahoo.com", "Morris" }
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
