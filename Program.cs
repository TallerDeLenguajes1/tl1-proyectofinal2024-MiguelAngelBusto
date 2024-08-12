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
                Console.WriteLine(string.IsNullOrWhiteSpace(Nombre));
                Console.WriteLine("\nNombre ingresado incorrectamente ingresado incorrectamente");
                System.Console.WriteLine("\n\n\t\t1)Ingrese un Nombre valido: ");
                Nombre = System.Console.ReadLine();
            }
            Console.Clear();
            System.Console.WriteLine("\n\n\t\t2)Ingrese su Apodo: ");
            Apodo = System.Console.ReadLine();
            while(string.IsNullOrWhiteSpace(Apodo)){
                Console.Clear();
                Console.WriteLine("\nNombre ingresado incorrectamente ingresado incorrectamente");
                System.Console.WriteLine("\n\n\t\t1)Ingrese un Nombre valido: ");
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
            Console.WriteLine("\n\n\t\t4) Ingrese su fecha de nacimiento (DD/MM/YYYY): ");
            fechaInput = Console.ReadLine();
            while (!DateTime.TryParseExact(fechaInput, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out fecha))
            {
            Console.Clear();
            Console.WriteLine("Formato de fecha inválido. Asegúrate de usar el formato dd/MM/yyyy.");
            Console.WriteLine("\n\n\t\t4) Ingrese su fecha de nacimiento (DD/MM/YYYY): ");
            fechaInput = Console.ReadLine();
            }
            DateTime hoy = DateTime.Now;
            edad = hoy.Year - fecha.Year;
            Personaje usuario = aux.Fabricar((Cargos)cargo, Nombre, Apodo, fecha , edad , 0);
            json.Guardar(usuario);
            Console.Clear();
            System.Console.WriteLine("Datos guardados exitosamente.");
            Thread.Sleep(2000); 
            do {
                System.Console.WriteLine(mens.MenuCarga(usuario.DatoPersonaje.Nombre));
                System.Console.WriteLine(mens.InterfaceCombate());
                Personaje rival2 = aux.Fabricar();
                auxiciliar = Console.ReadLine();
                y = Int32.Parse(auxiciliar);
                System.Console.WriteLine(y);
                switch (y)
                {
                    case 1:
                        if (Combate.Pelea(usuario, rival2))
                        {
                            usuario.Combates++;
                            Console.Clear();
                            System.Console.WriteLine("Combate Ganado!!");
                            Thread.Sleep(2000);
                        }
                        else
                        {
                            Console.Clear();
                            System.Console.WriteLine("Combate Perdido!!");
                            Thread.Sleep(2000);
                        }
                        Console.Clear();
                        break;
                    case 2:
                        Console.Clear();
                        System.Console.WriteLine(mens.MsjCombate(usuario));
                        Thread.Sleep(6000);
                        Console.Clear();
                        break;
                    case 3:
                        Console.Clear();
                        json.Guardar(usuario);
                        System.Console.WriteLine("Datos guardados exitosamente.");
                        Thread.Sleep(2000);
                        break;
                    case 4:
                        y = -1;
                        break;
                    default:
                        Console.Clear();
                        System.Console.WriteLine("Opción no válida, vuelva a intentarlo.");
                        Thread.Sleep(2000);
                        Console.Clear();
                        break;
                }
            } while (y != -1 && usuario.Combates < 10);

            if (usuario.Combates >= 10)
            {
                json.Guardar(usuario);
                System.Console.WriteLine("Felicidades ganaste 10 combates, pasaras al registro de campeones!");
                json.Guardar(usuario, "Campeones.txt");
                Thread.Sleep(4000);
            }
            Console.Clear();
            System.Console.WriteLine(mens.MenuCarga(usuario.DatoPersonaje.Nombre));
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
            Console.Clear();
            do
            {
                System.Console.WriteLine(mens.MenuCarga(usuario.DatoPersonaje.Nombre));
                System.Console.WriteLine(mens.InterfaceCombate());
                Personaje rival2 = aux.Fabricar();
                auxiciliar = Console.ReadLine();
                y = Int32.Parse(auxiciliar);
                System.Console.WriteLine(y);
                switch (y)
                {
                    case 1:
                        if (Combate.Pelea(usuario, rival2))
                        {
                            usuario.Combates++;
                            System.Console.WriteLine("Combate Ganado!!");
                        }
                        else
                        {
                            System.Console.WriteLine("Combate Perdido!!");
                        }
                        Thread.Sleep(2000);
                        Console.Clear();
                        break;
                    case 2:
                        Console.Clear();
                        System.Console.WriteLine(mens.MsjCombate(usuario));
                        Thread.Sleep(6000);
                        Console.Clear();
                        break;
                    case 3:
                        Console.Clear();
                        json.Guardar(usuario);
                        System.Console.WriteLine("Datos guardados exitosamente.");
                        Thread.Sleep(2000);
                        break;
                    case 4:
                        y = -1;
                        break;
                    default:
                        Console.Clear();
                        System.Console.WriteLine("Opción no válida, vuelva a intentarlo.");
                        Thread.Sleep(2000); // Tiempo para mostrar mensaje de error
                        break;
                }
            } while (y != -1 && usuario.Combates < 10);

            if (usuario.Combates >= 10)
            {
                json.Guardar(usuario);
                System.Console.WriteLine("Felicidades ganaste 10 combates, pasaras al registro de campeones!");
                json.Guardar(usuario, "Campeones.txt");
                Thread.Sleep(4000);
            }
            Console.Clear();
            System.Console.WriteLine(mens.MenuCarga(usuario.DatoPersonaje.Nombre));
            break;
        case 3:
            Console.Clear();
            List<Personaje> campeones = new List<Personaje>();
            campeones = json.CargarCampeones("Campeones.txt");
            if (campeones.Count() != 0)
            {
                for (int i = 0; i < campeones.Count; i++)
                {
                    System.Console.WriteLine("\n" + i + ")" + campeones[i].DatoPersonaje.Nombre);
                }
            }
            else
            {
                System.Console.WriteLine("\nNo se encontraron campeones");
            }

            Thread.Sleep(4000);
            break;
        case 4:
            Console.Clear();
            System.Console.WriteLine("Terminando el programa...");
            Thread.Sleep(3000);
            Environment.Exit(0);
            break;
        default:
            System.Console.WriteLine("Numero ingresado incorrecto, ingrese nuevamente");
            break;
    }
    System.Console.WriteLine(mens.Menu());
    } else {
    Console.Clear();
    System.Console.WriteLine("Ingreso Incorrecto");
    Thread.Sleep(2000);
    x = 0;
    Console.Clear();
    System.Console.WriteLine(mens.Menu());
    }
}
