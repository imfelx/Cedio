using Utils;

namespace Data;

class IdeaData
{
  private const string IdeasRoot = "Storage/Ideas.txt";
  private const string PromblemsRoot = "Storage/Problems.txt";
  private const string TechnosRoot = "Storage/Techno.txt";
  private const string ContrasRoot = "Storage/Contra.txt";
  public static string[] ideas = new string[0];
  public static string[] promblem = new string[0];
  public static string[] techno = new string[0];
  public static string[] contra = new string[0];

  public static void Load()
  {
    ideas = StorageHelper.Load(IdeasRoot);
    promblem = StorageHelper.Load(PromblemsRoot);
    techno = StorageHelper.Load(TechnosRoot);
    contra = StorageHelper.Load(ContrasRoot);
  }

  public static void Save() =>
    StorageHelper.Save(IdeasRoot, ideas);

  public static string[] AddIdea(string idea)
  {
    if (string.IsNullOrWhiteSpace(idea))
    {
      StyleConsole.Error("La idea que intenta agregar esta vacia. Intente nuevamente.");
      return ideas;
    }

    if (ideas == new string[0])
    {
      ideas = new string[] { idea };
      return ideas;
    }

    string[] newArr = new string[ideas.Length + 1];

    for (int i = 0; i < ideas.Length; i++)
    {
      newArr[i] = ideas[i];
    }

    newArr[ideas.Length] = idea;

    ideas = newArr;

    return ideas;
  }
}