using Aminoko.Api.Services.ContentGeneration;
using Aminoko.TemplateGen.Converters;

namespace Aminoko.Api.Services.Generation;

public class InlineConverter : InlineConverterBase
{
    private readonly ITextGenerator _textGenerator;
    private readonly ITranslationGenerator _translationGenerator;

    public InlineConverter(
        ITextGenerator textGenerator,
        ITranslationGenerator translationGenerator)
    {
        _textGenerator = textGenerator;
        _translationGenerator = translationGenerator;
    }

    public override string InlineStatementMethodQuery(string inputString) =>
        _textGenerator.GenerateText(inputString);

    public override string InlineStatementMethodTranslate(string inputString) =>
        _translationGenerator.GenerateTranslation(inputString);
}
