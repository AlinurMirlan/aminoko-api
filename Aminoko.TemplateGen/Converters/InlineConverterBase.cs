namespace Aminoko.TemplateGen.Converters;

public abstract class InlineConverterBase : IInlineConverter
{
    private string? _statementWord;
    private string? _statementSentence;

    public string StatementWord
    {
        get => _statementWord ?? throw new InvalidOperationException($"{nameof(StatementWord)} is not set.");
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(value));
            }

            _statementWord = value;
        }
    }

    public string StatementSentence
    {
        get => _statementSentence ?? throw new InvalidOperationException($"{nameof(StatementSentence)} is not set.");
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(value));
            }

            _statementSentence = value;
        }
    }

    public virtual string InlineStatementWord() => StatementWord;

    public virtual string InlineStatementSentence() => StatementSentence;

    public virtual string InlineStatement(string inputString) => inputString;

    public virtual string InlineString(string @string) => @string;

    public virtual string InlineText(string text) => text;

    public abstract string InlineStatementMethodQuery(string inputString);

    public abstract string InlineStatementMethodTranslate(string inputString);
}