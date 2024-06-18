namespace personajes;

public class Personaje {
    Datos datos;

    Caracteristicas caracteristicas;

    public Personaje(Datos datos, Caracteristicas caracteristicas)
    {
        this.datos = datos;
        this.caracteristicas = caracteristicas;
    }

    public Datos Datos { get => datos; set => datos = value; }
    public Caracteristicas Caracteristicas { get => caracteristicas; set => caracteristicas = value; }
}