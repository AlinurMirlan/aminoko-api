using Aminoko.Api.Persistence.Repos;
using FastEndpoints;

namespace Aminoko.Api.Endpoints.Flashcards.DeleteFlashcard;

[HttpDelete("/flashcard/{FlashcardId:int}")]
public class DeleteFlashcardEndpoint : Endpoint<DeleteFlashcardRequest>
{
    private readonly IFlashcardRepo _flashcardRepo;

    public DeleteFlashcardEndpoint(IFlashcardRepo flashcardRepo)
    {
        _flashcardRepo = flashcardRepo;
    }

    public override async Task HandleAsync(DeleteFlashcardRequest r, CancellationToken ct)
    {
        await _flashcardRepo.DeleteAsync(r.FlashcardId);
        await SendNoContentAsync(cancellation: ct);
    }
}
