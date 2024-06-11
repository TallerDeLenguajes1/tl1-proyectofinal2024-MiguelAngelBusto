namespace personajes;

public enum Cargos {
    Guerrero,
    Ingeniero,
    Mago,
    Elfo,
    Orco,
    Metemorfo
}

public class Datos {
    Cargos Tipo;
    string Nombre;
    string Apodo;
    Date fechaN;
    int Edad;

    public Cargos Tipo1 { get => Tipo; set => Tipo = value; }
    public global::System.String Nombre1 { get => Nombre; set => Nombre = value; }
    public global::System.String Apodo1 { get => Apodo; set => Apodo = value; }
    public Date FechaN { get => fechaN; set => fechaN = value; }
    public global::System.Int32 Edad1 { get => Edad; set => Edad = value; }
}