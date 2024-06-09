using Aminoko.TemplateGen.Models;

namespace Aminoko.TemplateGen;

/// <summary>
/// Template to flashcard generator.
/// </summary>
public interface IFlashcardGenerator
{
    public Flashcard GenerateFlashcard(string template);
}
