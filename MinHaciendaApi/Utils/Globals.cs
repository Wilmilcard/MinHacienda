using System.Security.Cryptography;
using System.Text;

namespace MinHaciendaApi.Utils
{
    public class Globals
    {
        public static DateTime FechaActual() => DateTime.UtcNow.AddHours(-5);
        public static string UserSystem() => "Api MinHacienda";
    }
}
