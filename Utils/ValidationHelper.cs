namespace Utils;

class ValidationHelper
{
  public static bool ValidarIndice(int i, string[]? array, string type)
  {
    if (array == null || array.Length == 0)
    {
      StyleConsole.Error($"No hay {type} cargados.");
      return false;
    }

    if (i < 0 || i >= array.Length)
    {
      StyleConsole.Error("Índice fuera de rango.");
      return false;
    }
    return true;
  }
  public static bool ValidarIndiceArrayDoble(int i, string[][]? array, string type)
  {
    if (array == null || array.Length == 0)
    {
      StyleConsole.Error($"No hay {type} cargados.");
      return false;
    }

    if (i < 0 || i >= array.Length)
    {
      StyleConsole.Error("Índice fuera de rango.");
      return false;
    }

    return true;
  }
}