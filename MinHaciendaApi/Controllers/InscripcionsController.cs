using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MinHaciendaDomain.DB;
using MinHaciendaDomain.Models;

namespace MinHaciendaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class InscripcionsController : ControllerBase
    {
        private readonly MinHaciendaContext _context;

        public InscripcionsController(MinHaciendaContext context)
        {
            _context = context;
        }

        [AllowAnonymous]
        [HttpGet("[Action]/{page}/{cant}")]
        public async Task<IActionResult> GetInscripciones([FromRoute] int page, [FromRoute] int cant)
        {
            try
            {
                
                int pageNumber = page; 
                int pageSize = cant;

                var totalRecords = _context.inscripciones;
                var totalPages = (int)Math.Ceiling((double)totalRecords.Count() / pageSize);

                var rpta = totalRecords
                    .Include(e => e.Estudiante)
                        .ThenInclude(u => u.User)
                    .Include(x => x.Curso)
                    .Select(x => new
                    {
                        x.Estudiante.EstudianteId,
                        x.Estudiante.Nombre,
                        x.Estudiante.Apellido,
                        Curso = new
                        {
                            x.Curso.Nombre,
                            x.Curso.Codigo,
                            x.Curso.Creditos
                        },
                        sesion = new
                        {
                            x.Estudiante.User.Username,
                            x.Estudiante.User.PasswordHash,
                        }
                    })
                    .OrderByDescending(x => x.EstudianteId)
                    .Skip((pageNumber - 1) * pageSize) 
                    .Take(pageSize)
                    .ToList();

                var response = new
                {
                    succcess = true,
                    page = $"{pageNumber}/{totalPages}",
                    data = rpta
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
                    stackTrace = ex.StackTrace
                };

                return new BadRequestObjectResult(response);
            }
        }

    }
}
