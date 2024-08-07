﻿using System;
using System.IO;

namespace personajes { 
public class Rivales
{
     string _nombreArchivo = "Rivales.txt";

        public Rivales() { }

        public void GuardarDatos(string[] datos)
        {
            try
            {
                
                if (!File.Exists(_nombreArchivo))
                {
                    
                    using (FileStream fs = File.Create(_nombreArchivo))
                    {
                        
                    }
                }

                
                File.WriteAllLines(_nombreArchivo, datos);
                Console.WriteLine($"Datos guardados en {_nombreArchivo}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al guardar los datos: {ex.Message}");
            }
        }


        public List<string> CargarDatos()
    {
        try
        {
            var datos = new List<string>(File.ReadAllLines(_nombreArchivo));
            return datos;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al cargar los datos: {ex.Message}");
            return new List<string>();
        }
    }
}
}