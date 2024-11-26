using Microsoft.EntityFrameworkCore;
using MinHaciendaApi.Utils;
using MinHaciendaDomain;
using MinHaciendaDomain.DB;
using System;

namespace MinHaciendaApi
{
    public class Startup
    {
        public IConfiguration _Configuration;
        public Startup(IConfiguration configuration)
        {
            this._Configuration = configuration;
        }

        public static WebApplication InitializarApp(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            ConfigureServices(builder);
            var app = builder.Build();
            Configure(app);
            return app;
        }

        public static void ConfigureServices(WebApplicationBuilder builder)
        {
            // Crear variable de conexion
            builder.Services.AddCustomizedDataStore(builder.Configuration);
            builder.Services.AddCustomizedRepository();

            //Global Exceptions
            builder.Services.AddTransient<GlobalExceptionHandler>();

            builder.Services.AddControllers();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
        }

        public static void Configure(WebApplication app)
        {
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseMiddleware<GlobalExceptionHandler>();

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();
        }
    }
}
