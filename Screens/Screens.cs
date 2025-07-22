using Data;
using Utils;

namespace Screen;

public class ScreenMain
{
  public const int ExitInput = 0;

  public static void Screen()
  {
    while (true)
    {
      MainScreen.Screen(ExitInput);

      int op = InputHelper.ReadOption();

      if (op == ExitInput)
      {
        StyleConsole.Title("CONFIRMACIÓN DE SALIDA", 40);
        StyleConsole.WriteLine("¿Está seguro que desea salir? (S/N)", ConsoleColor.Yellow);
        string? confirm = Console.ReadLine()?.Trim().ToUpper();
        if (confirm == "S")
        {
          if (IdeaData.ideas != new string[0]) IdeaData.Save();

          // AnimationHelper.LoadingAnimation("Guardando datos", 1.5);
          StyleConsole.Title("SALIENDO DEL PROGRAMA", 40);
          StyleConsole.WriteLine("¡Hasta pronto!", ConsoleColor.Green);
          break;
        }
        else
        {
          StyleConsole.Error("Operación cancelada. Volviendo al menú principal...");
          continue;
        }
      }

      MainScreen.Navigator(op);
    }
  }
}