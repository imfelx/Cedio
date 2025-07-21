using Utils;
using Screen;

internal class Program
{
  private static void Main(string[] args)
  {
    if (!OperatingSystem.IsWindows())
    {
      StyleConsole.Error("No se podran reproducir los sonidos en este sistema operativo.");
    }

    ScreenMain.Main();
  }
}