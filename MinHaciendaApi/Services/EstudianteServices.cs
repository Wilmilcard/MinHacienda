using MinHaciendaApi.Interfaces;
using MinHaciendaDomain.Models;
using MinHaciendaDomain.Repository;

namespace MinHaciendaApi.Services
{
    public class EstudianteServices : BaseRepository<Estudiante>, IEstudianteServices
    {
        public EstudianteServices(IRepository<Estudiante> repository) : base(repository)
        {
        }
    }
}
