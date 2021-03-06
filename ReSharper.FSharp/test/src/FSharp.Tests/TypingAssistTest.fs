namespace rec JetBrains.ReSharper.Plugins.FSharp.Tests.Features.TypingAssist

open System.IO
open JetBrains.ProjectModel
open JetBrains.ReSharper.FeaturesTestFramework.TypingAssist
open JetBrains.ReSharper.Plugins.FSharp.Common.Util
open JetBrains.ReSharper.Plugins.FSharp.Psi.Features.TypingAssist
open JetBrains.ReSharper.Plugins.FSharp.Services.Formatter
open JetBrains.ReSharper.Plugins.FSharp.Tests
open JetBrains.ReSharper.Psi.CachingLexers
open JetBrains.ReSharper.TestFramework
open JetBrains.TextControl
open NUnit.Framework

[<FSharpTest>]
[<TestSettingsKey(typeof<FSharpFormatSettingsKey>)>]
type FSharpTypingAssistTest() =
    inherit TypingAssistTestBase()

    override x.RelativeTestDataPath = "features/service/typingAssist"

    [<Test>] member x.``Enter 00 - File beginning``() = x.DoNamedTest()
    [<Test>] member x.``Enter 01 - No indent``() = x.DoNamedTest()
    [<Test>] member x.``Enter 02 - Dumb indent``() = x.DoNamedTest()
    [<Test>] member x.``Enter 03 - Dumb indent, trim spaces``() = x.DoNamedTest()
    [<Test>] member x.``Enter 04 - Dumb indent, empty line``() = x.DoNamedTest()

    [<Test>] member x.``Enter 05 - Indent after =``() = x.DoNamedTest()
    [<Test>] member x.``Enter 06 - Indent after = and spaces``() = x.DoNamedTest()
    [<Test>] member x.``Enter 07 - Indent after = and spaces, comments``() = x.DoNamedTest()
    [<Test>] member x.``Enter 08 - Indent after = and line with spaces``() = x.DoNamedTest()
    [<Test>] member x.``Enter 09 - Indent after = and line with comments``() = x.DoNamedTest()
    [<Test>] member x.``Enter 10 - Indent after = and line with source``() = x.DoNamedTest()

    [<Test>] member x.``Enter 11 - Left paren``() = x.DoNamedTest()
    [<Test>] member x.``Enter 12 - Left paren and eol space``() = x.DoNamedTest()
    [<Test>] member x.``Enter 13 - Left paren and space before``() = x.DoNamedTest()
    [<Test>] member x.``Enter 14 - List, first element``() = x.DoNamedTest()
    [<Test>] member x.``Enter 15 - List, last element``() = x.DoNamedTest()

    [<Test>] member x.``Enter 16 - After list``() = x.DoNamedTest()
    [<Test>] member x.``Enter 17 - After multiple continued lines``() = x.DoNamedTest()
    [<Test>] member x.``Enter 18 - After single continued line``() = x.DoNamedTest()
    [<Test>] member x.``Enter 19 - After pair starting at line start``() = x.DoNamedTest()

    [<Test>] member x.``Enter 20 - Nested indent after =``() = x.DoNamedTest()
    [<Test>] member x.``Enter 21 - Nested indent after = and comments``() = x.DoNamedTest()

    [<Test>] member x.``Enter 22 - Indent after = 2``() = x.DoNamedTest()
    [<Test>] member x.``Enter 23 - After new line ctor and =``() = x.DoNamedTest()
    [<Test>] member x.``Enter 24 - Add indent after continued line``() = x.DoNamedTest()
    [<Test>] member x.``Enter 25 - Add indent after continued line before block``() = x.DoNamedTest()

    [<Test>] member x.``Enter 26 - Empty line, add indent from below``() = x.DoNamedTest()
    [<Test>] member x.``Enter 27 - Empty line, dump indent``() = x.DoNamedTest()
    [<Test>] member x.``Enter 28 - No indent after else and new line``() = x.DoNamedTest()

    [<Test>] member x.``Enter 29 - No indent before source``() = x.DoNamedTest()
    [<Test>] member x.``Enter 30 - No indent before source 2``() = x.DoNamedTest()
    [<Test>] member x.``Enter 31 - Inside empty ctor``() = x.DoNamedTest()
    [<Test>] member x.``Enter 32 - Nested binding``() = x.DoNamedTest()
    [<Test>] member x.``Enter 33 - After then on line with multiple parens in row``() = x.DoNamedTest()
    [<Test>] member x.``Enter 34 - After line with multiple parens in row``() = x.DoNamedTest()
    [<Test>] member x.``Enter 35 - Nested binding and indent``() = x.DoNamedTest()

    [<Test>] member x.``Enter 36 - Indent after =, trim before source``() = x.DoNamedTest()
    [<Test>] member x.``Enter 37 - After first list element, trim before source``() = x.DoNamedTest()

    [<Test>] member x.``Enter 38 - Empty list``() = x.DoNamedTest()
    [<Test>] member x.``Enter 39 - Empty list with spaces``() = x.DoNamedTest()
    [<Test>] member x.``Enter 40 - Empty list continuing line``() = x.DoNamedTest()
    [<Test>] member x.``Enter 41 - Empty array continuing line``() = x.DoNamedTest()
    [<Test>] member x.``Enter 42 - Before first list element and new line``() = x.DoNamedTest()
    [<Test>] member x.``Enter 43 - Before first list element``() = x.DoNamedTest()
    [<Test>] member x.``Enter 44 - Before first list element and spaces``() = x.DoNamedTest()
    [<Test>] member x.``Enter 45 - Before first list element in multiline brackets``() = x.DoNamedTest()

    [<Test>] member x.``Space 01 - Inside empty list``() = x.DoNamedTest()
    [<Test>] member x.``Space 02 - Inside empty array``() = x.DoNamedTest()
    [<Test>] member x.``Space 03 - Inside empty quotation, typed``() = x.DoNamedTest()
    [<Test>] member x.``Space 04 - Inside empty quotation, untyped``() = x.DoNamedTest()
    [<Test>] member x.``Space 05 - Inside empty quotation, no assist``() = x.DoNamedTest()
    [<Test>] member x.``Space 06 - Inside operator, no assist``() = x.DoNamedTest()
    [<Test>] member x.``Space 07 - Inside empty array, no assist``() = x.DoNamedTest()
    [<Test>] member x.``Space 08 - Inside empty braces``() = x.DoNamedTest()

