using System;
using JetBrains.ReSharper.Plugins.FSharp.Psi.Parsing;
using JetBrains.ReSharper.Psi;
using JetBrains.ReSharper.Psi.ExtensionsAPI.Tree;
using JetBrains.ReSharper.Psi.Tree;
using JetBrains.ReSharper.Resources.Shell;

namespace JetBrains.ReSharper.Plugins.FSharp.Psi.Impl.Tree
{
    public class FSharpString : FSharpToken, ILiteralExpression
    {
        public FSharpString(NodeType nodeType, string text) : base(nodeType, text)
        {
        }

        public ConstantValue ConstantValue => ClrConstantValueFactory.CreateStringValue(GetText(), GetPsiModule());

        public ExpressionAccessType GetAccessType() => ExpressionAccessType.Read;
        public bool IsConstantValue() => true;
        public ITokenNode Literal => this;

        public IType Type() => GetPsiModule().GetPredefinedType().String; // todo: ByteArray strings
        public IExpressionType GetExpressionType() => Type();
        public IType GetImplicitlyConvertedTo() => Type();
        
        public void SetText(string literalText)
        {
            var tokenType = Literal.GetTokenType();

            if (tokenType == FSharpTokenType.STRING
                || tokenType == FSharpTokenType.VERBATIM_STRING
                || tokenType == FSharpTokenType.TRIPLE_QUOTED_STRING
                || tokenType == FSharpTokenType.VERBATIM_BYTEARRAY)
            {
                var literal = tokenType.Create(literalText);
                using (WriteLockCookie.Create(IsPhysical()))
                {
                    ModificationUtil.ReplaceChild(Literal, literal);
                }
            }
            else
            {
                throw new InvalidOperationException("Invalid token type " + tokenType);
            }
        }
    }
}
