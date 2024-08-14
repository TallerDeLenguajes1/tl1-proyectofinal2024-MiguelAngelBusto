using personajes;
namespace archivo;
using System.IO;
using System.Text.Json;

public class PersonajesJson {
    
    Personaje aux;

    public PersonajesJson()
    {
    }

    public void Guardar (Personaje aux){
        string jsonString = JsonSerializer.Serialize(aux);
        string filePath = "PartidasGuardas.json";
        File.WriteAllText(filePath,jsonString);
        System.Console.WriteLine("Guardado con exito");
    }

    public Personaje Cargar(){
        string filePath = "PartidasGuardas.json";
        string jsonString = File.ReadAllText(filePath);
        Personaje personaje = JsonSerializer.Deserialize<Personaje>(jsonString);
        return personaje;
    }

public void Guardar(Personaje aux, string ubi) {
    try {
        string jsonString = JsonSerializer.Serialize(aux);
        
        using (StreamWriter sw = File.AppendText(ubi)) {
            sw.WriteLine(jsonString);
        }
        System.Console.WriteLine("Guardado con éxito en: " + ubi);
    } catch (Exception ex) {
        System.Console.WriteLine($"Error al guardar el personaje: {ex.Message}");
    }
}

public List<Personaje> CargarCampeones(string ubi) {
    List<Personaje> personajes = new List<Personaje>();
    if (!File.Exists(ubi)) {
        System.Console.WriteLine("Archivo no encontrado: " + ubi);
        return personajes;
    }

    try {
        string[] lines = File.ReadAllLines(ubi);
        System.Console.WriteLine("Archivo leído correctamente. Número de líneas: " + lines.Length);
        foreach (string line in lines) {
            if (!string.IsNullOrWhiteSpace(line)) {
                try {
                    Personaje personaje = JsonSerializer.Deserialize<Personaje>(line);
                    personajes.Add(personaje);
                } catch (JsonException ex) {
                    System.Console.WriteLine("Error de deserialización en la línea: " + line);
                    System.Console.WriteLine("Mensaje de error: " + ex.Message);
                }
            }
        }

        if (personajes.Count == 0) {
            System.Console.WriteLine("No se encontraron personajes en el archivo.");
        }

        return personajes;
    } catch (Exception ex) {
        System.Console.WriteLine($"Error al cargar los personajes: {ex.Message}");
        return new List<Personaje>();
    }

}
    public List<string> CargarListaDeStrings()
    {
        try
        {
            using (StreamReader reader = new StreamReader("nombres.json"))
            {
                string jsonString = reader.ReadToEnd();
                List<string> lista = JsonSerializer.Deserialize<List<string>>(jsonString);
                
                if (lista == null)
                {
                    throw new InvalidOperationException("El archivo está vacío o no se pudo deserializar la lista.");
                }

                return lista;
            }
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("El archivo no se encontró.");
            return new List<string>(); // Retorna una lista vacía en caso de error
        }
        catch (JsonException)
        {
            Console.WriteLine("El archivo no contiene datos válidos.");
            return new List<string>(); // Retorna una lista vacía en caso de error
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al cargar el archivo: {ex.Message}");
            return new List<string>(); // Retorna una lista vacía en caso de error
        }
    }
}