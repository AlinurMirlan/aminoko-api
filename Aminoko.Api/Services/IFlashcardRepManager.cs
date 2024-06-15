using Aminoko.Api.Models;

namespace Aminoko.Api.Services;

public interface IFlashcardRepManager
{
    public Task UpdateFlashcardRepetitionDate(int flashcardId, RepetitionOutcome repetitionOutcome);
}
