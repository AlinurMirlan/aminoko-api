using Aminoko.Api.Persistence.Models;

namespace Aminoko.Api.Endpoints.Flashcards.UpdateFlashcard;

public static class UpdateFlashcardMapping
{
    public static Flashcard ToFlashcard(this UpdateFlashcardRequest request)
    {
        return new Flashcard
        {
            Id = request.FlashcardId,
            Front = request.Front,
            Back = request.Back
        };
    }
}
