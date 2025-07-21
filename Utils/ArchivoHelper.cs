using System.Text;
namespace Utils;

class ArchivoHelper
{
  private static void GuardarArchivo(string ruta, string[] lineas)
  {
    using (StreamWriter write = new StreamWriter(ruta, false, Encoding.UTF8))
    {
      foreach (var linea in lineas)
      {
        write.WriteLine(linea);
      }
    }
  }

  private static string[] CargarArchivo(string ruta)
  {
    return File.Exists(ruta) ? File.ReadAllLines(ruta, Encoding.UTF8) : new string[0];
  }
}
