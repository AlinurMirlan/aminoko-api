namespace Aminoko.Template;

public class InlineConverter : IInlineConverter
{
    public string InlineStatementMethodQuery(string inputString)
    {
        throw new NotImplementedException();
    }

    public string InlineStatementMethodTranslate(string inputString)
    {
        throw new NotImplementedException();
    }

    public string InlineStatementSentence()
    {
        throw new NotImplementedException();
    }

    public string InlineStatementWord()
    {
        throw new NotImplementedException();
    }

    public string InlineString(string @string) => @string;

    public string InlineText(string text) => text;

    public string InlineStatement(string statement) => statement;

}
