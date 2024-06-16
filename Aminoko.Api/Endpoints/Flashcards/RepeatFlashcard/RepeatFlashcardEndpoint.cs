using Aminoko.Api.Models;
using Aminoko.Api.Services;
using FastEndpoints;

namespace Aminoko.Api.Endpoints.Flashcards.RepeatFlashcard;

[HttpPost("/flashcards/repeat")]
public class RepeatFlashcardEndpoint : Endpoint<RepeatFlashcardRequest>
{
    private readonly IFlashcardRepManager _flashcardRepManager;

    public RepeatFlashcardEndpoint(IFlashcardRepManager flashcardRepManager)
    {
        _flashcardRepManager = flashcardRepManager;
    }

    public override async Task HandleAsync(RepeatFlashcardRequest r, CancellationToken ct)
    {
        var repetitionOutcome = (RepetitionOutcome)r.RepetitionResult;
        await _flashcardRepManager.UpdateFlashcardRepetitionDate(r.FlashcardId, repetitionOutcome);
        await SendNoContentAsync(cancellation: ct);
    }
}
