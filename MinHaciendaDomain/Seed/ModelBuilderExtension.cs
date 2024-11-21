using Bogus.Extensions.UnitedKingdom;
using Microsoft.EntityFrameworkCore;
using MinHaciendaDomain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            #region Estudiantes
            id = 1;
            var fakerEstudiantes = new Bogus.Faker<Estudiante>()
                .RuleFor(x => x.EstudianteId, f => id++)
                .RuleFor(x => x.Nombre, f => f.Person.FirstName)
                .RuleFor(x => x.Apellido, f => f.Person.LastName)
                .RuleFor(x => x.Email, f => f.Person.Email)
                .RuleFor(x => x.Genero, f => random.Next(0,1) == 1 ? "M" : "F")
                .RuleFor(x => x.FechaNacimiento, f => f.Person.DateOfBirth)
                .RuleFor(x => x.CreadoPor, f => system)
                .RuleFor(x => x.Creado, f => fecha);

            var listEstudiantes = fakerEstudiantes.Generate(500);
            foreach (var e in listEstudiantes)
                modelBuilder.Entity<Estudiante>().HasData(e);
            #endregion

            /*
            #region Curso
            id = 1;
            var fakerCurso = new Bogus.Faker<Curso>()
                .RuleFor(x => x.CursoId, f => id++)
                .RuleFor(x => x.Nombre, f => f.Lorem.Word())
                .RuleFor(x => x.Codigo, f => f.Lorem.Word())
                .RuleFor(x => x.Creditos, f => random.Next(10, 50))
                .RuleFor(x => x.CreadoPor, f => system)
                .RuleFor(x => x.Creado, f => fecha);

            var listCursos = fakerCurso.Generate(5);
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

                modelBuilder.Entity<Curso>().HasData(fakerAsignacion);
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
                    FechaInscripcion = new DateTime(2020,1,1).AddDays(random.Next(1,1000)),
                    CreadoPor = system,
                    Creado = fecha
                };

                modelBuilder.Entity<Curso>().HasData(fakerInscripcion);
            }
            #endregion
            */
        }

    }
}
