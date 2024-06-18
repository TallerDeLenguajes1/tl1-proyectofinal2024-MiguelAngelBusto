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
}