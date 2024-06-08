using Aminoko.Template.Models;

namespace Aminoko.Template;

public interface IFlashcardBuilder
{
    public Flashcard Flashcard { get; }

    public void SwitchSide();

    public void AddBlock(BlockType blockType, string inputString);
}
