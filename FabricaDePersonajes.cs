namespace personajes;

public class FabricaDePersonajes {

    public Personaje Fabricar(){

    var seed = Environment.TickCount;
    var random = new Random(seed);

    Datos pokemon = new Datos(Cargos.Fuego,"Rival 1","Rival 1",DateTime.Now,random.Next(18,40));

    Caracteristicas carac = new Caracteristicas(random.Next(1,11),random.Next(1,5),random.Next(1,11),random.Next(1,11),random.Next(1,11),100);

    Personaje final = new Personaje(pokemon,carac);
    return final;
    }

}