using Screen;
using Utils;

class TodoScreen
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
  public static void MainScreen(int i)
  {
    while (true)
    {
      Console.Clear();
      StyleConsole.Title($"Pomodoro");
      StyleConsole.Error($"{ScreenMain.ExitInput}. Volver");

      int op = InputHelper.LeerOpcion();

      if (op == ScreenMain.ExitInput) break;

      Navigator(op);
    }
  }
}