namespace personajes;

public class Personaje {
    Datos datoPersonaje;

    Caracteristicas caracteristicasPersonaje;

    public Datos DatoPersonaje { get => datoPersonaje; set => datoPersonaje = value; }
    public Caracteristicas CaracteristicasPersonaje { get => caracteristicasPersonaje; set => caracteristicasPersonaje = value; }

    public Personaje(){
        
    }

    public Personaje(Datos datoPersonaje, Caracteristicas caracteristicasPersonaje)
    {
        this.datoPersonaje = datoPersonaje;
        this.caracteristicasPersonaje = caracteristicasPersonaje;
    }
}