using System.Globalization;
using personajes;
using archivo;

FabricaDePersonajes aux = new FabricaDePersonajes();
Personaje rival1 = aux.Fabricar();

System.Console.WriteLine(rival1.Datos.Apodo1);

/*Datos datos = new Datos(Cargos.,nombre,apodo,dateTime,n);
string dato;
string.TryParse(datos, out dato);
*/
