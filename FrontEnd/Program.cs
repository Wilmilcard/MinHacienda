//using System;
//using System.Threading.Tasks;
//using OpenAI_API;
//using OpenAI_API.Completions;
//using System.Threading;

using FrontEnd.HttpResponse;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        string apiUrl = "http://localhost:5069/api/Estudiantes/GetEstudiantes";

        using (HttpClient client = new HttpClient())
        {
            HttpResponseMessage response = await client.GetAsync(apiUrl);

            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();

                var responseObject = JsonConvert.DeserializeObject<ResponseApi>(responseBody);

                Console.WriteLine("Respuesta de la API:");
                Console.WriteLine("");
                var listEstudiantes = responseObject.data;

                foreach (var e in listEstudiantes)
                {
                    Console.WriteLine($"{e.nombre} - {e.email}");
                    if (listEstudiantes.Where(x => x.email == "Kara_Gulgowski@yahoo.com").FirstOrDefault() != null)
                    {
                        Console.WriteLine("EUREKAAAAA");
                        break;
                    }
                }

                
            }
            else
            {
                Console.WriteLine("Error en la solicitud. Código de estado: " + response.StatusCode);
            }
            Console.ReadLine();
        }

        //var apiKey = "Su-api-key";  // Sustituir por tu clave API
        //var openAI = new OpenAIAPI(apiKey);

        //var prompt = "Hola, ¿cómo estás?";

        //var request = new CompletionRequest
        //{
        //    Prompt = prompt,
        //    MaxTokens = 50, 
        //    Temperature = 0.7 
        //};

        //int retryCount = 0;
        //bool success = false;

        //while (!success && retryCount < 3)  
        //{
        //    try
        //    {
        //        var result = await openAI.Completions.CreateCompletionAsync(request);
        //        Console.WriteLine($"Respuesta de OpenAI: {result.Completions[0].Text}");
        //        success = true;  // Si la solicitud es exitosa, salimos del bucle
        //    }
        //    catch (Exception ex)
        //    {
        //        if (ex.Message.Contains("TooManyRequests"))
        //        {
        //            retryCount++;
        //            Console.WriteLine($"Error al hacer la solicitud a la API: {ex.Message}. Intentando de nuevo en 10 segundos...");
        //            Thread.Sleep(10000);  
        //        }
        //        else
        //        {
        //            Console.WriteLine($"Error: {ex.Message}");
        //            break;
        //        }
        //    }
        //}

        //if (!success)
        //{
        //    Console.WriteLine("No se pudo realizar la solicitud después de varios intentos.");
        //}
    }
}
