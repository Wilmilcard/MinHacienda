using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MinHaciendaApi.HttpRequest;
using MinHaciendaApi.Utils;
using MinHaciendaDomain.DB;
using MinHaciendaDomain.Models;

namespace MinHaciendaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstudiantesController : ControllerBase
    {
        private readonly MinHaciendaContext _context;

        public EstudiantesController(MinHaciendaContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Estudiante>>> GetEstudiantes()
        {
            return await _context.estudiantes.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Estudiante>> GetEstudiante(int id)
        {
            var estudiante = await _context.estudiantes.FindAsync(id);

            if (estudiante == null)
            {
                return NotFound();
            }

            return estudiante;
        }
                
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEstudiante(int id, Estudiante estudiante)
        {
            if (id != estudiante.EstudianteId)
            {
                return BadRequest();
            }

            _context.Entry(estudiante).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EstudianteExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpPost("[Action]")]
        public async Task<IActionResult> Create([FromBody] EstudianteRequest request)
        {
            try
            {
                if (request == null)
                    return BadRequest();

                using (var transaccion = _context.Database.BeginTransaction())
                {
                    var NuevoEstudiante = new Estudiante
                    {
                        Nombre = request.Nombre,
                        Apellido = request.Apellido,
                        Email = request.Email,
                        Genero = request.Genero,
                        FechaNacimiento = request.FechaNacimiento,
                        Creado = Globals.FechaActual(),
                        CreadoPor = Globals.UserSystem()
                    };

                    await _context.estudiantes.AddAsync(NuevoEstudiante);
                    _context.SaveChanges();

                    transaccion.Commit();
                }

                var response = new
                {
                    succcess = true,
                    data = "Insertado Correctamente"
                };

                return new OkObjectResult(response);
            }
            catch (Exception ex)
            {
                var response = new
                {
                    succcess = false,
                    error = ex.Message,
                    errorCode = ex.HResult,
                    stackTrace = ex.StackTrace // Agregar el stack trace
                };

                return new BadRequestObjectResult(response);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEstudiante(int id)
        {
            var estudiante = await _context.estudiantes.FindAsync(id);
            if (estudiante == null)
            {
                return NotFound();
            }

            _context.estudiantes.Remove(estudiante);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EstudianteExists(int id)
        {
            return _context.estudiantes.Any(e => e.EstudianteId == id);
        }
    }
}
