using System.Security.Cryptography;
using System.Text;

namespace MinHaciendaApi.Utils
{
    public class Globals
    {
        public static DateTime FechaActual() => DateTime.UtcNow.AddHours(-5);
        public static string UserSystem() => "Api MinHacienda";

        //Encrypt
        public static string MD5(string password)
        {
            string serializar, rpta;

            byte[] encodedPassword = new UTF8Encoding().GetBytes(password);
            byte[] hash = ((HashAlgorithm)CryptoConfig.CreateFromName("MD5")).ComputeHash(encodedPassword);
            string encoded = BitConverter.ToString(hash).Replace("-", string.Empty).ToUpper();

            serializar = serialize(encoded);
            rpta = encoded.Substring(0, 16) + serializar;

            return rpta;
        }

        private static string serialize(string cadena)
        {
            string rpta;

            byte[] encodedPassword = new UTF8Encoding().GetBytes(cadena);
            byte[] hash = ((HashAlgorithm)CryptoConfig.CreateFromName("MD5")).ComputeHash(encodedPassword);
            string encoded = BitConverter.ToString(hash).Replace("-", string.Empty).ToUpper();
            rpta = encoded.Substring(0, 16);
            return rpta;

        }
        //
    }
}
