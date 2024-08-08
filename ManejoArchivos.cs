using System.IO;
namespace archivo;

public enum FileMode {
    CreateNew,
    Create,
    Open,
    OpenOrCreate,
    Truncate,
    Append
}


public class ManejoArchivos {
    string ruta = "../Archivo/personajes.txt";

/*public Cargar (){
    String line;
    try
    {
        StreamReader sr = new StreamReader(ruta);
        line = sr.ReadLine();
        while (line != null)
        {
            Console.WriteLine(line);
            line = sr.ReadLine();
        }
        sr.Close();
        Console.ReadLine();
    }
    catch(Exception e)
    {
        Console.WriteLine("Excepcion: " + e.Message);
    }
    finally
    {
        Console.WriteLine("Ejecutando bloque final.");
    }
    }
}

public Guardar(){
    try
    {
        StreamWriter sw = new StreamWriter(ruta);
        //Deberia mandar el json para que guarde;
        sw.WriteLine("Lo que desea guardar");
        sw.Close();
    }
    catch(Exception e)
    {
        Console.WriteLine("Excepcion: " + e.Message);
    }
    finally
    {
        Console.WriteLine("Ejecutando bloque final.");
    }
}
*/
}

/*
Preguntas:
1) Al leer un archivo, puedo ir a una linea especifica?, que funcion deberia utilizar y que parametros utilizaria.
2) Podemos utilizar/crear algun tipo de interfaz?
3) Hacer un diagrama de clases y sus relaciones.
*/

