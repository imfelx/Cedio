using Utils;

namespace Data;

class ProjectData
{
  private const string ProjectsPath = "Storage/projects";
  public static int ProjectsIndex = -1;
  public static string[] bitacora = new string[0];

  public static void Saveproject()
  {
    string projectsPath = Path.Combine(ProjectsPath, $"{ProjectsIndex}");

    if (!Directory.Exists(ProjectsPath))
    {
      Directory.CreateDirectory(ProjectsPath);
    }
    if (!Directory.Exists(projectsPath))
    {
      Directory.CreateDirectory(projectsPath);
    }

    StorageHelper.Save(Path.Combine(projectsPath, "bitacora.txt"), bitacora);
  }

  public static void Loadproject(int i)
  {
    ProjectsIndex = i;
    string projectsPath = Path.Combine(ProjectsPath, $"{ProjectsIndex}");

    bitacora = StorageHelper.Load(Path.Combine(projectsPath, "bitacora.txt"));
  }

  public static string[] AddBitacora(string bit)
  {

    if (bitacora.Length == 0)
    {
      bitacora = new string[] { $"{DateTime.Now} || {bit}" };
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
}