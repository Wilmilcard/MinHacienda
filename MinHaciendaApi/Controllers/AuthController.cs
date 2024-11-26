using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MinHaciendaApi.HttpRequest;
using MinHaciendaApi.Interfaces;
using MinHaciendaDomain.DB;
using MinHaciendaDomain.Models;

namespace MinHaciendaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly MinHaciendaContext _context;
        private readonly IUserServices _userServices;
        private readonly IConfiguration _configuration;

        public AuthController(MinHaciendaContext context, IUserServices userServices, IConfiguration configuration) 
        {
            _context = context;
            _userServices = userServices;
            _configuration = configuration;
        }

        [HttpGet("[Action]")]
        public async Task<IActionResult> Test()
        {
            //var user = _userServices

            var response = new
            {
                succcess = true,
                data = "Proceso terminado"
            };

            return new OkObjectResult(response);
        }

        [HttpPost("[Action]")]
        public async Task<IActionResult> Create([FromBody] LoginRequest request)
        {
            var newUser = new User
            {
                Username = request.email,
                PasswordHash = Utils.Globals.MD5(request.password),
                Creado = Utils.Globals.FechaActual(),
                CreadoPor = Utils.Globals.UserSystem()
            };

            await _userServices.AddAsync(newUser);

            var response = new
            {
                succcess = true,
                data = "Proceso terminado"
            };

            return new OkObjectResult(response);
        }
    }
}
