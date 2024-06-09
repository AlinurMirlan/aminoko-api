namespace Aminoko.TemplateGen.Converters;

public abstract class InlineConverterBase : IInlineConverter
{
    public string? StatementWord { get; private set; }

    public string? StatementSentence { get; private set; }

    public void SetStatementWord(string statementWord)
    {
        StatementWord = statementWord;
    }

    public void SetStatementSentence(string statementSentence)
    {
        StatementSentence = statementSentence;
    }

    public virtual string InlineStatementWord() =>
        StatementWord ?? throw new InvalidOperationException($"{nameof(StatementWord)} is not set.");

    public virtual string InlineStatementSentence() =>
        StatementSentence ?? throw new InvalidOperationException($"{nameof(StatementSentence)} is not set.");

    public virtual string InlineStatement(string inputString) => inputString;

    public virtual string InlineString(string @string) => @string;

    public virtual string InlineText(string text) => text;

    public abstract string InlineStatementMethodQuery(string inputString);

    public abstract string InlineStatementMethodTranslate(string inputString);
}