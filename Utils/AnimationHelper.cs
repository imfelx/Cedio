namespace Utils;

class AnimationHelper
{
  public static void LoadingAnimation(string text = "Cargando", double duration = 2)
  {
    int counter = 0;
    DateTime endTIme = DateTime.Now.AddSeconds(duration);

    StyleConsole.Write(text);
    while (DateTime.Now < endTIme)
    {
      StyleConsole.Write(".");
      counter++;
      Thread.Sleep(100);

      if (Console.KeyAvailable && InputHelper.ReadKey(ConsoleKey.Spacebar))
      {
        Sound.StopSound();
        break;
      }
    }
  }
  public static void SpinnerAnimation(double duration)
  {
    char[] spinner = { '|', '/', '-', '\\' };
    int counter = 0;
    DateTime endTIme = DateTime.Now.AddSeconds(duration);

    while (DateTime.Now < endTIme)
    {
      StyleConsole.Write($"\r{spinner[counter % spinner.Length]}");
      counter++;
      Thread.Sleep(100);

      if (Console.KeyAvailable && InputHelper.ReadKey(ConsoleKey.Spacebar))
      {
        Sound.StopSound();
        break;
      }
    }
  }
  public static string LoopAnimation(string[] arr, string selected, double duration = 5, bool capital = false, ConsoleColor endColor = ConsoleColor.Green)
  {
    bool skip = false;

    ConsoleColor[] colores = { ConsoleColor.Blue, ConsoleColor.Yellow, ConsoleColor.Green, ConsoleColor.Red, ConsoleColor.Magenta };
    int counter = 0;
    DateTime endTime = DateTime.Now.AddSeconds(duration);

    int maxLength = arr.Max(s => s.Length);
    int baseDelay = 50;
    int delay = baseDelay;

    while (DateTime.Now < endTime)
    {
      double tiempoRestante = (endTime - DateTime.Now).TotalSeconds;

      if (tiempoRestante < duration * 0.4) delay = baseDelay + 30;
      if (tiempoRestante < duration * 0.2) delay = baseDelay + 70;

      string a = arr[counter % arr.Length].PadRight(maxLength);
      StyleConsole.Write($"\r{a}", colores[counter % colores.Length]);

      counter++;
      Thread.Sleep(delay);

      if (Console.KeyAvailable && InputHelper.ReadKey(ConsoleKey.Spacebar))
      {
        Sound.StopSound();
        skip = true;
        break;
      }
    }

    string resultadoFinal = selected.PadRight(maxLength);
    StyleConsole.Write($"\r{resultadoFinal}\n", endColor);
    if (!skip) Thread.Sleep(1000 * 2);

    return selected;
  }
}