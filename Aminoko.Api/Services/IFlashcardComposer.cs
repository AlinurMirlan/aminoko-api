using Aminoko.Api.Endpoints.Flashcards.CreateFlashcard;
using Aminoko.Api.Persistence.Models;

namespace Aminoko.Api.Services;

public interface IFlashcardComposer
{
    Task<Flashcard> ComposeAsync(CreateFlashcardRequest flashcardGenRequest);
}
