using mensajes;

namespace personajes;

public class Combate{

    public static bool Pelea (Personaje p1, Personaje p2){
        Console.Clear();
        int i=0;
        int aux1 = p1.CaracteristicasPersonaje.Salud;
        int aux2 = p2.CaracteristicasPersonaje.Salud;
        Mensajes msj = new Mensajes();
        System.Console.WriteLine("\nLas de tu rival: \n"+msj.MsjCombate(p1));
        Thread.Sleep(2000);
        System.Console.WriteLine("\nLas de tu rival: \n"+msj.MsjCombate(p2));
        Thread.Sleep(3000);
        while(aux1>0 && aux2>0){
            if(i%2==0){
            Console.Clear();
            int dano = ((Ataque(p1)*Comparar(p1,p2))-Defensa(p2))/100;
            aux2=aux2-dano;
            System.Console.WriteLine("TU\n\nDanio Generedado al rival: "+dano+"\n\nVida Restante: "+aux2);
            Thread.Sleep(2000);
            } else {
            Console.Clear();
            int dano = ((Ataque(p2)*Comparar(p2,p1))-Defensa(p1))/100;
            aux1=aux1-dano;
            System.Console.WriteLine("RIVAL\n\nDanio Recibido del rival: "+dano+"\n\nVida Restante: "+aux1);
            Thread.Sleep(2000);
            }
            i++;
        }
        if(aux1>aux2){
            p1.CaracteristicasPersonaje.Nivel++;
            p1.CaracteristicasPersonaje.Armadura++;
            p1.CaracteristicasPersonaje.Salud=p1.CaracteristicasPersonaje.Salud+10;
            p1.CaracteristicasPersonaje.Destreza++;
            p1.CaracteristicasPersonaje.Fuerza++;
            p1.CaracteristicasPersonaje.Velocidad++;
            return true;
        }else {
            return false;
        }
    }

    public static int Ataque (Personaje p1){
        return p1.CaracteristicasPersonaje.Destreza*p1.CaracteristicasPersonaje.Fuerza*p1.CaracteristicasPersonaje.Nivel;
    }

    public static int Defensa(Personaje p1){
        return p1.CaracteristicasPersonaje.Armadura*p1.CaracteristicasPersonaje.Velocidad;
    }

    public static int Comparar(Personaje p1,Personaje p2){
        if((p1.DatoPersonaje.Tipo.ToString()=="Fuego" && p2.DatoPersonaje.Tipo.ToString()=="Agua") || (p1.DatoPersonaje.Tipo.ToString()=="Tierra" && p2.DatoPersonaje.Tipo.ToString()=="Fuego") || (p1.DatoPersonaje.Tipo.ToString()=="Agua" && p2.DatoPersonaje.Tipo.ToString()=="Tierra")){
            return 50;
        }
        if((p1.DatoPersonaje.Tipo.ToString()=="Fuego" && p2.DatoPersonaje.Tipo.ToString()=="Tierra") || (p1.DatoPersonaje.Tipo.ToString()=="Tierra" && p2.DatoPersonaje.Tipo.ToString()=="Agua") || (p1.DatoPersonaje.Tipo.ToString()=="Agua" && p2.DatoPersonaje.Tipo.ToString()=="Fuego")){
            return 100;
        }
        return 75;
    }
}
