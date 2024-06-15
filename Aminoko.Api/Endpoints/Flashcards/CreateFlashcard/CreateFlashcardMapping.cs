using Aminoko.Api.Infrastructure.Mapping;
using Aminoko.Api.Persistence.Models;

namespace Aminoko.Api.Endpoints.Flashcards.CreateFlashcard;

public static class CreateFlashcardMapping
{
    public static CreateFlashcardResponse ToCreateFlashcardResponse(this Flashcard flashcard)
    {
        return new CreateFlashcardResponse
        {
            Flashcard = flashcard.ToFlashcardDto()
        };
    }
}
