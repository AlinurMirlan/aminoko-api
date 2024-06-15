using Aminoko.TemplateGen.Converters;
using Aminoko.TemplateGen.Models;
using Antlr4.Runtime;

namespace Aminoko.TemplateGen;

/// <summary>
/// <inheritdoc cref="IFlashcardGen"/>
/// </summary>
/// <param name="templateVisitor"></param>
public class FlashcardGen : IFlashcardGen
{
    private readonly InlineConverterBase _inlineConverter;
    private readonly BlockConverterBase _blockConverter;
    private readonly IFlashcardBuilder _flashcardBuilder;

    public FlashcardGen(
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
        _inlineConverter.StatementWord = statementWord;
        _blockConverter.StatementWord = statementWord;
    }

    public void SetStatementSentence(string statementSentence) 
        => _inlineConverter.StatementSentence = statementSentence;

    public void SetStatementImage(string statementImage) 
        => _blockConverter.StatementImage = statementImage;

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
