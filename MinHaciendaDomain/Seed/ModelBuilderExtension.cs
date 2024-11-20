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

            //modelBuilder.Entity<Profesor>().HasData(
            //    new Profesor
            //    {
            //        ProfesorId = 1,
            //        Nombre = "Juan",
            //        Apellido = "Leon",
            //        Email = "jleon@asesoftware.com",
            //        Departamento = "Ingenieria",
            //        CreadoPor = system,
            //        Creado = fecha
            //    },
            //    new Profesor
            //    {
            //        ProfesorId = 2,
            //        Nombre = "Eduard",
            //        Apellido = "Gutierrez",
            //        Email = "egutierrez@asesoftware.com",
            //        Departamento = "Ciencias",
            //        CreadoPor = system,
            //        Creado = fecha
            //    }
            //);

            var fakerProfesores = new Bogus.Faker<Profesor>()
                .RuleFor(x => x.ProfesorId, f => id++)
                .RuleFor(x => x.Nombre, f => f.Person.FirstName)
                .RuleFor(x => x.Apellido, f => f.Person.LastName)
                .RuleFor(x => x.Email, f => f.Person.Email)
                .RuleFor(x => x.Departamento, f => f.Lorem.Word())
                .RuleFor(x => x.CreadoPor, f => system)
                .RuleFor(x => x.Creado, f => fecha);

            foreach (var p in fakerProfesores.Generate(50))
                modelBuilder.Entity<Profesor>().HasData(p);
        }

    }
}
