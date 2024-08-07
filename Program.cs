﻿using System.Globalization;
using personajes;
using archivo;
using mensajes;
using System.Threading;


FabricaDePersonajes aux = new FabricaDePersonajes();
Mensajes mens = new Mensajes();
string Nombre;
string Apodo;
Cargos tipo;
string fecha;
string edad;
string auxiciliar;
PersonajesJson json = new PersonajesJson(); ;
Console.Clear();
int x = 0, y = 0;
ServicioApi apiClient = new ServicioApi();

var datos = await apiClient.ObtenerDatosAsync();

Rivales fileSaver = new Rivales();

fileSaver.GuardarDatos(datos);
Thread.Sleep(2000);
Console.Clear();
System.Console.WriteLine(mens.Menu());

while (x > -1)
{
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
            System.Console.WriteLine("\n\n\t\t4)Ingrese su fecha de nacimiento (DD/MM/YYYY): ");
            fecha = Console.ReadLine();
            System.Console.WriteLine("\n\n\t\t5)Ingrese su Edad: ");
            edad = Console.ReadLine();
            Personaje usuario = aux.Fabricar(tipo, Nombre, Apodo, DateTime.ParseExact(fecha, "dd/MM/yyyy", CultureInfo.InvariantCulture), Int32.Parse(edad) - 1, 0);
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
}
