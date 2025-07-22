namespace Utils;

class TextHelper
{
  public static string CapitalText(string text)
  {
    if (string.IsNullOrWhiteSpace(text)) return text;

    return char.ToUpper(text[0]) + text.Substring(1);
  }
}