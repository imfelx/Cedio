using System;
using System.IO;

class FrasesService
{
    private static string rutaArchivo = "frases.txt";
    private static string[] lineas;

    public static void Frases()
    {
        Console.WriteLine("FRASES TECHNOLÓGICAS INSPIRADORAS\n");
        Console.WriteLine("Presiona una tecla para ver cada frase en orden aleatorio...\n");

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

        Barajar(lineas);

        for (int i = 0; i < lineas.Length; i++)
        {
            string[] partes = lineas[i].Split('|');

            if (partes.Length == 2)
            {
                string frase = partes[0].Trim();
                string autor = partes[1].Trim();

                Console.WriteLine("“" + frase + "”");
                Console.WriteLine("– " + autor + " ");
                Console.ReadKey(true);
            }
        }

        Console.WriteLine("Fin de las frases.");
    }

    private static void Barajar(string[] arreglo)
    {
        Random rand = new Random();

        for (int i = arreglo.Length - 1; i > 0; i--)
        {
            int j = rand.Next(i + 1);
            string temp = arreglo[i];
            arreglo[i] = arreglo[j];
            arreglo[j] = temp;
        }
    }
}
