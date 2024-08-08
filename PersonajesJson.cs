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
        string filePath = "PartidasGuardas.txt";
        File.WriteAllText(filePath,jsonString);
        System.Console.WriteLine("Guardado con exito");
    }

    public Personaje Cargar(){
        string filePath = "PartidasGuardas.txt";
        string jsonString = File.ReadAllText(filePath);
        Personaje personaje = JsonSerializer.Deserialize<Personaje>(jsonString);
        return personaje;
    }

public void Guardar(Personaje aux, string ubi) {
    try {
        // Serializar el objeto Personaje a una cadena JSON
        string jsonString = JsonSerializer.Serialize(aux);
        
        // Abrir el archivo para añadir datos (append)
        using (StreamWriter sw = File.AppendText(ubi)) {
            // Escribir la cadena JSON al archivo
            sw.WriteLine(jsonString);
        }
        
        // Confirmación de guardado exitoso
        System.Console.WriteLine("Guardado con éxito en: " + ubi);
    } catch (Exception ex) {
        // Manejo de errores
        System.Console.WriteLine($"Error al guardar el personaje: {ex.Message}");
    }
}

public List<Personaje> CargarCampeones(string ubi) {
    List<Personaje> personajes = new List<Personaje>();

    // Verificar si el archivo existe
    if (!File.Exists(ubi)) {
        System.Console.WriteLine("Archivo no encontrado: " + ubi);
        return personajes;
    }

    try {
        // Leer todas las líneas del archivo
        string[] lines = File.ReadAllLines(ubi);
        System.Console.WriteLine("Archivo leído correctamente. Número de líneas: " + lines.Length);

        // Deserializar cada línea a un objeto Personaje
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
        // Manejo de errores
        System.Console.WriteLine($"Error al cargar los personajes: {ex.Message}");
        return new List<Personaje>();
    }
}
}