using Utils;

public static class MainMenu
{
  public static void Navigator(int op)
  {
    Console.Clear();
    switch (op)
    {
      case 1:
        break;
      default:
        StyleConsole.Error("Ninguna opcion es valida, intente nuevamente");
        break;
    }
  }
  public static void Screen(int exitInput)
  {
    Console.Clear();
    StyleConsole.Title("MENÚ PRINCIPAL");
    StyleConsole.WriteLine($"{exitInput}. Salir", ConsoleColor.Red);
  }
}