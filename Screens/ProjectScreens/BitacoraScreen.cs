using Data;
using Screen;
using Utils;

class BitacoraScreen
{
  private static string[] bitacora = ProjectData.bitacora;

  private static void AddBitacora()
  {
    StyleConsole.Title($"BITACORA {DateTime.Now}");
    string bitacora = InputHelper.ReadString("Escribe tu bitacora", true);

    ProjectData.AddBitacora(bitacora);
  }
  private static void GetBitacoras()
  {
    static void ShowBitacora(string[][] bit)
    {
      int op;
      do
      {
        op = InputHelper.ReadNum("Ingresa el indice de la bitacora") - 1;
      } while (op < 0 || op >= bit.Length);

      Console.Clear();
      StyleConsole.Title($"BITACORA {bit[op][0]}");
      StyleConsole.WriteLine(bit[op][1]);
      InputHelper.Continuar();
    }

    string[][] bitacoras = ProjectData.GetBitacora();

    int pageSize = 25;
    int currentPage = 0;
    int totalPages = (bitacoras.Length + pageSize - 1) / pageSize;

    while (true)
    {
      int start = currentPage * pageSize;
      int end = start + pageSize;

      if (end > bitacoras.Length) end = bitacoras.Length;

      Console.Clear();
      StyleConsole.Title("LISTA DE BITACORAS");
      for (int i = start; i < end; i++)
      {
        StyleConsole.WriteLine($"{i + 1}: {bitacoras[i][0]}", ConsoleColor.Green);
      }

      StyleConsole.WriteLine($"\nPágina {currentPage + 1} de {totalPages}", ConsoleColor.Cyan);
      StyleConsole.WriteLine("Presiona [Enter] para siguiente, [Backspace] para anterior, [Spacebar] para ver bitacora, [Esc] para salir.");

      if (InputHelper.ReadKey(ConsoleKey.Enter) && currentPage < totalPages - 1)
      {
        currentPage++;
      }
      else if (InputHelper.ReadKey(ConsoleKey.Backspace) && currentPage > 0)
      {
        currentPage--;
      }
      else if (InputHelper.ReadKey(ConsoleKey.Spacebar))
      {
        ShowBitacora(bitacoras);
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
        AddBitacora();
        break;
      case 2:
        GetBitacoras();
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
      StyleConsole.Title("BITACORA");
      StyleConsole.WriteLine("1.Agregar Bitacora del Dia", ConsoleColor.Green);
      StyleConsole.WriteLine("2.Ver bitacoras", ConsoleColor.Green);
      StyleConsole.Error($"{ScreenMain.ExitInput}. Volver");

      int op = InputHelper.ReadOption();

      if (op == ScreenMain.ExitInput) break;

      Navigator(op);
    }
  }
}