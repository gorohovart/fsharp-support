using System;
using System.Collections.Generic;
using JetBrains.DataFlow;
using JetBrains.ProjectModel;
using JetBrains.ProjectModel.Resources;
using JetBrains.ReSharper.Plugins.FSharp.Psi.Impl.Tree;
using JetBrains.ReSharper.Psi;
using JetBrains.ReSharper.Psi.Caches;
using JetBrains.ReSharper.Psi.CSharp.Util;
using JetBrains.ReSharper.Psi.impl.Shared.References;
using JetBrains.ReSharper.Psi.Impl.Shared.InjectedPsi;
using JetBrains.ReSharper.Psi.Impl.Shared.References.Universal;
using JetBrains.ReSharper.Psi.Resolve;
using JetBrains.ReSharper.Psi.Tree;
using JetBrains.UI.Icons;
using JetBrains.Util;

namespace JetBrains.ReSharper.Plugins.FSharp.Psi.Util.Literals.Injected
{
//  [SolutionComponent]
//  public class FSharpPathReferenceProvider : ReferenceInjectorProviderInLiteralsWithRangeMarkersBase<FSharpString,
//      FSharpLiteralInjectionTarget>,
//    IUniversalPathReferenceProvider
//  {
//    public FSharpPathReferenceProvider(Lifetime lifetime, ISolution solution,
//      IPersistentIndexManager persistentIndexManager, InjectionNodeProvidersViewer providersViewer,
//      FSharpLiteralInjectionTarget injectionTargetLanguage) : base(lifetime, solution, persistentIndexManager,
//      providersViewer, injectionTargetLanguage)
//    {
//    }
//
//    public override IconId Icon
//    {
//      get { return ProjectModelThemedIcons.Directory.Id; }
//    }
//
//    public override string ProvidedInjectionID
//    {
//      get { return InjectedLanguageIDs.PathReference; }
//    }
//
//    public override PsiLanguageType SupportedOriginalLanguage
//    {
//      get { return FSharpLanguage.Instance; }
//    }
//
//    public IEnumerable<Tuple<TreeTextRange, string>> GetPathReferenceInfos(ITreeNode element)
//    {
//      return UniversalPathReferenceUtil.GetPathReferenceInfos(element, GetStartOffset(element),
//        GetEndOffset(element), ParseLiteral);
//    }
//
//    private static Tuple<string, RangeTranslator> ParseLiteral(string arg)
//    {
//      var parsed = FSharpStringLiteralParser.ParseStringLiteral(arg, out var translator);
//      return Tuple.Create(parsed, translator);
//    }
//
//    public IReference BindReference(UniversalPathReference universalPathReference, IDeclaredElement declaredElement)
//    {
//      return universalPathReference; //TODO
//    }
//  }
}