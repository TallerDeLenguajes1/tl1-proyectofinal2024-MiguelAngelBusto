using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using static System.Net.WebRequestMethods;
namespace personajes
{
    public class ServicioApi
    {
        string _url = "https://api.generadordni.es/v2/person/username";

        public async Task<string[]> ObtenerDatosAsync()
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync(_url);
                    response.EnsureSuccessStatusCode();
                    string json = await response.Content.ReadAsStringAsync();
                    return System.Text.Json.JsonSerializer.Deserialize<string[]>(json);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error al obtener los datos: {ex.Message}");
                    return Array.Empty<string>();
                }
            }
        }
    }
}