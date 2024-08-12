using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace personajes
{
    public class ServicioApi
    {
        private readonly string _url = "https://api.generadordni.es/v2/person/username";
        private const string FilePath = "nombres.json";

        public async Task ObtenerDatosAsync()
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync(_url);
                    response.EnsureSuccessStatusCode();
                    string json = await response.Content.ReadAsStringAsync();

                    // Guardar los datos en nombres.json
                    File.WriteAllText(FilePath, json);
                    Console.WriteLine("Datos guardados en 'nombres.json'.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error al obtener los datos: {ex.Message}");
                    
                    // Crear una lista de 10 nombres aleatorios
                    var randomNames = GenerateRandomNames(10);
                    string fallbackJson = JsonSerializer.Serialize(randomNames);

                    // Guardar la lista de nombres aleatorios en nombres.json
                    File.WriteAllText(FilePath, fallbackJson);
                    Console.WriteLine("Datos de respaldo guardados en 'nombres.json'.");
                }
            }
        }

        private List<string> GenerateRandomNames(int count)
        {
            var names = new List<string>
            {
                "Ana", "Luis", "Carlos", "Maria", "Jose",
                "Elena", "Pedro", "Laura", "Javier", "Marta"
            };
            return names.OrderBy(x => Guid.NewGuid()).Take(count).ToList();
        }
    }
}
