namespace mensajes;

public class Mensajes{
    public string Menu (){
        return "\n\n\n\n\n\t\t-----------------------------------------\n\t\t|\tBienvenido a Pokemon!\t\t|\n\t\t-----------------------------------------\n\n\n\n\nQue desea hacer:\n1)Comenzar una partida nueva\n2)Cargar Partida\n3)Registro de campeones\n4)Salir.\nIngrese su eleccion: ";
    }

    public string MenuCarga(string nombre){
        return "\n\n\n\n\n\t\t-----------------------------------------\n\t\t|\t"+nombre+"\t\t|\n\t\t-----------------------------------------\n\n\n\n\n";
    }
}