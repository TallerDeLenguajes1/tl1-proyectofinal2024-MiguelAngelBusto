using System.Globalization;
using personajes;
using archivo;
using mensajes;
using System.Threading;


FabricaDePersonajes aux = new FabricaDePersonajes();
Mensajes mens = new Mensajes();
string Nombre;
string Apodo;
Cargos tipo;
int edad;
string auxiciliar;
bool entradaValida;
PersonajesJson json = new PersonajesJson(); ;
Console.Clear();
int x = 0, y = 0;
ServicioApi apiClient = new ServicioApi();
await apiClient.ObtenerDatosAsync();
Thread.Sleep(2000);
Console.Clear();
System.Console.WriteLine(mens.Menu());
int anchoConsola = Console.WindowWidth;

while (x > -1 )
{
    auxiciliar = Console.ReadLine();
    entradaValida = Int32.TryParse(auxiciliar, out x);
    if(entradaValida){
    switch (x)
    {
        case 1:
            Console.Clear();
            System.Console.WriteLine("\n\n\t\t1)Ingrese su Nombre: ");
            Nombre = System.Console.ReadLine();
            while(string.IsNullOrWhiteSpace(Nombre)){
                Console.Clear();
                Console.WriteLine("\nNombre ingresado incorrectamente ingresado incorrectamente");
                System.Console.WriteLine("\n\n\t\t1)Ingrese un Nombre valido: ");
                Nombre = System.Console.ReadLine();
            }
            Console.Clear();
            System.Console.WriteLine("\n\n\t\t2)Ingrese su Apodo: ");
            Apodo = System.Console.ReadLine();
            while(string.IsNullOrWhiteSpace(Apodo)){
                Console.Clear();
                Console.WriteLine("\nApodo ingresado incorrectamente ingresado incorrectamente");
                System.Console.WriteLine("\n\n\t\t1)Ingrese un Apodo valido: ");
                Apodo = System.Console.ReadLine();
            }
            Console.Clear();
            int cargo;
            bool esValido;

            do
            {
                Console.Clear();
                Console.WriteLine("\n\n\t\t3) Elija el pokemon a usar:\n1) Charmander\n2) Squirtle\n3) Bulbasaur\n\nIngrese su elección:");
                auxiciliar = Console.ReadLine();
                esValido = Int32.TryParse(auxiciliar, out cargo);

                if (!esValido || cargo < 1 || cargo > 3)
                {
                    esValido = false;
                }
            } while (!esValido);
            Console.Clear();
            string fechaInput;
            DateTime fecha;
            bool var = false;
            DateTime hoy = DateTime.Now;
            Console.WriteLine("\n\n\t\t4) Ingrese su fecha de nacimiento (DD/MM/YYYY): ");
            fechaInput = Console.ReadLine();
            while (!var)
            {
            if(DateTime.TryParseExact(fechaInput, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out fecha)){
                fecha = DateTime.ParseExact(fechaInput, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None);
                if(fecha<hoy){
                    var = true;
                }else{
                    Console.Clear();
                    Console.WriteLine("la Fecha supera la fecha actual.");
                    Console.WriteLine("\n\n\t\t4) Ingrese su fecha de nacimiento (DD/MM/YYYY): ");
                    fechaInput = Console.ReadLine();
                }
            } else {
                Console.Clear();
                Console.WriteLine("Formato de fecha inválido. Asegúrate de usar el formato dd/MM/yyyy.");
                Console.WriteLine("\n\n\t\t4) Ingrese su fecha de nacimiento (DD/MM/YYYY): ");
                fechaInput = Console.ReadLine();
            }
            }
            fecha = DateTime.ParseExact(fechaInput, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None);
            edad = hoy.Year - fecha.Year;
            Personaje usuario = aux.Fabricar((Cargos)cargo, Nombre, Apodo, fecha , edad , 0 , 5);
            json.Guardar(usuario);
            Console.Clear();
            System.Console.WriteLine("Datos guardados exitosamente.");
            Thread.Sleep(2000); 
            do {
                System.Console.WriteLine(mens.MenuCarga(usuario.DatoPersonaje.Nombre));
                System.Console.WriteLine("\t\tUsuario: "+usuario.DatoPersonaje.Nombre);
                System.Console.WriteLine("\t\tVidas: "+usuario.Vidas);
                System.Console.WriteLine("\t\tCantidad de Combates: "+usuario.Combates);
                System.Console.WriteLine(mens.InterfaceCombate());
                Personaje rival2 = aux.Fabricar();
                auxiciliar = Console.ReadLine();
                entradaValida = Int32.TryParse(auxiciliar, out y);
                if(entradaValida){
                    Combate.Menu(y,usuario,rival2,mens,json);
                    if(y==4){
                    break;
                }
                } else {
                        Console.Clear();
                        System.Console.WriteLine("Opción no válida, vuelva a intentarlo.");
                        }
            } while (y != -1 && usuario.Combates < 10 && usuario.Vidas>0);
            if (usuario.Combates >= 10)
            {
                json.Guardar(usuario);
                System.Console.WriteLine("Felicidades ganaste 10 combates, pasaras al registro de campeones!");
                json.Guardar(usuario, "Campeones.json");
                Thread.Sleep(4000);
                break;
            } else {
                System.Console.WriteLine("Te quedaste sin vidas, lo siento");
                Thread.Sleep(4000);
            }
            Console.Clear();
            break;
        case 2:
            Console.Clear();
            usuario = json.Cargar();
            System.Console.WriteLine("\n\n\n\t\t\tCargado con exito!!");
            Thread.Sleep(3000);
            if (usuario.Combates >= 10)
            {
                System.Console.WriteLine("La partida cargada ya tuvo 10 triunfos");
                Thread.Sleep(4000);
                break;
            }
            if(usuario.Vidas<1){
                System.Console.WriteLine("La partida cargada se quedo sin vidas");
                Thread.Sleep(4000);
                break;
            }
            Console.Clear();
            do
            {
                System.Console.WriteLine(mens.MenuCarga(usuario.DatoPersonaje.Nombre));
                System.Console.WriteLine("\t\tUsuario: "+usuario.DatoPersonaje.Nombre);
                System.Console.WriteLine("\t\tVidas: "+usuario.Vidas);
                System.Console.WriteLine("\t\tCantidad de Combates: "+usuario.Combates);
                System.Console.WriteLine(mens.InterfaceCombate());
                Personaje rival2 = aux.Fabricar();
                auxiciliar = Console.ReadLine();
                entradaValida = Int32.TryParse(auxiciliar, out y);
                if(entradaValida){
                Combate.Menu(y,usuario,rival2,mens,json);
                if(y==4){
                    break;
                }
                } else {
                        Console.Clear();
                        System.Console.WriteLine("Opción no válida, vuelva a intentarlo.");
                        Thread.Sleep(2000);
                        Console.Clear();
                        }
            } while (y != -1 && usuario.Combates < 10 && usuario.Vidas>0);

            if (usuario.Combates >= 10)
            {
                json.Guardar(usuario);
                System.Console.WriteLine("Felicidades ganaste 10 combates, pasaras al registro de campeones!");
                json.Guardar(usuario, "Campeones.json");
                Thread.Sleep(4000);
                break;
            } else {
                System.Console.WriteLine("Te quedaste sin vidas, lo siento");
                Thread.Sleep(4000);
            }
            Console.Clear();
            break;
        case 3:
            Console.Clear();
            List<Personaje> campeones = new List<Personaje>();
            campeones = json.CargarCampeones("Campeones.json");
            if (campeones.Count() != 0)
            {
                for (int i = 0; i < campeones.Count; i++)
                {
                    
                    System.Console.WriteLine("\n" + i + ")" + campeones[i].DatoPersonaje.Nombre+"\tCantidad de Vidas: "+campeones[i].Vidas);
                }
            }
            else
            {
                System.Console.WriteLine("\nNo se encontraron campeones");
            }
            Thread.Sleep(4000);
            Console.Clear();
            break;
        case 4:
            Console.Clear();
            System.Console.WriteLine("Terminando el programa...");
            Thread.Sleep(3000);
            Environment.Exit(0);
            break;
        default:
            Console.Clear();
            System.Console.WriteLine("Numero ingresado incorrecto, ingrese nuevamente");
            Console.WriteLine("\n\nPresiona cualquier tecla para continuar...");
            Console.ReadKey();
            Console.Clear();
            break;
    }
    System.Console.WriteLine(mens.Menu());
    } else {
    Console.Clear();
    System.Console.WriteLine("Ingreso Incorrecto");
    Console.WriteLine("\n\nPresiona cualquier tecla para continuar...");
    Console.ReadKey();
    x = 0;
    Console.Clear();
    System.Console.WriteLine(mens.Menu());
    }
}
