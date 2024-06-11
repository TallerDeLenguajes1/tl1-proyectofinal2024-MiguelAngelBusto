using System.Globalization;
using personajes;
using archivo;

Console.WriteLine("Ingrese un nombre: ");
string nombre = Console.ReadLine();
Console.WriteLine("Ingrese un Apodo: ");
string apodo = Console.ReadLine();
Console.WriteLine("Ingrese una Fecha: ");
string fechaN = Console.ReadLine();
Console.WriteLine("Ingrese su edad: ");
string edad = Console.ReadLine();
int n;
int.TryParse(edad, out n);

string format = "MM/dd/yyyy";

DateTime dateTime = DateTime.ParseExact(fechaN, format, CultureInfo.InvariantCulture);
Console.WriteLine(dateTime);

/*Datos datos = new Datos(Cargos.,nombre,apodo,dateTime,n);
string dato;
string.TryParse(datos, out dato);
*/
