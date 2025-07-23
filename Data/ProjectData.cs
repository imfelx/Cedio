using Utils;

namespace Data;

class ProjectData
{
  private const string ProjectsPath = "Storage/projects";
  public static int ProjectsIndex = -1;
  public static string[] bitacora = new string[0];

  public static void Saveprojects(int i)
  {
    string projectsPath = Path.Combine(ProjectsPath, $"{i}");

    if (!Directory.Exists(projectsPath))
    {
      Directory.CreateDirectory(projectsPath);
    }
    if (!Directory.Exists(projectsPath))
    {
      Directory.CreateDirectory(projectsPath);
    }

    StorageHelper.Save(Path.Combine(projectsPath, "bitacora.txt"), bitacora);
  }

  public static void Loadprojects(int i)
  {
    string projectsPath = Path.Combine(ProjectsPath, $"{i}");

    bitacora = StorageHelper.Load(Path.Combine(projectsPath, "bitacora.txt"));
  }

  public static string[] AddBitacora(string bit)
  {

    if (bitacora == new string[0])
    {
      bitacora = new string[] { bit };
      return bitacora;
    }

    string[] newArr = new string[bitacora.Length + 1];

    for (int i = 0; i < bitacora.Length; i++)
    {
      newArr[i] = bitacora[i];
    }

    newArr[bitacora.Length] = $"{DateTime.Now} || {bit}";

    bitacora = newArr;

    return bitacora;
  }

  public static string[][] GetBitacora()
  {
    string[][] bitacoras = new string[bitacora.Length][];

    for (int i = 0; i < bitacora.Length; i++)
    {
      bitacoras[i] = bitacora[i].Split(" || ");
    }

    return bitacoras;
  }
}