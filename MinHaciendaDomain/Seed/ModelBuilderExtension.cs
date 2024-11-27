using Bogus;
using Bogus.Extensions.UnitedKingdom;
using Microsoft.EntityFrameworkCore;
using MinHaciendaDomain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MinHaciendaDomain.Seed
{
    public static class ModelBuilderExtension
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            var system = "MinHacienda";
            var fecha = DateTime.Now;
            var id = 1;
            var random = new Random();

            #region Profesores
            var fakerProfesores = new Bogus.Faker<Profesor>()
                .RuleFor(x => x.ProfesorId, f => id++)
                .RuleFor(x => x.Nombre, f => f.Person.FirstName)
                .RuleFor(x => x.Apellido, f => f.Person.LastName)
                .RuleFor(x => x.Email, f => f.Person.Email)
                .RuleFor(x => x.Departamento, f => f.Lorem.Word())
                .RuleFor(x => x.CreadoPor, f => system)
                .RuleFor(x => x.Creado, f => fecha);

            var listProfesores = fakerProfesores.Generate(20);
            foreach (var p in listProfesores)
                modelBuilder.Entity<Profesor>().HasData(p);
            #endregion

            #region Users
            id = 1;
            var fakerUser = new Bogus.Faker<User>()
                .RuleFor(x => x.UserId, f => id++)
                .RuleFor(x => x.Username, (f, u) => f.Internet.UserName("nombre", $"apellido_{id}"))
                .RuleFor(x => x.PasswordHash, f => Encrypt.MD5("juan"))
                .RuleFor(x => x.CreadoPor, f => system)
                .RuleFor(x => x.Creado, f => fecha);

            var listUsers = fakerUser.Generate(10);
            foreach (var u in listUsers)
                modelBuilder.Entity<User>().HasData(u);
            #endregion

            #region Estudiantes
            id = 1;
            var fakerEstudiantes = new Bogus.Faker<Estudiante>()
                .RuleFor(x => x.EstudianteId, f => id++)
                .RuleFor(x => x.Nombre, f => f.Person.FirstName)
                .RuleFor(x => x.Apellido, f => f.Person.LastName)
                .RuleFor(x => x.Email, f => f.Person.Email)
                .RuleFor(x => x.Genero, f => random.Next(0,1) == 1 ? "M" : "F")
                .RuleFor(x => x.FechaNacimiento, f => f.Person.DateOfBirth)
                .RuleFor(x => x.UserId, f => random.Next(1,10))
                .RuleFor(x => x.CreadoPor, f => system)
                .RuleFor(x => x.Creado, f => fecha);

            var listEstudiantes = fakerEstudiantes.Generate(30);
            foreach (var e in listEstudiantes)
                modelBuilder.Entity<Estudiante>().HasData(e);
            #endregion


            #region Curso
            var listCursos = new List<Curso>()
            {
                new Curso
                {
                    CursoId = 1,
                    Nombre = "Programacion",
                    Codigo = "POO",
                    Creditos = 25,
                    CreadoPor = system,
                    Creado = fecha
                },
                new Curso
                {
                    CursoId = 2,
                    Nombre = "Ingles",
                    Codigo = "ING",
                    Creditos = 15,
                    CreadoPor = system,
                    Creado = fecha
                },
                new Curso
                {
                    CursoId = 3,
                    Nombre = "Calculo II",
                    Codigo = "CAL",
                    Creditos = 20,
                    CreadoPor = system,
                    Creado = fecha
                },
                new Curso
                {
                    CursoId = 4,
                    Nombre = "Arquitectura",
                    Codigo = "ARQ",
                    Creditos = 25,
                    CreadoPor = system,
                    Creado = fecha
                },
                new Curso
                {
                    CursoId = 5,
                    Nombre = "Seguridad",
                    Codigo = "SEG",
                    Creditos = 30,
                    CreadoPor = system,
                    Creado = fecha
                }
            };

            //id = 1;
            //var fakerCurso = new Bogus.Faker<Curso>()
            //    .RuleFor(x => x.CursoId, f => id++)
            //    .RuleFor(x => x.Nombre, f => f.Lorem.Word())
            //    .RuleFor(x => x.Codigo, f => f.Lorem.Word())
            //    .RuleFor(x => x.Creditos, f => random.Next(10, 50))
            //    .RuleFor(x => x.CreadoPor, f => system)
            //    .RuleFor(x => x.Creado, f => fecha);

            
            foreach (var c in listCursos)
                modelBuilder.Entity<Curso>().HasData(c);
            #endregion

            
            #region Asignacion
            id = 1;
            foreach(var p in listProfesores)
            {
                var fakerAsignacion = new Asignacion
                {
                    AsignacionId = id++,
                    ProfesorId = p.ProfesorId,
                    CursoId = random.Next(1,listCursos.Count),
                    Semestre = random.Next(1,10),
                    CreadoPor = system,
                    Creado = fecha
                };

                modelBuilder.Entity<Asignacion>().HasData(fakerAsignacion);
            }
            #endregion

            #region Inscripcion
            id = 1;
            foreach (var e in listEstudiantes)
            {
                var fakerInscripcion = new Inscripcion
                {
                    InscripcionId = id++,
                    EstudianteId = e.EstudianteId,
                    CursoId = random.Next(1, listCursos.Count),
                    FechaInscripcion = new DateTime(2020, 1, 1).AddDays(random.Next(1, 1000)),
                    CreadoPor = system,
                    Creado = fecha
                };

                modelBuilder.Entity<Inscripcion>().HasData(fakerInscripcion);
            }
            #endregion
        }

    }
}
