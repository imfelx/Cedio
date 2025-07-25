using Data;
using Utils;

namespace Services;

class GeneratorServices
{
  private static string[] ideas = IdeaData.ideas;
  private static string[] promblem = IdeaData.promblem;
  private static string[] techno = IdeaData.techno;
  private static string[] contra = IdeaData.contra;
  private static Random random = new Random();

  private static bool PastConvination(string text)
  {
    for (int i = 0; i < ideas.Length; i++)
    {
      if (text == ideas[i]) return true;
    }
    return false;
  }

  private static string? IdeaGenerator()
  {
    string idea;
    int totalConvinations = promblem.Length * techno.Length * contra.Length;

    if (ideas.Length == totalConvinations) return null;

    do
    {
      idea = AnimationHelper.LoopAnimation(promblem, TextHelper.CapitalText(promblem[random.Next(promblem.Length)]));
      idea += $" {AnimationHelper.LoopAnimation(techno, techno[random.Next(techno.Length)])}";
      idea += $" {AnimationHelper.LoopAnimation(contra, contra[random.Next(contra.Length)])}";
    } while (PastConvination(idea));

    return idea;
  }

  public static void Generator()
  {
    while (true)
    {
      Console.Clear();
      StyleConsole.Title("GENERANDO IDEA...");
      string? idea = IdeaGenerator();

      if (idea == null)
      {
        StyleConsole.Error("Ya no hay más combinaciones posibles.");
        return;
      }

      Console.Clear();
      StyleConsole.Title("IDEA");
      StyleConsole.WriteLine($"💡 Idea loca generada:", ConsoleColor.Cyan);
      StyleConsole.WriteLine(idea, ConsoleColor.Green);


      FraseService.MostrarFraseAleatoria();
      StyleConsole.Write("\n¿Deseas guardar esta idea? (s = sí / cualquier otra tecla = no / x = salir): ");
      string input = Console.ReadLine()?.Trim().ToLower() ?? "";

      if (input == "s")
      {
        IdeaData.AddIdea(idea);
        StyleConsole.WriteLine("✅ Idea guardada exitosamente.\n", ConsoleColor.Green);
      }
      else if (input == "x")
      {
        StyleConsole.Error("🚪 Saliendo del generador...");
        return;
      }
      else
      {
        StyleConsole.Error("❌ Idea descartada. Generando otra...\n");
      }
    }
  }

}