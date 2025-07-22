using Screen;
using Utils;

class ProjectScreen
{
  public static void Navigator(int op)
  {
    Console.Clear();
    switch (op)
    {
      case 1:
        break;
      case 2:
        break;
      case 3:
        break;
      case 4:
        break;
      default:
        StyleConsole.Error("Ninguna opcion es valida, intente nuevamente");
        break;
    }
  }
  public static void MainScreen(int i)
  {
    while (true)
    {
      Console.Clear();
      StyleConsole.Title($"Proyecto {i}");
      StyleConsole.WriteLine("1. Contador Pomodoro", ConsoleColor.Green);
      StyleConsole.WriteLine("2. Bitacora", ConsoleColor.Green);
      StyleConsole.WriteLine("3. Manejador de tareas", ConsoleColor.Green);
      StyleConsole.WriteLine("4. Frase motivadora", ConsoleColor.Green);
      StyleConsole.Error($"{ScreenMain.ExitInput}. Volver");

      int op = InputHelper.LeerOpcion();

      if (op == ScreenMain.ExitInput) break;

      Navigator(op);
    }
  }
}