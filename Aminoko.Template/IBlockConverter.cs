namespace Aminoko.Template;

public interface IBlockConverter
{
    public string BlockStatementImage();

    public string BlockStatementDefinition();

    public string BlockStatementMethodAudio(string inputString);

    public string BlockStatementMethodImage(string inputString);

    public string BlockText(string text);
}
