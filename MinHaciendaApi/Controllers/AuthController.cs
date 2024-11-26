using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MinHaciendaApi.HttpRequest;
using MinHaciendaApi.Interfaces;
using MinHaciendaApi.Utils;
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

        [HttpPost("[Action]")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            if (string.IsNullOrEmpty(request.email) || string.IsNullOrEmpty(request.password))
                return new BadRequestObjectResult(new { success = false, data = "El usuario y/o contraseña estan vacios" });

            var user = _userServices.QueryNoTracking().Where(x => x.Username == request.email).FirstOrDefault();
            if (user == null)
                return new BadRequestObjectResult(new { success = false, data = "El usuario no se encuentra registrado" });

            var pass = Encrypt.MD5(request.password);
            
            //Tiempo de Token
            var expiration_date = Globals.FechaActual().AddHours(5).AddHours(8);//8 horas de vida para el token
            var jwtHelper = new JWTHelper(this._configuration.GetValue<string>("SecurityKey"));
            var token = jwtHelper.CreateToken(request.email, expiration_date);

            //Validamos la sesion
            var _sesion = _context.sesiones
                .Where(x => x.UserId == user.UserId)
                .FirstOrDefault();

            if (_sesion == null)
            {
                var sesion = new Sesion
                {
                    UserId = user.UserId,
                    Token = token,
                    Expiration_Date = expiration_date,
                    Creado = Globals.FechaActual(),
                    CreadoPor = Globals.UserSystem()
                };
                _context.sesiones.Add(sesion);

                user.Actualizado = Globals.FechaActual();
                await _userServices.UpdateAsync(user);
                
                _sesion = _context.sesiones.Where(x => x.UserId == user.UserId).FirstOrDefault();
            }
            else
            {
                _sesion.Token = token;
                _sesion.Expiration_Date = expiration_date;
                _sesion.Actualizado = Globals.FechaActual();
                _context.sesiones.Update(_sesion);
            }

            user.Actualizado = Globals.FechaActual();
            await _userServices.UpdateAsync(user);

            _context.SaveChanges();

            var response = new
            {
                success = true,
                data = new
                {
                    token,
                    sesion = new
                    {
                        user = _sesion.User.Username,
                        Mensaje = "Se logeo correctamente",
                    }
                },
            };

            return new OkObjectResult(response);
        }

        [HttpPost("[Action]")]
        public async Task<IActionResult> Create([FromBody] LoginRequest request)
        {
            var newUser = new User
            {
                Username = request.email,
                PasswordHash = Encrypt.MD5(request.password),
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
