namespace Aminoko.Template;

/// <summary>
/// Template to flashcard generator.
/// </summary>
public interface IFlashcardGenerator
{
    public Flashcard GenerateFlashcard(string template);
}
