
namespace personajes;

public enum Cargos {
    Fuego,
    Agua,
    Tierra
}

public class Datos {
    Cargos Tipo;
    string Nombre;
    string Apodo;
    DateTime fechaN;
    int Edad;

    public Cargos Tipo1 { get => Tipo; set => Tipo = value; }
    public global::System.String Nombre1 { get => Nombre; set => Nombre = value; }
    public global::System.String Apodo1 { get => Apodo; set => Apodo = value; }
    public DateTime FechaN { get => fechaN; set => fechaN = value; }
    public global::System.Int32 Edad1 { get => Edad; set => Edad = value; }

    public Datos (Cargos tipo, string nombre, string apodo, DateTime fechaN, int edad){
        this.Tipo = tipo;
        this.Nombre = nombre;
        this.Apodo = apodo;
        this.fechaN = fechaN;
        this.Edad = edad;
    }

}