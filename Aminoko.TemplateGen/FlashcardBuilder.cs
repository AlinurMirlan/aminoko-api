using Aminoko.TemplateGen.Models;

namespace Aminoko.TemplateGen;

public class FlashcardBuilder : IFlashcardBuilder
{
    private readonly IList<Block> blocksFront = [];
    private readonly IList<Block> blocksBack = [];
    private IList<Block> blocks;

    public FlashcardBuilder()
    {
        blocks = blocksFront;
    }

    public Flashcard Flashcard => new(blocksFront, blocksBack);

    public void AddBlock(BlockType blockType, string inputString)
    {
        if (string.IsNullOrEmpty(inputString))
        {
            return;
        }

        blocks.Add(new Block(blockType, inputString));
    }

    public void SwitchSide()
    {
        blocks = blocks == blocksFront ? blocksBack : blocksFront;
    }
}
