using System.Globalization;
using personajes;
using archivo;
using mensajes;
FabricaDePersonajes aux = new FabricaDePersonajes();
Mensajes mens = new Mensajes();
string Nombre;
string Apodo;
Cargos tipo;
string fecha;
string edad;
string auxiciliar;
PersonajesJson json = new PersonajesJson();;
Console.Clear();
System.Console.WriteLine(mens.Menu());
int x=0;
while(x>-1){
    auxiciliar = Console.ReadLine();
    x = Int32.Parse(auxiciliar);
    switch (x)
    {
        case 1:
        Console.Clear();
        System.Console.WriteLine("\n\n\t\t1)Ingrese su Nombre: ");
        Nombre = System.Console.ReadLine();
        System.Console.WriteLine("\n\n\t\t2)Ingrese su Apodo: ");
        Apodo = System.Console.ReadLine();
        System.Console.WriteLine("\n\n\t\t3)Elija el pokemon a usar:\n1)Charmander\n2)Squirtle\n3)Bulbasaur\n\nIngrese su eleccion:");
        auxiciliar = System.Console.ReadLine();
        tipo = (Cargos)Int32.Parse(auxiciliar);
        System.Console.WriteLine("\n\n\t\t4)Ingrese su fecha de nacimiento (MM/DD/YYYY): ");
        fecha = Console.ReadLine();
        System.Console.WriteLine("\n\n\t\t5)Ingrese su Edad: ");
        edad = Console.ReadLine();
        Personaje usuario = aux.Fabricar(tipo,Nombre,Apodo,DateTime.ParseExact(fecha, "MM/dd/yyyy", CultureInfo.InvariantCulture),Int32.Parse(edad)-1);
        json.Guardar(usuario);
        Personaje rival1 = aux.Fabricar();
        break;
        case 2:
        usuario = json.Cargar();

        Console.Clear();
        System.Console.WriteLine(mens.MenuCarga(usuario.DatoPersonaje.Nombre));
        break;
        case 3:
        
        break;
        case 4:
        Console.Clear();
        Environment.Exit(0);
        break;
        default:
        System.Console.WriteLine("Numero ingresado incorrecto, ingrese nuevamente");
        break;
    }
}
//System.Console.WriteLine(usuario.Datos.Nombre1);
//System.Console.WriteLine(rival1.Datos.Tipo1);




/*Datos datos = new Datos(Cargos.,nombre,apodo,dateTime,n);
string dato;
string.TryParse(datos, out dato);
*/
