using Services;
using Utils;

public static class MainScreen
{
  public static void Navigator(int op)
  {
    Console.Clear();
    switch (op)
    {
      case 1:
        GeneratorServices.Generator();
        break;
      default:
        StyleConsole.Error("Ninguna opcion es valida, intente nuevamente");
        break;
    }
    InputHelper.Continuar();
  }
  public static void Screen(int exitInput)
  {
    Console.Clear();
    StyleConsole.Title("MENÚ PRINCIPAL");
    StyleConsole.WriteLine("1. Generar Idea", ConsoleColor.Green);
    StyleConsole.Error($"{exitInput}. Salir");
  }
}