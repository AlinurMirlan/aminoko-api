namespace Aminoko.TemplateGen.Converters;

public abstract class BlockConverterBase : IBlockConverter
{
    private string? _statementWord;
    private string? _statementImage;

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

    public string StatementImage
    {
        get => _statementImage ?? throw new InvalidOperationException($"{nameof(StatementImage)} is not set.");
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(value));
            }

            _statementImage = value;
        }
    }

    public virtual string BlockText(string text) => text;

    public abstract string BlockStatementDefinition();

    public string BlockStatementImage() => throw new NotImplementedException();

    public abstract string BlockStatementMethodAudio(string inputString);

    public abstract string BlockStatementMethodImage(string inputString);
}
