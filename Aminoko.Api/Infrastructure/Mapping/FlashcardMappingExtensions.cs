using Aminoko.Api.Models;
using Aminoko.Api.Persistence.Models;

namespace Aminoko.Api.Infrastructure.Mapping;

public static class FlashcardMappingExtensions
{
    public static FlashcardDto ToFlashcardDto(this Flashcard flashcard)
    {
        return new FlashcardDto
        {
            Id = flashcard.Id,
            Front = flashcard.Front,
            Back = flashcard.Back,
            CreationDate = flashcard.CreationDate,
        };
    }
}
