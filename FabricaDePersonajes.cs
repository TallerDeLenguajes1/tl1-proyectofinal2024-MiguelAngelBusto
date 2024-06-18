namespace personajes;

public class FabricaDePersonajes {

    public Personaje Fabricar(){

    var seed = Environment.TickCount;
    var random = new Random(seed);

    Datos pokemon = new Datos((Cargos)random.Next(0,3),"Rival 1","Rival 1",DateTime.Now,random.Next(18,40));

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

}