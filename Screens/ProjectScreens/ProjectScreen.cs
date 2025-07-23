using Data;
using Screen;
using Utils;

class ProjectScreen
{
  private static int i = ProjectData.ProjectsIndex;
  private static string[] projects = IdeaData.ideas;

  private static void ProjectsList()
  {
    int pageSize = 25;
    int currentPage = 0;
    int totalPages = (projects.Length + pageSize - 1) / pageSize;

    while (true)
    {
      StyleConsole.Title("LISTA DE PROYECTOS");

      int start = currentPage * pageSize;
      int end = start + pageSize;

      if (end > projects.Length) end = projects.Length;

      for (int i = start; i < end; i++)
      {
        StyleConsole.WriteLine($"{i + 1}: {projects[i]}", ConsoleColor.Green);
      }

      StyleConsole.WriteLine($"\nPágina {currentPage + 1} de {totalPages}", ConsoleColor.Cyan);
      StyleConsole.WriteLine("Presiona [Enter] para siguiente, [Backspace] para anterior, [Esc] para salir.");


      if (InputHelper.ReadKey(ConsoleKey.Enter) && currentPage < totalPages - 1)
      {
        currentPage++;
      }
      else if (InputHelper.ReadKey(ConsoleKey.Backspace) && currentPage > 0)
      {
        currentPage--;
      }
      else if (InputHelper.ReadKey(ConsoleKey.Escape)) break;
    }
  }

  public static void ChoseProject()
  {
    while (true)
    {
      bool end = false;

      Console.Clear();
      StyleConsole.Title("SELECCION DE PROYECTO");
      StyleConsole.WriteLine("1. Ver lista de proyectos", ConsoleColor.Green);
      StyleConsole.WriteLine("2. Seleccionar Proyecto", ConsoleColor.Green);
      StyleConsole.Error($"{ScreenMain.ExitInput}. Volver");

      int op = InputHelper.ReadOption();

      if (op == ScreenMain.ExitInput) break;

      Console.Clear();
      switch (op)
      {
        case 1:
          ProjectsList();
          break;
        case 2:
          i = InputHelper.ReadNum("Ingresa el indice del proyecto") - 1;
          Console.WriteLine(i);
          end = true;
          break;
        default:
          StyleConsole.Error("Ninguna opcion es valida, intente nuevamente");
          break;
      }

      if (end) break;

      InputHelper.Continuar();
    }
  }
  private static void Navigator(int op)
  {
    Console.Clear();
    switch (op)
    {
      case 1:
        PomodoroScreen.MainScreen();
        break;
      case 2:
        BitacoraScreen.MainScreen();
        break;
      case 3:
        TodoScreen.MainScreen();
        break;
      case 4:
        break;
      default:
        StyleConsole.Error("Ninguna opcion es valida, intente nuevamente");
        break;
    }
    InputHelper.Continuar();
  }
  public static void MainScreen()
  {
    ChoseProject();
    while (true)
    {
      if (i == -1) break;

      Console.Clear();
      StyleConsole.Title($"Proyecto {i + 1}");
      StyleConsole.WriteLine("1. Contador Pomodoro", ConsoleColor.Green);
      StyleConsole.WriteLine("2. Bitacora", ConsoleColor.Green);
      StyleConsole.WriteLine("3. Manejador de tareas", ConsoleColor.Green);
      StyleConsole.WriteLine("4. Frase motivadora", ConsoleColor.Green);
      StyleConsole.Error($"{ScreenMain.ExitInput}. Volver");

      int op = InputHelper.ReadOption();

      if (op == ScreenMain.ExitInput) break;

      Navigator(op);
    }
  }
}