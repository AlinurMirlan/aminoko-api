using Aminoko.TemplateGen.Models;

namespace Aminoko.TemplateGen;

public interface IFlashcardBuilder
{
    public Flashcard Flashcard { get; }

    public void SwitchSide();

    public void AddBlock(BlockType blockType, string inputString);
}
