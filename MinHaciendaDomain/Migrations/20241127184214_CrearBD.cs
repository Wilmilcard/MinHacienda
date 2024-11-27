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
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(600)", maxLength: 600, nullable: false),
                    Creado = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreadoPor = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Actualizado = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "asignaciones",
                columns: table => new
                {
                    AsignacionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProfesorId = table.Column<int>(type: "int", nullable: false),
                    CursoId = table.Column<int>(type: "int", nullable: false),
                    Semestre = table.Column<int>(type: "int", nullable: false),
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
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Creado = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreadoPor = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Actualizado = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_estudiantes", x => x.EstudianteId);
                    table.ForeignKey(
                        name: "FK_estudiantes_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sesion",
                columns: table => new
                {
                    SesionID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    Token = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Expiration_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Creado = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreadoPor = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Actualizado = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sesion", x => x.SesionID);
                    table.ForeignKey(
                        name: "FK_Sesion_User_UserID",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
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

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "UserId", "Actualizado", "Creado", "CreadoPor", "PasswordHash", "Username" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 27, 13, 42, 12, 982, DateTimeKind.Local).AddTicks(5204), "MinHacienda", "A94652AA97C7211B9ECA8F8B61E1A8A7", "nombre_apellido_280" },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 27, 13, 42, 12, 982, DateTimeKind.Local).AddTicks(5204), "MinHacienda", "A94652AA97C7211B9ECA8F8B61E1A8A7", "nombre.apellido_3" },
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 27, 13, 42, 12, 982, DateTimeKind.Local).AddTicks(5204), "MinHacienda", "A94652AA97C7211B9ECA8F8B61E1A8A7", "nombre43" },
                    { 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 27, 13, 42, 12, 982, DateTimeKind.Local).AddTicks(5204), "MinHacienda", "A94652AA97C7211B9ECA8F8B61E1A8A7", "nombre32" },
                    { 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 27, 13, 42, 12, 982, DateTimeKind.Local).AddTicks(5204), "MinHacienda", "A94652AA97C7211B9ECA8F8B61E1A8A7", "nombre.apellido_6" },
                    { 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 27, 13, 42, 12, 982, DateTimeKind.Local).AddTicks(5204), "MinHacienda", "A94652AA97C7211B9ECA8F8B61E1A8A7", "nombre.apellido_7" },
                    { 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 27, 13, 42, 12, 982, DateTimeKind.Local).AddTicks(5204), "MinHacienda", "A94652AA97C7211B9ECA8F8B61E1A8A7", "nombre.apellido_8" },
                    { 8, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 27, 13, 42, 12, 982, DateTimeKind.Local).AddTicks(5204), "MinHacienda", "A94652AA97C7211B9ECA8F8B61E1A8A7", "nombre_apellido_9" },
                    { 9, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 27, 13, 42, 12, 982, DateTimeKind.Local).AddTicks(5204), "MinHacienda", "A94652AA97C7211B9ECA8F8B61E1A8A7", "nombre_apellido_1095" },
                    { 10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 27, 13, 42, 12, 982, DateTimeKind.Local).AddTicks(5204), "MinHacienda", "A94652AA97C7211B9ECA8F8B61E1A8A7", "nombre78" }
                });

            migrationBuilder.InsertData(
                table: "cursos",
                columns: new[] { "CursoId", "Actualizado", "Codigo", "Creado", "CreadoPor", "Creditos", "Nombre" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "POO", new DateTime(2024, 11, 27, 13, 42, 12, 982, DateTimeKind.Local).AddTicks(5204), "MinHacienda", 25, "Programacion" },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ING", new DateTime(2024, 11, 27, 13, 42, 12, 982, DateTimeKind.Local).AddTicks(5204), "MinHacienda", 15, "Ingles" },
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "CAL", new DateTime(2024, 11, 27, 13, 42, 12, 982, DateTimeKind.Local).AddTicks(5204), "MinHacienda", 20, "Calculo II" },
                    { 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ARQ", new DateTime(2024, 11, 27, 13, 42, 12, 982, DateTimeKind.Local).AddTicks(5204), "MinHacienda", 25, "Arquitectura" },
                    { 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "SEG", new DateTime(2024, 11, 27, 13, 42, 12, 982, DateTimeKind.Local).AddTicks(5204), "MinHacienda", 30, "Seguridad" }
                });

            migrationBuilder.InsertData(
                table: "profesores",
                columns: new[] { "ProfesorId", "Actualizado", "Apellido", "Creado", "CreadoPor", "Departamento", "Email", "Nombre" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Heidenreich", new DateTime(2024, 11, 27, 13, 42, 12, 982, DateTimeKind.Local).AddTicks(5204), "MinHacienda", "suscipit", "Frederick.Heidenreich@yahoo.com", "Frederick" },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Walter", new DateTime(2024, 11, 27, 13, 42, 12, 982, DateTimeKind.Local).AddTicks(5204), "MinHacienda", "molestiae", "Lucia40@gmail.com", "Lucia" },
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lubowitz", new DateTime(2024, 11, 27, 13, 42, 12, 982, DateTimeKind.Local).AddTicks(5204), "MinHacienda", "voluptatibus", "Mike.Lubowitz@gmail.com", "Mike" },
                    { 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Windler", new DateTime(2024, 11, 27, 13, 42, 12, 982, DateTimeKind.Local).AddTicks(5204), "MinHacienda", "autem", "Linda_Windler@yahoo.com", "Linda" },
                    { 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pfannerstill", new DateTime(2024, 11, 27, 13, 42, 12, 982, DateTimeKind.Local).AddTicks(5204), "MinHacienda", "expedita", "Larry.Pfannerstill98@yahoo.com", "Larry" },
                    { 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cartwright", new DateTime(2024, 11, 27, 13, 42, 12, 982, DateTimeKind.Local).AddTicks(5204), "MinHacienda", "autem", "Mercedes45@gmail.com", "Mercedes" },
                    { 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Collier", new DateTime(2024, 11, 27, 13, 42, 12, 982, DateTimeKind.Local).AddTicks(5204), "MinHacienda", "consequuntur", "Sammy72@gmail.com", "Sammy" },
                    { 8, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Runolfsson", new DateTime(2024, 11, 27, 13, 42, 12, 982, DateTimeKind.Local).AddTicks(5204), "MinHacienda", "dolorem", "Otis.Runolfsson@yahoo.com", "Otis" },
                    { 9, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fadel", new DateTime(2024, 11, 27, 13, 42, 12, 982, DateTimeKind.Local).AddTicks(5204), "MinHacienda", "sit", "Domingo_Fadel3@gmail.com", "Domingo" },
                    { 10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jacobson", new DateTime(2024, 11, 27, 13, 42, 12, 982, DateTimeKind.Local).AddTicks(5204), "MinHacienda", "quo", "Erma39@gmail.com", "Erma" },
                    { 11, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Parisian", new DateTime(2024, 11, 27, 13, 42, 12, 982, DateTimeKind.Local).AddTicks(5204), "MinHacienda", "dolor", "Patricia.Parisian@gmail.com", "Patricia" },
                    { 12, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Berge", new DateTime(2024, 11, 27, 13, 42, 12, 982, DateTimeKind.Local).AddTicks(5204), "MinHacienda", "facilis", "Lance_Berge6@gmail.com", "Lance" },
                    { 13, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Metz", new DateTime(2024, 11, 27, 13, 42, 12, 982, DateTimeKind.Local).AddTicks(5204), "MinHacienda", "et", "Ivan68@hotmail.com", "Ivan" },
                    { 14, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kozey", new DateTime(2024, 11, 27, 13, 42, 12, 982, DateTimeKind.Local).AddTicks(5204), "MinHacienda", "non", "Emilio3@gmail.com", "Emilio" },
                    { 15, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bechtelar", new DateTime(2024, 11, 27, 13, 42, 12, 982, DateTimeKind.Local).AddTicks(5204), "MinHacienda", "sint", "Judith_Bechtelar97@hotmail.com", "Judith" },
                    { 16, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lesch", new DateTime(2024, 11, 27, 13, 42, 12, 982, DateTimeKind.Local).AddTicks(5204), "MinHacienda", "accusamus", "Nancy_Lesch@gmail.com", "Nancy" },
                    { 17, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hegmann", new DateTime(2024, 11, 27, 13, 42, 12, 982, DateTimeKind.Local).AddTicks(5204), "MinHacienda", "porro", "Jeffery_Hegmann30@gmail.com", "Jeffery" },
                    { 18, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Wilkinson", new DateTime(2024, 11, 27, 13, 42, 12, 982, DateTimeKind.Local).AddTicks(5204), "MinHacienda", "soluta", "Vickie_Wilkinson@gmail.com", "Vickie" },
                    { 19, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pfannerstill", new DateTime(2024, 11, 27, 13, 42, 12, 982, DateTimeKind.Local).AddTicks(5204), "MinHacienda", "aut", "Tyrone77@yahoo.com", "Tyrone" },
                    { 20, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Torphy", new DateTime(2024, 11, 27, 13, 42, 12, 982, DateTimeKind.Local).AddTicks(5204), "MinHacienda", "facilis", "Delia.Torphy43@hotmail.com", "Delia" }
                });

            migrationBuilder.InsertData(
                table: "asignaciones",
                columns: new[] { "AsignacionId", "Actualizado", "Creado", "CreadoPor", "CursoId", "ProfesorId", "Semestre" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 27, 13, 42, 12, 982, DateTimeKind.Local).AddTicks(5204), "MinHacienda", 3, 1, 3 },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 27, 13, 42, 12, 982, DateTimeKind.Local).AddTicks(5204), "MinHacienda", 2, 2, 5 },
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 27, 13, 42, 12, 982, DateTimeKind.Local).AddTicks(5204), "MinHacienda", 2, 3, 9 },
                    { 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 27, 13, 42, 12, 982, DateTimeKind.Local).AddTicks(5204), "MinHacienda", 2, 4, 3 },
                    { 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 27, 13, 42, 12, 982, DateTimeKind.Local).AddTicks(5204), "MinHacienda", 1, 5, 2 },
                    { 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 27, 13, 42, 12, 982, DateTimeKind.Local).AddTicks(5204), "MinHacienda", 3, 6, 6 },
                    { 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 27, 13, 42, 12, 982, DateTimeKind.Local).AddTicks(5204), "MinHacienda", 3, 7, 4 },
                    { 8, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 27, 13, 42, 12, 982, DateTimeKind.Local).AddTicks(5204), "MinHacienda", 2, 8, 4 },
                    { 9, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 27, 13, 42, 12, 982, DateTimeKind.Local).AddTicks(5204), "MinHacienda", 3, 9, 5 },
                    { 10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 27, 13, 42, 12, 982, DateTimeKind.Local).AddTicks(5204), "MinHacienda", 1, 10, 2 },
                    { 11, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 27, 13, 42, 12, 982, DateTimeKind.Local).AddTicks(5204), "MinHacienda", 2, 11, 5 },
                    { 12, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 27, 13, 42, 12, 982, DateTimeKind.Local).AddTicks(5204), "MinHacienda", 2, 12, 3 },
                    { 13, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 27, 13, 42, 12, 982, DateTimeKind.Local).AddTicks(5204), "MinHacienda", 3, 13, 5 },
                    { 14, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 27, 13, 42, 12, 982, DateTimeKind.Local).AddTicks(5204), "MinHacienda", 4, 14, 7 },
                    { 15, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 27, 13, 42, 12, 982, DateTimeKind.Local).AddTicks(5204), "MinHacienda", 4, 15, 8 },
                    { 16, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 27, 13, 42, 12, 982, DateTimeKind.Local).AddTicks(5204), "MinHacienda", 4, 16, 3 },
                    { 17, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 27, 13, 42, 12, 982, DateTimeKind.Local).AddTicks(5204), "MinHacienda", 3, 17, 3 },
                    { 18, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 27, 13, 42, 12, 982, DateTimeKind.Local).AddTicks(5204), "MinHacienda", 1, 18, 1 },
                    { 19, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 27, 13, 42, 12, 982, DateTimeKind.Local).AddTicks(5204), "MinHacienda", 2, 19, 3 },
                    { 20, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 27, 13, 42, 12, 982, DateTimeKind.Local).AddTicks(5204), "MinHacienda", 1, 20, 4 }
                });

            migrationBuilder.InsertData(
                table: "estudiantes",
                columns: new[] { "EstudianteId", "Actualizado", "Apellido", "Creado", "CreadoPor", "Email", "FechaNacimiento", "Genero", "Nombre", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bednar", new DateTime(2024, 11, 27, 13, 42, 12, 982, DateTimeKind.Local).AddTicks(5204), "MinHacienda", "Doris.Bednar@gmail.com", new DateTime(1963, 1, 9, 0, 9, 58, 755, DateTimeKind.Local).AddTicks(3270), "F", "Doris", 6 },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Wintheiser", new DateTime(2024, 11, 27, 13, 42, 12, 982, DateTimeKind.Local).AddTicks(5204), "MinHacienda", "Allison_Wintheiser36@gmail.com", new DateTime(1978, 11, 11, 2, 40, 56, 756, DateTimeKind.Local).AddTicks(4432), "F", "Allison", 1 },
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Reynolds", new DateTime(2024, 11, 27, 13, 42, 12, 982, DateTimeKind.Local).AddTicks(5204), "MinHacienda", "Pat.Reynolds@gmail.com", new DateTime(1968, 6, 1, 17, 4, 48, 709, DateTimeKind.Local).AddTicks(5802), "F", "Pat", 2 },
                    { 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Armstrong", new DateTime(2024, 11, 27, 13, 42, 12, 982, DateTimeKind.Local).AddTicks(5204), "MinHacienda", "Bob_Armstrong31@yahoo.com", new DateTime(1994, 11, 4, 8, 21, 6, 900, DateTimeKind.Local).AddTicks(9304), "F", "Bob", 9 },
                    { 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kessler", new DateTime(2024, 11, 27, 13, 42, 12, 982, DateTimeKind.Local).AddTicks(5204), "MinHacienda", "Janice83@yahoo.com", new DateTime(1975, 12, 29, 10, 30, 57, 153, DateTimeKind.Local).AddTicks(3813), "F", "Janice", 4 },
                    { 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rohan", new DateTime(2024, 11, 27, 13, 42, 12, 982, DateTimeKind.Local).AddTicks(5204), "MinHacienda", "Aubrey.Rohan60@yahoo.com", new DateTime(1974, 11, 18, 23, 44, 26, 156, DateTimeKind.Local).AddTicks(3639), "F", "Aubrey", 5 },
                    { 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jones", new DateTime(2024, 11, 27, 13, 42, 12, 982, DateTimeKind.Local).AddTicks(5204), "MinHacienda", "Carroll78@yahoo.com", new DateTime(1960, 3, 26, 15, 45, 59, 349, DateTimeKind.Local).AddTicks(8566), "F", "Carroll", 7 },
                    { 8, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pfannerstill", new DateTime(2024, 11, 27, 13, 42, 12, 982, DateTimeKind.Local).AddTicks(5204), "MinHacienda", "Dave.Pfannerstill@gmail.com", new DateTime(1977, 2, 5, 20, 12, 45, 601, DateTimeKind.Local).AddTicks(9146), "F", "Dave", 1 },
                    { 9, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Graham", new DateTime(2024, 11, 27, 13, 42, 12, 982, DateTimeKind.Local).AddTicks(5204), "MinHacienda", "Aaron.Graham0@yahoo.com", new DateTime(1977, 2, 21, 20, 12, 10, 96, DateTimeKind.Local).AddTicks(5362), "F", "Aaron", 7 },
                    { 10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rice", new DateTime(2024, 11, 27, 13, 42, 12, 982, DateTimeKind.Local).AddTicks(5204), "MinHacienda", "Josephine51@hotmail.com", new DateTime(2004, 1, 21, 22, 31, 10, 730, DateTimeKind.Local).AddTicks(2510), "F", "Josephine", 7 },
                    { 11, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Parisian", new DateTime(2024, 11, 27, 13, 42, 12, 982, DateTimeKind.Local).AddTicks(5204), "MinHacienda", "Amber41@yahoo.com", new DateTime(1980, 11, 20, 9, 17, 33, 434, DateTimeKind.Local).AddTicks(5868), "F", "Amber", 5 },
                    { 12, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cormier", new DateTime(2024, 11, 27, 13, 42, 12, 982, DateTimeKind.Local).AddTicks(5204), "MinHacienda", "Helen_Cormier@yahoo.com", new DateTime(1963, 4, 7, 19, 53, 2, 601, DateTimeKind.Local).AddTicks(3647), "F", "Helen", 2 },
                    { 13, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ryan", new DateTime(2024, 11, 27, 13, 42, 12, 982, DateTimeKind.Local).AddTicks(5204), "MinHacienda", "Megan_Ryan21@hotmail.com", new DateTime(1996, 5, 14, 11, 22, 7, 533, DateTimeKind.Local).AddTicks(2506), "F", "Megan", 5 },
                    { 14, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rath", new DateTime(2024, 11, 27, 13, 42, 12, 982, DateTimeKind.Local).AddTicks(5204), "MinHacienda", "Gary25@yahoo.com", new DateTime(1974, 10, 20, 15, 54, 11, 79, DateTimeKind.Local).AddTicks(5307), "F", "Gary", 4 },
                    { 15, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Feeney", new DateTime(2024, 11, 27, 13, 42, 12, 982, DateTimeKind.Local).AddTicks(5204), "MinHacienda", "Julie_Feeney@yahoo.com", new DateTime(1965, 9, 9, 22, 8, 4, 77, DateTimeKind.Local).AddTicks(3242), "F", "Julie", 4 },
                    { 16, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Wolff", new DateTime(2024, 11, 27, 13, 42, 12, 982, DateTimeKind.Local).AddTicks(5204), "MinHacienda", "Kristopher.Wolff@hotmail.com", new DateTime(1980, 7, 30, 6, 7, 40, 673, DateTimeKind.Local).AddTicks(8693), "F", "Kristopher", 2 },
                    { 17, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Corwin", new DateTime(2024, 11, 27, 13, 42, 12, 982, DateTimeKind.Local).AddTicks(5204), "MinHacienda", "Sally_Corwin86@yahoo.com", new DateTime(1993, 2, 5, 14, 23, 38, 134, DateTimeKind.Local).AddTicks(2904), "F", "Sally", 9 },
                    { 18, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Reichert", new DateTime(2024, 11, 27, 13, 42, 12, 982, DateTimeKind.Local).AddTicks(5204), "MinHacienda", "Jeffrey21@gmail.com", new DateTime(1995, 5, 16, 21, 21, 42, 794, DateTimeKind.Local).AddTicks(8540), "F", "Jeffrey", 7 },
                    { 19, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Leffler", new DateTime(2024, 11, 27, 13, 42, 12, 982, DateTimeKind.Local).AddTicks(5204), "MinHacienda", "Johnnie.Leffler87@gmail.com", new DateTime(1978, 3, 13, 2, 49, 51, 106, DateTimeKind.Local).AddTicks(9328), "F", "Johnnie", 2 },
                    { 20, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Swift", new DateTime(2024, 11, 27, 13, 42, 12, 982, DateTimeKind.Local).AddTicks(5204), "MinHacienda", "Sherri_Swift@hotmail.com", new DateTime(1990, 8, 3, 22, 8, 19, 400, DateTimeKind.Local).AddTicks(6970), "F", "Sherri", 7 },
                    { 21, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Grimes", new DateTime(2024, 11, 27, 13, 42, 12, 982, DateTimeKind.Local).AddTicks(5204), "MinHacienda", "Kenneth_Grimes@gmail.com", new DateTime(1987, 9, 2, 5, 3, 51, 74, DateTimeKind.Local).AddTicks(6917), "F", "Kenneth", 7 },
                    { 22, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Daugherty", new DateTime(2024, 11, 27, 13, 42, 12, 982, DateTimeKind.Local).AddTicks(5204), "MinHacienda", "Woodrow.Daugherty@gmail.com", new DateTime(1987, 6, 2, 16, 16, 12, 257, DateTimeKind.Local).AddTicks(4107), "F", "Woodrow", 6 },
                    { 23, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Wuckert", new DateTime(2024, 11, 27, 13, 42, 12, 982, DateTimeKind.Local).AddTicks(5204), "MinHacienda", "Lucy.Wuckert13@hotmail.com", new DateTime(1980, 10, 31, 16, 37, 11, 481, DateTimeKind.Local).AddTicks(3173), "F", "Lucy", 7 },
                    { 24, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cummerata", new DateTime(2024, 11, 27, 13, 42, 12, 982, DateTimeKind.Local).AddTicks(5204), "MinHacienda", "Clarence.Cummerata41@hotmail.com", new DateTime(1983, 8, 9, 14, 34, 22, 198, DateTimeKind.Local).AddTicks(2200), "F", "Clarence", 9 },
                    { 25, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gulgowski", new DateTime(2024, 11, 27, 13, 42, 12, 982, DateTimeKind.Local).AddTicks(5204), "MinHacienda", "Kara_Gulgowski@yahoo.com", new DateTime(1956, 10, 22, 22, 23, 37, 507, DateTimeKind.Local).AddTicks(5339), "F", "Kara", 3 },
                    { 26, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hills", new DateTime(2024, 11, 27, 13, 42, 12, 982, DateTimeKind.Local).AddTicks(5204), "MinHacienda", "Kendra89@hotmail.com", new DateTime(1996, 11, 1, 20, 58, 9, 274, DateTimeKind.Local).AddTicks(3475), "F", "Kendra", 3 },
                    { 27, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ernser", new DateTime(2024, 11, 27, 13, 42, 12, 982, DateTimeKind.Local).AddTicks(5204), "MinHacienda", "Sylvester_Ernser@gmail.com", new DateTime(1956, 9, 6, 12, 22, 12, 153, DateTimeKind.Local).AddTicks(8021), "F", "Sylvester", 3 },
                    { 28, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Schuster", new DateTime(2024, 11, 27, 13, 42, 12, 982, DateTimeKind.Local).AddTicks(5204), "MinHacienda", "Chad73@yahoo.com", new DateTime(1964, 12, 26, 0, 24, 1, 771, DateTimeKind.Local).AddTicks(707), "F", "Chad", 8 },
                    { 29, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Zieme", new DateTime(2024, 11, 27, 13, 42, 12, 982, DateTimeKind.Local).AddTicks(5204), "MinHacienda", "Hugo_Zieme45@gmail.com", new DateTime(2003, 5, 26, 9, 7, 58, 926, DateTimeKind.Local).AddTicks(1523), "F", "Hugo", 7 },
                    { 30, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Zemlak", new DateTime(2024, 11, 27, 13, 42, 12, 982, DateTimeKind.Local).AddTicks(5204), "MinHacienda", "Joshua_Zemlak@hotmail.com", new DateTime(1983, 2, 1, 5, 35, 2, 265, DateTimeKind.Local).AddTicks(6648), "F", "Joshua", 7 }
                });

            migrationBuilder.InsertData(
                table: "inscripciones",
                columns: new[] { "InscripcionId", "Actualizado", "Creado", "CreadoPor", "CursoId", "EstudianteId", "FechaInscripcion" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 27, 13, 42, 12, 982, DateTimeKind.Local).AddTicks(5204), "MinHacienda", 1, 1, new DateTime(2022, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 27, 13, 42, 12, 982, DateTimeKind.Local).AddTicks(5204), "MinHacienda", 2, 2, new DateTime(2021, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 27, 13, 42, 12, 982, DateTimeKind.Local).AddTicks(5204), "MinHacienda", 3, 3, new DateTime(2020, 2, 9, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 27, 13, 42, 12, 982, DateTimeKind.Local).AddTicks(5204), "MinHacienda", 4, 4, new DateTime(2020, 3, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 27, 13, 42, 12, 982, DateTimeKind.Local).AddTicks(5204), "MinHacienda", 2, 5, new DateTime(2022, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 27, 13, 42, 12, 982, DateTimeKind.Local).AddTicks(5204), "MinHacienda", 4, 6, new DateTime(2020, 10, 24, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 27, 13, 42, 12, 982, DateTimeKind.Local).AddTicks(5204), "MinHacienda", 2, 7, new DateTime(2022, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 27, 13, 42, 12, 982, DateTimeKind.Local).AddTicks(5204), "MinHacienda", 2, 8, new DateTime(2021, 3, 28, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 27, 13, 42, 12, 982, DateTimeKind.Local).AddTicks(5204), "MinHacienda", 3, 9, new DateTime(2022, 9, 23, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 27, 13, 42, 12, 982, DateTimeKind.Local).AddTicks(5204), "MinHacienda", 1, 10, new DateTime(2021, 7, 30, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 11, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 27, 13, 42, 12, 982, DateTimeKind.Local).AddTicks(5204), "MinHacienda", 4, 11, new DateTime(2020, 9, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 12, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 27, 13, 42, 12, 982, DateTimeKind.Local).AddTicks(5204), "MinHacienda", 1, 12, new DateTime(2021, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 13, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 27, 13, 42, 12, 982, DateTimeKind.Local).AddTicks(5204), "MinHacienda", 3, 13, new DateTime(2021, 6, 7, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 14, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 27, 13, 42, 12, 982, DateTimeKind.Local).AddTicks(5204), "MinHacienda", 2, 14, new DateTime(2020, 7, 24, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 15, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 27, 13, 42, 12, 982, DateTimeKind.Local).AddTicks(5204), "MinHacienda", 1, 15, new DateTime(2021, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 16, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 27, 13, 42, 12, 982, DateTimeKind.Local).AddTicks(5204), "MinHacienda", 2, 16, new DateTime(2020, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 17, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 27, 13, 42, 12, 982, DateTimeKind.Local).AddTicks(5204), "MinHacienda", 2, 17, new DateTime(2020, 6, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 18, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 27, 13, 42, 12, 982, DateTimeKind.Local).AddTicks(5204), "MinHacienda", 3, 18, new DateTime(2021, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 19, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 27, 13, 42, 12, 982, DateTimeKind.Local).AddTicks(5204), "MinHacienda", 1, 19, new DateTime(2020, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 20, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 27, 13, 42, 12, 982, DateTimeKind.Local).AddTicks(5204), "MinHacienda", 1, 20, new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 21, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 27, 13, 42, 12, 982, DateTimeKind.Local).AddTicks(5204), "MinHacienda", 4, 21, new DateTime(2020, 7, 28, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 22, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 27, 13, 42, 12, 982, DateTimeKind.Local).AddTicks(5204), "MinHacienda", 1, 22, new DateTime(2020, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 23, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 27, 13, 42, 12, 982, DateTimeKind.Local).AddTicks(5204), "MinHacienda", 1, 23, new DateTime(2020, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 24, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 27, 13, 42, 12, 982, DateTimeKind.Local).AddTicks(5204), "MinHacienda", 4, 24, new DateTime(2021, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 25, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 27, 13, 42, 12, 982, DateTimeKind.Local).AddTicks(5204), "MinHacienda", 3, 25, new DateTime(2021, 12, 23, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 26, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 27, 13, 42, 12, 982, DateTimeKind.Local).AddTicks(5204), "MinHacienda", 2, 26, new DateTime(2022, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 27, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 27, 13, 42, 12, 982, DateTimeKind.Local).AddTicks(5204), "MinHacienda", 1, 27, new DateTime(2020, 11, 19, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 28, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 27, 13, 42, 12, 982, DateTimeKind.Local).AddTicks(5204), "MinHacienda", 1, 28, new DateTime(2021, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 29, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 27, 13, 42, 12, 982, DateTimeKind.Local).AddTicks(5204), "MinHacienda", 4, 29, new DateTime(2022, 5, 23, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 30, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 27, 13, 42, 12, 982, DateTimeKind.Local).AddTicks(5204), "MinHacienda", 3, 30, new DateTime(2022, 2, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) }
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
                name: "IX_estudiantes_UserId",
                table: "estudiantes",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_inscripciones_CursoId",
                table: "inscripciones",
                column: "CursoId");

            migrationBuilder.CreateIndex(
                name: "IX_inscripciones_EstudianteId",
                table: "inscripciones",
                column: "EstudianteId");

            migrationBuilder.CreateIndex(
                name: "IX_Sesion_UserID",
                table: "Sesion",
                column: "UserID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "asignaciones");

            migrationBuilder.DropTable(
                name: "inscripciones");

            migrationBuilder.DropTable(
                name: "Sesion");

            migrationBuilder.DropTable(
                name: "profesores");

            migrationBuilder.DropTable(
                name: "cursos");

            migrationBuilder.DropTable(
                name: "estudiantes");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
