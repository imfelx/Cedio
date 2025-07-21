namespace Utils;

class AnimationHelper
{
  public static void LoadingAnimation(string text, double duracion)
  {
    int counter = 0;
    DateTime endTIme = DateTime.Now.AddSeconds(duracion);

    StyleConsole.Write(text);
    while (DateTime.Now < endTIme)
    {
      StyleConsole.Write(".");
      counter++;
      Thread.Sleep(100);

      if (Console.KeyAvailable && InputHelper.LeerTecla(ConsoleKey.Spacebar))
      {
        Sound.StopSound();
        break;
      }
    }
  }
  public static void SpinnerAnimation(double duracion)
  {
    char[] spinner = { '|', '/', '-', '\\' };
    int counter = 0;
    DateTime endTIme = DateTime.Now.AddSeconds(duracion);

    while (DateTime.Now < endTIme)
    {
      StyleConsole.Write($"\r{spinner[counter % spinner.Length]}");
      counter++;
      Thread.Sleep(100);

      if (Console.KeyAvailable && InputHelper.LeerTecla(ConsoleKey.Spacebar))
      {
        Sound.StopSound();
        break;
      }
    }
  }
}