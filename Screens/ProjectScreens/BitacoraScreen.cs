using Data;
using Screen;
using Utils;

class BitacoraScreen
{
  private static string[] bitacora = ProjectData.bitacora;
  private static string[][] bitacoras = new string[0][];

  private static void AddBitacora()
  {
    StyleConsole.Title($"BITACORA {DateTime.Now}");
    string bit = InputHelper.ReadString("Escribe tu bitacora", true);

    bitacora = ProjectData.AddBitacora(bit);
  }
  private static void GetBitacoras()
  {
    int pageSize = 25;
    int currentPage = 0;
    bitacoras = new string[bitacora.Length][];

    int totalPages = (bitacoras.Length + pageSize - 1) / pageSize;

    for (int i = 0; i < bitacora.Length; i++)
    {
      bitacoras[i] = bitacora[i].Split(" || ");
    }

    static void ShowBitacora()
    {
      int op;
      do
      {
        op = InputHelper.ReadNum("Ingresa el indice de la bitacora") - 1;
      } while (op < 0 || op >= bitacora.Length);

      Console.Clear();
      StyleConsole.Title($"BITACORA {bitacoras[op][0]}");
      StyleConsole.WriteLine(bitacoras[op][1]);
      InputHelper.Continuar();
    }

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
      StyleConsole.WriteLine("Presiona [Spacebar] para siguiente, [Backspace] para anterior, [Enter] para ver bitacora, [Esc] para salir.");

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
        ShowBitacora();
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