using Microsoft.EntityFrameworkCore;
using MinHaciendaDomain.Models;
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

        public DbSet<Asignacion> Asignaciones { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Estudiante> Estudiantes { get; set; }
        public DbSet<Inscripcion> Inscripciones { get; set; }
        public DbSet<Profesor> Profesores { get; set; }
    }
}
