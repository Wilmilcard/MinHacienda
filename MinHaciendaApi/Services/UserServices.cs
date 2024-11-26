using MinHaciendaApi.Interfaces;
using MinHaciendaDomain.Models;
using MinHaciendaDomain.Repository;

namespace MinHaciendaApi.Services
{
    public class UserServices : BaseRepository<User>, IUserServices
    {
        public UserServices(IRepository<User> repository) : base(repository)
        {
        }
    }
}
