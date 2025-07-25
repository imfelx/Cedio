using Data;
using Screen;
using Services;
using Utils;

class ProjectScreen
{
  private static int project = ProjectData.ProjectsIndex;
  private static string[] ideas = IdeaData.ideas;
  private static void ProjectsList()
  {
    int pageSize = 25;
    int currentPage = 0;
    int totalPages = (ideas.Length + pageSize - 1) / pageSize;

    while (project == -1)
    {
      Console.Clear();
      StyleConsole.Title("LISTA DE PROYECTOS");

      int start = currentPage * pageSize;
      int end = start + pageSize;

      if (end > ideas.Length) end = ideas.Length;

      for (int i = start; i < end; i++)
      {
        StyleConsole.WriteLine($"{i + 1}: {ideas[i]}", ConsoleColor.Green);
      }

      StyleConsole.WriteLine($"\nPágina {currentPage + 1} de {totalPages}", ConsoleColor.Cyan);
      StyleConsole.WriteLine("Presiona [SpaceBar] para siguiente, [Backspace] para anterior, [Enter] para seleccionar Proyecto, [Esc] para salir.");

      if (InputHelper.ReadKey(ConsoleKey.Spacebar) && currentPage < totalPages - 1)
      {
        currentPage++;
      }
      else if (InputHelper.ReadKey(ConsoleKey.Backspace) && currentPage > 0)
      {
        currentPage--;
      }
      else if (InputHelper.ReadKey(ConsoleKey.Enter))
      {
        project = InputHelper.ReadNum("\nIngresa el indice de la bitacora") - 1;
        if (project < 0 || project > ideas.Length + 1)
        {
          project = -1;
          continue;
        }
        ProjectData.Loadproject(project);
        AnimationHelper.LoadingAnimation();
        break;
      }
      else if (InputHelper.ReadKey(ConsoleKey.Escape)) break;
    }
  }

  private static void Navigator(int op)
  {
    Console.Clear();
    switch (op)
    {
      case 1:
        PomodoroService.Pomodoro();
        break;
      case 2:
        BitacoraScreen.MainScreen();
        break;
      case 3:
        StyleConsole.Title("IDEA DEL PROYECTO");
        StyleConsole.WriteLine($"{ideas[project]}\n", ConsoleColor.Green);
        InputHelper.Continuar();
        break;
      case 4:
        //FraseService.MostrarFraseAleatoria();
        break;
      default:
        StyleConsole.Error("Ninguna opcion es valida, intente nuevamente");
        break;
    }
  }
  public static void MainScreen()
  {
    ProjectsList();
    while (project != -1)
    {
      Console.Clear();
      StyleConsole.Title($"Proyecto {project + 1}");
      StyleConsole.WriteLine("1. Contador Pomodoro", ConsoleColor.Green);
      StyleConsole.WriteLine("2. Bitacora", ConsoleColor.Green);
      StyleConsole.WriteLine("3. Ver Idea del Proyecto", ConsoleColor.Green);
      StyleConsole.WriteLine("4. Frase motivadora", ConsoleColor.Green);
      StyleConsole.Error($"{ScreenMain.ExitInput}. Volver");

      int op = InputHelper.ReadOption();

      if (op == ScreenMain.ExitInput)
      {
        ProjectData.Saveproject();
        ProjectData.ProjectsIndex = -1;
        break;
      }

      Navigator(op);
    }
  }
}