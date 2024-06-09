namespace Aminoko.TemplateGen.Converters;

public interface IInlineConverter
{
    public string InlineStatementWord();

    public string InlineStatementSentence();

    public string InlineStatement(string inputString);

    public string InlineStatementMethodQuery(string inputString);

    public string InlineStatementMethodTranslate(string inputString);

    public string InlineString(string @string);

    public string InlineText(string text);
}
