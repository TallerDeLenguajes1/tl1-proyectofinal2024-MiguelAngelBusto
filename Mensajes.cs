namespace mensajes;
using personajes;

public class Mensajes
{
    public string Menu()
    {
        return "\n\n\n\n\n\t\t-----------------------------------------\n\t\t|\tBienvenido a Pokemon!\t\t|\n\t\t-----------------------------------------\n\n\n\n\nQue desea hacer:\n1)Comenzar una partida nueva\n2)Cargar Partida\n3)Registro de campeones\n4)Salir.\nIngrese su eleccion: ";
    }

    public string MenuCarga(string nombre)
    {
        return "\n\n\n\n\n\t\t-----------------------------------------\n\t\t|\t\tPOKEMON\t\t\t|\n\t\t-----------------------------------------\n\n\n\n\n";
    }

    public string InterfaceCombate()
    {
        return "\n\t\t1) Comenzar siguiente combate\n\t\t2) Estadisticas del pokemon\n\t\t3) Guardar datos\n\t\t4) Salir al menu anterior\n\n\t\tCual sera su eleccion:";
    }

    public string MsjCombate(Personaje p1)
    {
        if (p1.DatoPersonaje.Tipo.ToString() == "Fuego")
        {
            return "Pokemon: Charmander\nFuerza: " +p1.CaracteristicasPersonaje.Fuerza.ToString() + "\nVelocidad: " + p1.CaracteristicasPersonaje.Velocidad.ToString() + "\nDestreza: " + p1.CaracteristicasPersonaje.Destreza.ToString() + "\nArmadura: " + p1.CaracteristicasPersonaje.Armadura.ToString() + "\nSalud: " + p1.CaracteristicasPersonaje.Salud.ToString() + "\nNivel: " + p1.CaracteristicasPersonaje.Nivel.ToString();
        }
        if (p1.DatoPersonaje.Tipo.ToString() == "Tierra")
        {
            return "Pokemon: Bulbasaur\nFuerza: " + p1.CaracteristicasPersonaje.Fuerza.ToString() + "\nVelocidad: " + p1.CaracteristicasPersonaje.Velocidad.ToString() + "\nDestreza: " + p1.CaracteristicasPersonaje.Destreza.ToString() + "\nArmadura: " + p1.CaracteristicasPersonaje.Armadura.ToString() + "\nSalud: " + p1.CaracteristicasPersonaje.Salud.ToString() + "\nNivel: " + p1.CaracteristicasPersonaje.Nivel.ToString();
        }
        else 
        {
            return "Pokemon: Squirtle\nFuerza: " + p1.CaracteristicasPersonaje.Fuerza.ToString() + "\nVelocidad: " + p1.CaracteristicasPersonaje.Velocidad.ToString() + "\nDestreza: " + p1.CaracteristicasPersonaje.Destreza.ToString() + "\nArmadura: " + p1.CaracteristicasPersonaje.Armadura.ToString() + "\nSalud: " + p1.CaracteristicasPersonaje.Salud.ToString() + "\nNivel: " + p1.CaracteristicasPersonaje.Nivel.ToString();
        }
    }
}