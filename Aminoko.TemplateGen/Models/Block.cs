namespace Aminoko.TemplateGen.Models;

public class Block
{
    public BlockType BlockType { get; set; }

    public string Value { get; set; }

    public Block(BlockType blockType, string value)
    {
        BlockType = blockType;
        Value = value;
    }
}