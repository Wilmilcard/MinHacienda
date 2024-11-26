using MinHaciendaApi.Interfaces;
using MinHaciendaApi.Services;

namespace MinHaciendaApi
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddCustomizedServicesProject(this IServiceCollection services)
        {
            services.AddScoped<IUserServices, UserServices>();
            services.AddScoped<IEstudianteServices, EstudianteServices>();

            return services;
        }
    }
}
