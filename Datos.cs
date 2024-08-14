
namespace personajes;
public enum Cargos: int {
    Fuego=1,
    Agua=2,
    Tierra=3
}

public class Datos {
    Cargos tipo;
    string nombre;
    string apodo;
    DateTime fechaN;
    int edad;


    public String Nombre { get => nombre; set => nombre = value; }
    public String Apodo { get => apodo; set => apodo = value; }
    public DateTime FechaN { get => fechaN; set => fechaN = value; }
    public Int32 Edad { get => edad; set => edad = value; }
    public Cargos Tipo { get => tipo; set => tipo = value; }

    public Datos (Cargos tipo, string nombre, string apodo, DateTime fechaN, int edad){
        this.Tipo = tipo;
        this.Nombre = nombre;
        this.Apodo = apodo;
        this.fechaN = fechaN;
        this.Edad = edad;
    }
    public Datos(){

    }

}