namespace Utils;

class StyleConsole
{
  public static void Title(string titulo, int ancho = 50)
  {
    string top = "╔" + new string('═', ancho - 2) + "╗";
    string bottom = "╚" + new string('═', ancho - 2) + "╝";
    string middle = "║" + titulo.PadLeft((ancho - 2 + titulo.Length) / 2).PadRight(ancho - 2) + "║";
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine($"\r{top}");
    Console.WriteLine(middle);
    Console.WriteLine(bottom);
    Console.ResetColor();
  }

  public static void WriteLine(string texto, ConsoleColor color = ConsoleColor.Yellow)
  {
    Console.ForegroundColor = color;
    Console.WriteLine(texto);
    Console.ResetColor();
  }

  public static void Write(string text, ConsoleColor color = ConsoleColor.Yellow)
  {
    Console.ForegroundColor = color;
    Console.Write(text);
    Console.ResetColor();
  }
  public static void Error(string text)
  {
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine(text);
    Console.ResetColor();
  }
}

