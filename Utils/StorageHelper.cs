using System.Text;
namespace Utils;

class StorageHelper
{
  public static void Save(string path, string[] lines)
  {
    using (StreamWriter write = new StreamWriter(path, false, Encoding.UTF8))
    {
      foreach (var line in lines)
      {
        write.WriteLine(line);
      }
    }
  }

  public static string[] Load(string path)
  {
    return File.Exists(path) ? File.ReadAllLines(path, Encoding.UTF8) : new string[0];
  }
}
