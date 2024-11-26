using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using MinHaciendaDomain.Models;
using MinHaciendaDomain.Seed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinHaciendaDomain.DB
{
    public class MinHaciendaContext : DbContext
    {
        public MinHaciendaContext(DbContextOptions<MinHaciendaContext> options) : base(options)
        {

        }

        public DbSet<Asignacion> asignaciones { get; set; }
        public DbSet<Curso> cursos { get; set; }
        public DbSet<Estudiante> estudiantes { get; set; }
        public DbSet<Inscripcion> inscripciones { get; set; }
        public DbSet<Profesor> profesores { get; set; }
        public DbSet<User> usuarios { get; set; }
        public DbSet<Sesion> sesiones { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Seed();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .ConfigureWarnings(warnings => warnings
                    .Log(RelationalEventId.PendingModelChangesWarning));
        }
    }
}
