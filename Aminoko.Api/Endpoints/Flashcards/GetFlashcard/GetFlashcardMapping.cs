using Aminoko.Api.Infrastructure.Mapping;
using Aminoko.Api.Persistence.Models;

namespace Aminoko.Api.Endpoints.Flashcards.GetFlashcard;

public static class GetFlashcardMapping
{
    public static GetFlashcardResponse ToFlashcardResponse(this Flashcard flashcard)
    {
        return new GetFlashcardResponse
        {
            Flashcard = flashcard.ToFlashcardDto()
        };
    }
}
