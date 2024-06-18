namespace personajes;

public class Caracteristicas {
    int velocidad;
    int destreza;
    int fuerza;
    int nivel;
    int armadura;
    int salud;

    public Caracteristicas(int velocidad, int destreza, int fuerza, int nivel, int armadura, int salud)
    {
        this.velocidad = velocidad;
        this.destreza = destreza;
        this.fuerza = fuerza;
        this.nivel = nivel;
        this.armadura = armadura;
        this.salud = salud;
    }

    public global::System.Int32 Velocidad { get => velocidad; set => velocidad = value; }
    public global::System.Int32 Destreza { get => destreza; set => destreza = value; }
    public global::System.Int32 Fuerza { get => fuerza; set => fuerza = value; }
    public global::System.Int32 Nivel { get => nivel; set => nivel = value; }
    public global::System.Int32 Armadura { get => armadura; set => armadura = value; }
    public global::System.Int32 Salud { get => salud; set => salud = value; }

    
}