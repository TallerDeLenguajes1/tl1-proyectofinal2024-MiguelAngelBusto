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
Console.Clear();
System.Console.WriteLine(mens.Menu());
System.Console.WriteLine("Ingrese su Nombre: ");
Nombre = System.Console.ReadLine();
System.Console.WriteLine("Ingrese su Apodo: ");
Apodo = System.Console.ReadLine();
System.Console.WriteLine("Elija el pokemon a usar:\n1)Charmander\n2)Squirtle\n3)Bulbasaur\n\nIngrese su eleccion:");
auxiciliar = System.Console.ReadLine();
tipo = (Cargos)Int32.Parse(auxiciliar);
System.Console.WriteLine("Ingrese su fecha de nacimiento (MM/DD/YYYY): ");
fecha = Console.ReadLine();
System.Console.WriteLine("Ingrese su Edad: ");
edad = Console.ReadLine();
Personaje usuario = aux.Fabricar(tipo,Nombre,Apodo,DateTime.ParseExact(fecha, "MM/dd/yyyy", CultureInfo.InvariantCulture),Int32.Parse(edad)-1);
Personaje rival1 = aux.Fabricar();
System.Console.WriteLine(usuario.Datos.Nombre1);
System.Console.WriteLine(rival1.Datos.Tipo1);




/*Datos datos = new Datos(Cargos.,nombre,apodo,dateTime,n);
string dato;
string.TryParse(datos, out dato);
*/
