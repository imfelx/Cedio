using System.Text;
namespace Utils;

class StorageHelper
{
  public static void Save(string root, string[] lines)
  {
    using (StreamWriter write = new StreamWriter(root, false, Encoding.UTF8))
    {
      foreach (var line in lines)
      {
        write.WriteLine(line);
      }
    }
  }

  public static string[] Load(string root)
  {
    return File.Exists(root) ? File.ReadAllLines(root, Encoding.UTF8) : new string[0];
  }
}
