using Aminoko.Api.Models;

namespace Aminoko.Api.Endpoints.Flashcards.CreateFlashcard;

public class CreateFlashcardResponse
{
    public required FlashcardDto Flashcard { get; set; }
}