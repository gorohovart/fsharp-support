using System;
using JetBrains.Annotations;
using JetBrains.ReSharper.Psi.CSharp.Util;
using JetBrains.Util;

namespace JetBrains.ReSharper.Plugins.FSharp.Psi.Util
{
  public static class FSharpStringLiteralParser
  {
    private static readonly RangeTranslator myEmptyRangeTranslator = new RangeTranslator();

    private static bool StartsAndEndsWith(this string text, string start, string end) =>
      text.StartsWith(start, StringComparison.Ordinal)
      && text.Length >= start.Length + end.Length
      && text.EndsWith(end, StringComparison.Ordinal);

    public static bool TryGetRawFromRegularString(string text, out string rawText)
    {
      if (text.StartsAndEndsWith("\"", "\""))
      {
        rawText = text.Substring(1, text.Length - 1 - 1);
        return true;
      }

      rawText = "";
      return false;
    }
    
    public static bool TryGetRawFromVerbatimString(string text, out string rawText)
    {
      if (text.StartsAndEndsWith("@\"", "\""))
      {
        rawText = text.Substring(2, text.Length - 2 - 1);
      }

      rawText = "";
      return false;
    }
    
    public static bool TryGetRawFromTripleQuotedString(string text, out string rawText)
    {
      if (text.StartsAndEndsWith("\"\"\"", "\"\"\""))
      {
        rawText = text.Substring(3, text.Length - 3 - 3);
      }

      rawText = "";
      return false;
    }
    
    public static bool TryGetRawFromByteArray(string text, out string rawText)
    {
      if (text.StartsAndEndsWith("\"", "\"B"))
      {
        rawText = text.Substring(1, text.Length - 1 - 2);
        return true;
      }

      rawText = "";
      return false;
    }
    
    public static string ParseStringLiteral([NotNull] string literalText, [NotNull] out RangeTranslator translator)
    {
      string rawText;
      
      if (TryGetRawFromRegularString(literalText, out rawText))
      {
        return CSharpStringLiteralParser.ParseRegularLiteralValue(rawText, out translator);
      }
      
      if (TryGetRawFromVerbatimString(literalText, out rawText))
      {
        return CSharpStringLiteralParser.ParseVerbatimLiteralValue(rawText, out translator);
      }
      
      if (TryGetRawFromTripleQuotedString(literalText, out rawText))
      {
        return ParseTripleQuotedString(rawText, out translator);
      }
      
      if (TryGetRawFromByteArray(literalText, out rawText))
      {
        // TODO: except unicode strings
        return CSharpStringLiteralParser.ParseRegularLiteralValue(rawText, out translator);
      }

      translator = myEmptyRangeTranslator;
      return null;
    }
    
    [CanBeNull]
    public static string ParseTripleQuotedString([NotNull] string text, [NotNull] out RangeTranslator translator)
    {
      translator = new RangeTranslator();
      translator.StartMapping(text.Length);
      translator.EndMapping(text.Length);
      return text;
    }
  }
}