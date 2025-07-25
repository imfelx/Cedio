using System;
using System.IO;

public class FraseService
{
    private static string rutaArchivo = "storage/frases.txt";
     private static string[] lineas = new string[0];


/// Muestra una frase aleatoria del archivo 'frases.txt'.
/// Si el archivo no existe o está vacío, muestra un mensaje de error.
    public static void MostrarFraseAleatoria()
    {
        if (!File.Exists(rutaArchivo))
        {
            Console.WriteLine("Error: No se encontró el archivo '" + rutaArchivo + "'.");
            return;
        }

        lineas = File.ReadAllLines(rutaArchivo);

        if (lineas.Length == 0)
        {
            Console.WriteLine("No hay frases en el archivo.");
            return;
        }

        Random rand = new Random();
        int idx = rand.Next(lineas.Length);

        string[] partes = lineas[idx].Split('|');
        if (partes.Length == 2)
        {
            string frase = partes[0].Trim();
            string autor = partes[1].Trim();

            Console.WriteLine("“" + frase + "”");
            Console.WriteLine("– " + autor + " ");
        }
    }
}