using System;
using System.Linq;
using JetBrains.ProjectModel;
using JetBrains.ReSharper.Plugins.FSharp.Psi.Impl.Tree;
using JetBrains.ReSharper.Plugins.FSharp.Psi.Parsing;
using JetBrains.ReSharper.Plugins.FSharp.Psi.Tree;
using JetBrains.ReSharper.Psi;
using JetBrains.ReSharper.Psi.ExtensionsAPI.Tree;
using JetBrains.ReSharper.Psi.Impl.Shared.InjectedPsi;
using JetBrains.ReSharper.Psi.Parsing;
using JetBrains.ReSharper.Psi.Tree;
using JetBrains.ReSharper.Resources.Shell;
using JetBrains.Text;
using JetBrains.Util.Logging;
using NVelocity.Runtime.Directive;

namespace JetBrains.ReSharper.Plugins.FSharp.Psi.Util.Literals.Injected
{
//  [SolutionComponent]
//  public sealed class FSharpLiteralInjectionTarget : IInjectionTargetLanguage
//  {
//    public bool ShouldInjectByAnnotation(ITreeNode originalNode, out string prefix, out string postfix)
//    {
//      prefix = null;
//      postfix = null;
//      return false;
//    }
//
//    public int GetStartOffsetForString(ITreeNode originalNode)
//    {
//      if (!(originalNode is FSharpString fsString)) return 1;
//
//      // " "
//      if (fsString.NodeType == FSharpTokenType.STRING)
//        return 1;
//      // @" "
//      if (fsString.NodeType == FSharpTokenType.VERBATIM_STRING)
//        return 2;
//      // """ """
//      if (fsString.NodeType == FSharpTokenType.TRIPLE_QUOTED_STRING)
//        return 3;
//      // " "B
//      if (fsString.NodeType == FSharpTokenType.BYTEARRAY)
//        return 1;
//      return 1;
//    }
//
//    public int GetEndOffsetForString(ITreeNode originalNode)
//    {
//      if (!(originalNode is FSharpString fsString)) return 1;
//
//      var length = fsString.Literal.GetText().Length;
//
//      //  " "
//      // @" "
//      if (fsString.NodeType == FSharpTokenType.STRING
//          || fsString.NodeType == FSharpTokenType.VERBATIM_STRING)
//        return length - 1;
//
//      // """ """
//      if (fsString.NodeType == FSharpTokenType.TRIPLE_QUOTED_STRING)
//        return length - 3;
//      // " "B
//      if (fsString.NodeType == FSharpTokenType.BYTEARRAY)
//        return length - 2;
//      return 1;
//    }
//
//    public bool SupportsRegeneration
//    {
//      get { return true; }
//    }
//
//    private string GetRangeBetweenOffsets(string text, int startOffset, int endOffset)
//    {
//      text = text.Substring(startOffset);
//      text = text.Substring(0, text.Length - endOffset);
//      return text;
//    }
//
//    public ITreeNode UpdateNode(IFile generatedFile, ITreeNode generatedNode, ITreeNode originalNode,
//      out int length, string prefix, string postfix, int startOffset, int endOffset)
//    {
//      if (!(originalNode is FSharpString fsString))
//      {
//        Logger.Fail("fsString is null");
//        length = -1;
//        return null;
//      }
//
//      var originalText = fsString.GetText();
//      var prepend = originalText.Substring(0, startOffset);
//      var append = originalText.Substring(originalText.Length - endOffset);
//
//      var textToInsert = generatedFile.GetText();
//      textToInsert = LiteralInjectorProviderUtil.ToOriginalText(textToInsert, prefix, postfix, startOffset, endOffset);
//      textToInsert = GetRangeBetweenOffsets(textToInsert, startOffset, endOffset);
//      textToInsert = prepend + textToInsert + append;
//
//      fsString.SetText(textToInsert);
//      length = textToInsert.Length;
//      return fsString;
//    }
//
//    private static readonly NodeTypeSet AllowedLiterals = new NodeTypeSet(
//      FSharpTokenType.STRING,
//      FSharpTokenType.VERBATIM_STRING,
//      FSharpTokenType.TRIPLE_QUOTED_STRING,
//      FSharpTokenType.BYTEARRAY);
//
//    public bool IsInjectionAllowed(ITreeNode literalNode)
//    {
//      if (!(literalNode is FSharpString fSharpString)) return false;
//
//      return AllowedLiterals[fSharpString.NodeType];
//    }
//
//    public string GetCorrespondingCommentTextForLiteral(ITreeNode originalNode)
//    {
//      // TODO
//      return null;
//    }
//
//    public IBuffer CreateBuffer(ITreeNode originalNode, string text, object options)
//    {
//      // TODO
//      return null;
//    }
//
//    public bool DoNotProcessNodeInterior(ITreeNode element)
//    {
//      // TODO
//      return false;
//    }
//
//    public bool IsPrimaryLanguageApplicable(IPsiSourceFile sourceFile)
//    {
//      return sourceFile.PrimaryPsiLanguage.Is<FSharpLanguage>();
//    }
//
//    public PsiLanguageType Language
//    {
//      get { return FSharpLanguage.Instance; }
//    }
//
//    public ILexerFactory CreateLexerFactory(LanguageService languageService)
//    {
//      return new FSharpLexerFactory();
//    }
//
//    public bool AllowsLineBreaks(ITreeNode originalNode)
//    {
//      if (!(originalNode is FSharpString fsString)) return false;
//
//      return fsString.NodeType == FSharpTokenType.VERBATIM_STRING
//             || fsString.NodeType == FSharpTokenType.TRIPLE_QUOTED_STRING;
//    }
//
//    public bool IsWhitespaceToken(ITokenNode token)
//    {
//      // TODO
//      var text = token.GetText();
//      return text == "\" \""
//             || text == "@\" \""
//             || text == "\"\"\" \"\"\""
//             || text == "\" \"B";
//    }
//
//    public TreeTextRange FixValueRangeForLiteral(ITreeNode element)
//    {
//      // TODO
//      return element.GetTreeTextRange();
//    }
//  }
}