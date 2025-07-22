using Screen;
using Utils;

class PomodoroScreen
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
  public static void MainScreen()
  {
    while (true)
    {
      Console.Clear();
      StyleConsole.Title($"Pomodoro");
      StyleConsole.Error($"{ScreenMain.ExitInput}. Volver");

      int op = InputHelper.ReadOption();

      if (op == ScreenMain.ExitInput) break;

      Navigator(op);
    }
  }
}