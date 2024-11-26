
using Newtonsoft.Json;
using NuGet.Packaging.Licenses;
using System.Net;

namespace MinHaciendaApi.Utils
{
    public class GlobalExceptionHandler : IMiddleware
    {
        private ILogger<GlobalExceptionHandler> _logger;
        public GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger)
        {
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                string msg = ex.Message.ToString();
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                _logger.LogError($"Error personalizado: {msg}");

                var response = new
                {
                    succcess = false,
                    juan = "Mensaje interno",
                    data = msg,
                    status = (int)HttpStatusCode.InternalServerError
                };

                await context.Response.WriteAsync(JsonConvert.SerializeObject(response));
            }
        }
    }
}
