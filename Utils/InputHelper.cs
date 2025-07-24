namespace Utils;

class InputHelper
{
  public static int ReadOption()
  {
    string? input;
    int op;

    do
    {
      StyleConsole.Write("Ingresa un numero valido: ");
      input = Console.ReadLine();
    }
    while (!int.TryParse(input, out op));

    return op;
  }

  public static string ReadString(string texto, ConsoleColor color = ConsoleColor.Yellow)
  {
    string? input;

    do
    {
      StyleConsole.Write($"{texto}: ", color);
      input = Console.ReadLine();
    }
    while (input == null || input.Trim() == "");

    return input;
  }

  public static int ReadNum(string texto, ConsoleColor color = ConsoleColor.Yellow)
  {
    string? input;
    int numero;

    do
    {
      StyleConsole.Write($"{texto}: ", color);
      input = Console.ReadLine();
    }
    while (!int.TryParse(input, out numero));

    return numero;
  }

  public static void Continuar(string text = "Presiona cualquier tecla para continuar...")
  {
    StyleConsole.WriteLine(text, ConsoleColor.Cyan);
    Console.ReadKey();
  }
  public static bool ReadKey(ConsoleKey key)
  {
    var keyInfo = Console.ReadKey(intercept: true);
    return keyInfo.Key == key;
  }
}

