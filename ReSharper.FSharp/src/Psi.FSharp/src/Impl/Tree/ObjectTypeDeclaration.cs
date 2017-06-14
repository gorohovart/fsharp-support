﻿﻿using JetBrains.ReSharper.Psi.FSharp.Impl.Cache2;
using JetBrains.ReSharper.Psi.FSharp.Tree;
 using JetBrains.Util.Extension;

namespace JetBrains.ReSharper.Psi.FSharp.Impl.Tree
{
  internal partial class ObjectTypeDeclaration
  {
    private const string Interface = "Interface";
    private const string AbstractClass = "AbstractClass";
    private const string Class = "Class";
    private const string Sealed = "Sealed";
    private const string Struct = "Struct";

    public override string DeclaredName => FSharpImplUtil.GetCompiledName(Identifier, Attributes);
    public override string SourceName => FSharpImplUtil.GetSourceName(Identifier);

    public override TreeTextRange GetNameRange()
    {
      return Identifier.GetNameRange();
    }

    public FSharpPartKind TypePartKind
    {
      get
      {
        foreach (var attr in AttributesEnumerable)
        {
          var attrIds = attr.LongIdentifier.Identifiers;
          if (attrIds.IsEmpty)
            continue;

          switch (attrIds.Last()?.GetText().SubstringBeforeLast("Attribute"))
          {
            case Interface:
              return FSharpPartKind.Interface;
            case AbstractClass:
            case Sealed:
            case Class:
              return FSharpPartKind.Class;
            case Struct:
              return FSharpPartKind.Struct;
          }
        }

        // ReSharper disable once LoopCanBeConvertedToQuery
        foreach (var member in TypeMembersEnumerable)
          if (!(member is IInterfaceInherit) && !(member is IAbstractSlot))
            return FSharpPartKind.Class;

        return FSharpPartKind.Interface;
      }
    }
  }
}