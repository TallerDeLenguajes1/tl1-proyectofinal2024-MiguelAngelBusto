using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
namespace personajes;

public class FabricaDePersonajes {

    Rivales fileLoader = new Rivales();

    List<string> datosCargados;

    public Personaje Fabricar(){

    var seed = Environment.TickCount;
    var random = new Random(seed);
    datosCargados = fileLoader.CargarDatos();

     Datos pokemon = new Datos((Cargos)random.Next(0, 3), datosCargados[random.Next(0,9)],"Rival 1",DateTime.Now,random.Next(18,40));

    Caracteristicas carac = new Caracteristicas(random.Next(1,11),random.Next(1,5),random.Next(1,11),random.Next(1,11),random.Next(1,11),100);

    Personaje final = new Personaje(pokemon,carac);
    return final;
    }

    public Personaje Fabricar (Cargos cargo, string Nombre,String Apodo,DateTime fecha, int edad){
        Datos aux = new Datos(cargo,Nombre,Apodo,fecha,edad);
        Personaje aux2 = Fabricar();
        aux2.DatoPersonaje = aux;
        return aux2;
    }

    public Personaje Fabricar (Cargos cargo, string Nombre,String Apodo,DateTime fecha, int edad,int combate){
        Datos aux = new Datos(cargo,Nombre,Apodo,fecha,edad);
        Personaje aux2 = Fabricar();
        aux2.DatoPersonaje = aux;
        aux2.Combates=combate;
        return aux2;
    }

}