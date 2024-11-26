using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MinHaciendaDomain.DB;

namespace MinHaciendaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly MinHaciendaContext _context;

        public AuthController(MinHaciendaContext context)
        {
            _context = context;
        }

        [HttpGet("[Action]")]
        public async Task<IActionResult> Test()
        {
            var cero = 0;
            var num = 10 / cero;

            var response = new
            {
                succcess = true,
                data = "Proceso terminado"
            };

            return new OkObjectResult(response);
        }
    }
}
