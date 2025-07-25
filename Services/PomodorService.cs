using Utils;

namespace Services;

class PomodoroService
{
  static public void Pomodoro()
  {
    Contador(1, 25, "Work", true, 0, 4, 2);
  }

  static public void Contador(int minutos, int segundos, string condición, bool interructor, int x, int y, int vueltas)
  {
    int contador = 0;
    do
    {
      Console.Clear();
      StyleConsole.Title("POMODORO");
      string resultados;
      for (int i = minutos - 1; i >= 0; i--)
      {
        for (int j = segundos - 1; j >= 0; j--)
        {
          Console.SetCursorPosition(x, y);
          resultados = (j < 10) ? $"{condición}: {i}:0{j}" : $"{condición}: {i}:{j}";
          StyleConsole.Write(resultados, ConsoleColor.Blue);
          Thread.Sleep(1000);
        }
      }
      contador++;

      if (interructor)
      {
        bool validarEntrada = false;
        int opción = 0;
        do
        {
          Console.SetCursorPosition(x, y);
          StyleConsole.Error("Quieres tomar un Break 1/S o 2/N: ");
          string menu = Console.ReadLine()!;
          Console.SetCursorPosition(x, y);
          Console.Write("                                                       ");
          validarEntrada = int.TryParse(menu, out opción) && (opción == 1 || opción == 2);
        } while (!validarEntrada);

        if (opción == 1)
        {
          Contador(1, 5, "Break", false, x, y, 1);
          Console.SetCursorPosition(x, y);
          StyleConsole.Error("Preciona cualquier tecla para continuar...");
          Console.ReadKey();
        }
      }
    } while (contador != vueltas);
  }
}