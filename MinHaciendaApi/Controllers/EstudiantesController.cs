using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using Azure.Core;
using Microsoft.AspNetCore.Authorization;
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
    //[AllowAnonymous]
    [Authorize]
    public class EstudiantesController : ControllerBase
    {
        private readonly MinHaciendaContext _context;

        public EstudiantesController(MinHaciendaContext context)
        {
            _context = context;
        }

        [AllowAnonymous]
        [HttpGet("[Action]")]
        public async Task<IActionResult> GetEstudiantes()
        {
            try
            {
                var rpta = _context.estudiantes
                    .Select(x => new
                    {
                        x.EstudianteId,
                        nombre = $"{x.Nombre} {x.Apellido}",
                        x.FechaNacimiento,
                        x.Email
                    })
                    .OrderByDescending(x => x.EstudianteId)
                    .ToList();

                var response = new
                {
                    succcess = true,
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

        [HttpGet("[Action]/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var rpta = _context.estudiantes
                    .Select(x => new
                    {
                        x.EstudianteId,
                        nombre = $"{x.Nombre} {x.Apellido}",
                        x.FechaNacimiento,
                        x.Email
                    })
                    .Where(x => x.EstudianteId == id)
                    .FirstOrDefault();

                var response = new
                {
                    succcess = true,
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

        [HttpGet("[Action]/{name}")]
        public async Task<IActionResult> GetByName([FromRoute] string name)
        {
            try
            {
                var rpta = _context.estudiantes
                    .Where(x => (x.Nombre).Contains(name))
                    .Select(x => new
                    {
                        x.EstudianteId,
                        nombre = $"{x.Nombre} {x.Apellido}",
                        x.FechaNacimiento,
                        x.Email
                    })
                    .ToList();

                var response = new
                {
                    succcess = true,
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

        [HttpPost("[Action]")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            try
            {
                if (request == null)
                    return BadRequest();

                var user = _context.estudiantes.Where(x => x.Email == request.email).FirstOrDefault();

                if (user == null)
                    return new BadRequestObjectResult(new { error = "Usuario no existe" });

                var response = new
                {
                    succcess = true,
                    data = "Login Exitoso"
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

        [HttpPut("[Action]/{id}")]
        public async Task<IActionResult> ActualizarEstudiante([FromRoute] int id, [FromBody] Estudiante request)
        {
            if (id != request.EstudianteId)
                return new BadRequestObjectResult(new { error = "Usuario no existe" });

            try
            {
                request.Actualizado = Utils.Globals.FechaActual();
                _context.estudiantes.Update(request);
                await _context.SaveChangesAsync();

                var response = new
                {
                    succcess = true,
                    data = $"Estudiante {request.Email} actualizado"
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

        [HttpPatch("[Action]")]
        public async Task<IActionResult> ActualizarEstudiantePatch([FromBody] EstudianteRequest request)
        {
            var estudiante = _context.estudiantes.Where(x => x.EstudianteId == request.EstudianteId).FirstOrDefault();

            if (estudiante == null)
                return new BadRequestObjectResult(new { error = "Usuario no existe" });

            if (request.Nombre != estudiante.Apellido)
                estudiante.Nombre = request.Nombre;
            if (request.Apellido != estudiante.Apellido)
                estudiante.Apellido = request.Apellido;
            if (request.FechaNacimiento != estudiante.FechaNacimiento)
                estudiante.FechaNacimiento = request.FechaNacimiento;
            if (request.Genero != estudiante.Genero)
                estudiante.Genero = request.Genero;
            if (request.Email != estudiante.Email)
                estudiante.Email = request.Email;

            estudiante.Actualizado = Utils.Globals.FechaActual();

            try
            {
                _context.estudiantes.Update(estudiante);
                await _context.SaveChangesAsync();

                var response = new
                {
                    succcess = true,
                    data = $"Estudiante {request.Email} actualizado"
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


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEstudiante(int id)
        {
            var estudiante = await _context.estudiantes.FindAsync(id);
            if (estudiante == null)
                return NotFound();

            using (var transaccion = _context.Database.BeginTransaction())
            {
                _context.estudiantes.Remove(estudiante);
                await _context.SaveChangesAsync();

                if(estudiante.Email == "Erma11@yahoo.com")
                {
                    transaccion.Rollback();
                    return new BadRequestObjectResult(new { error = "Usuario no fue borrado" });
                }

                transaccion.Commit();
            }


            var response = new
            {
                succcess = true,
                data = $"Estudiante {estudiante.Email} eliminado"
            };

            return new OkObjectResult(response);
        }

    }
}
