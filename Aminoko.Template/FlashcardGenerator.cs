using Antlr4.Runtime;

namespace Aminoko.Template;

/// <summary>
/// <inheritdoc cref="IFlashcardGenerator"/>
/// </summary>
/// <param name="templateVisitor"></param>
public class FlashcardGenerator(
    IInlineConverter inlineConverter,
    IBlockConverter blockConverter,
    IFlashcardBuilder flashcardBuilder) 
    : IFlashcardGenerator
{
    public Flashcard GenerateFlashcard(string template)
    {
        var inputStream = new AntlrInputStream(template);
        var templateLexer = new TemplateLexer(inputStream);
        var templateTokenStream = new CommonTokenStream(templateLexer);
        var templateParser = new TemplateParser(templateTokenStream);
        var templateVisitor = new TemplateVisitor(inlineConverter, blockConverter, flashcardBuilder);
        templateParser.template().Accept(templateVisitor);
        return flashcardBuilder.Flashcard;
    }
}
