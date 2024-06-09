using Aminoko.TemplateGen.Converters;
using Aminoko.TemplateGen.Models;
using Antlr4.Runtime;

namespace Aminoko.TemplateGen;

/// <summary>
/// <inheritdoc cref="IFlashcardGenerator"/>
/// </summary>
/// <param name="templateVisitor"></param>
public class FlashcardGenerator : IFlashcardGenerator
{
    private readonly InlineConverterBase _inlineConverter;
    private readonly BlockConverterBase _blockConverter;
    private readonly IFlashcardBuilder _flashcardBuilder;

    public FlashcardGenerator(
        InlineConverterBase inlineConverter,
        BlockConverterBase blockConverter,
        IFlashcardBuilder flashcardBuilder)
    {
        _inlineConverter = inlineConverter;
        _blockConverter = blockConverter;
        _flashcardBuilder = flashcardBuilder;
    }

    public void SetStatementWord(string statementWord)
    {
        _inlineConverter.SetStatementWord(statementWord);
        _blockConverter.SetStatementWord(statementWord);
    }

    public void SetStatementSentence(string statementSentence) 
        => _inlineConverter.SetStatementSentence(statementSentence);

    public void SetStatementImage(string statementImage) 
        => _blockConverter.SetStatementImage(statementImage);

    public Flashcard GenerateFlashcard(string template)
    {
        var inputStream = new AntlrInputStream(template);
        var templateLexer = new TemplateLexer(inputStream);
        var templateTokenStream = new CommonTokenStream(templateLexer);
        var templateParser = new TemplateParser(templateTokenStream);
        var templateVisitor = new TemplateVisitor(_inlineConverter, _blockConverter, _flashcardBuilder);
        templateParser.template().Accept(templateVisitor);
        return _flashcardBuilder.Flashcard;
    }
}
