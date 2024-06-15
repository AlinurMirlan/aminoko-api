using Aminoko.TemplateGen.Models;

namespace Aminoko.TemplateGen;

/// <summary>
/// Template to flashcard generator.
/// </summary>
public interface IFlashcardGen
{
    public Flashcard GenerateFlashcard(string template);
}
