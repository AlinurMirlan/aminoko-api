namespace Aminoko.Template.Converters;

public interface IInlineConverter
{
    public string InlineStatementWord();

    public string InlineStatementSentence();

    public string InlineStatementMethodTranslate(string inputString);

    public string InlineStatementMethodQuery(string inputString);

    public string InlineStatement(string statement);

    public string InlineText(string text);

    public string InlineString(string @string);
}
