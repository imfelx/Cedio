using Screen;
using Services;
using Utils;

class PomodoroScreen
{
  private static void Navigator(int op)
  {
    Console.Clear();
    switch (op)
    {
      case 1:
        PomodoroService.Pomodoro();
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
      StyleConsole.WriteLine("1. Pomdoro", ConsoleColor.Green);
      StyleConsole.Error($"{ScreenMain.ExitInput}. Volver");

      int op = InputHelper.ReadOption();

      if (op == ScreenMain.ExitInput) break;

      Navigator(op);
    }
  }
}