[<FSharpTest>]
type LineIndentsTest() =
    inherit LineIndentsTestBase()

    [<Test>] member x.``Indents``() = x.DoNamedTest()

    override x.DoLineTest(writer, textControl, line) =
        writer.WriteLine(getLineIndent x.CachingLexerService textControl line)

[<FSharpTest>]
type NestedIndentsTest() =
    inherit LineIndentsTestBase()

    [<Test>] member x.``Nested indents``() = x.DoNamedTest()

    override x.DoLineTest(writer, textControl, line) =
        writer.WriteLine(tryGetNestedIndentBelowLine x.CachingLexerService textControl line)
        
[<AbstractClass>]
type LineIndentsTestBase() =
    inherit BaseTestWithTextControl()

    override x.RelativeTestDataPath = "features/service/typingAssist"

    member x.CachingLexerService =
        x.Solution.GetComponent<CachingLexerService>()

    abstract DoLineTest: TextWriter * ITextControl * Line -> unit 

    override x.DoTest(project: IProject) =
        use textControl = x.OpenTextControl(project)
        let linesCount = int (textControl.Document.GetLineCount())
        x.ExecuteWithGold(fun writer ->
            for i in 1 .. linesCount do
                x.DoLineTest(writer, textControl, docLine (i - 1))) |> ignore
