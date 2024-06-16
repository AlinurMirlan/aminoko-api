using Aminoko.Api.Services.ContentGeneration;
using Aminoko.TemplateGen.Converters;

namespace Aminoko.Api.Services.ContentConversion;

public class InlineConverter : InlineConverterBase
{
    private readonly ITextGenerator _textGenerator;
    private readonly ITranslationGenerator _translationGenerator;

    public InlineConverter(
        ITextGenerator textGenerator,
        ITranslationGenerator translationGenerator)
    {
        _textGenerator = textGenerator ?? throw new ArgumentNullException(nameof(textGenerator));
        _translationGenerator = translationGenerator ?? throw new ArgumentNullException(nameof(translationGenerator));
    }

    public override string InlineStatementMethodQuery(string inputString) =>
        _textGenerator.GenerateTextAsync(inputString).Result;

    public override string InlineStatementMethodTranslate(string inputString) =>
        _translationGenerator.GenerateTranslationAsync(inputString).Result;
}
