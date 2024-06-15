using Aminoko.Api.Models;

namespace Aminoko.Api.Endpoints.Flashcards.GetFlashcard;

public class GetFlashcardResponse
{
    public required FlashcardDto Flashcard { get; set; }
}