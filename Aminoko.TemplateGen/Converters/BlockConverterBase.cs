namespace Aminoko.TemplateGen.Converters;

public abstract class BlockConverterBase : IBlockConverter
{
    public string? StatementWord { get; private set; }

    public string? StatementImage { get; private set; }

    public void SetStatementWord(string statementSentence)
    {
        StatementWord = statementSentence;
    }

    public void SetStatementImage(string statementImage)
    {
        StatementImage = statementImage;
    }

    public virtual string BlockText(string text) => text;

    public abstract string BlockStatementDefinition();

    public abstract string BlockStatementImage();

    public abstract string BlockStatementMethodAudio(string inputString);

    public abstract string BlockStatementMethodImage(string inputString);

}
