using Aminoko.Api.Persistence.Repos;
using FastEndpoints;

namespace Aminoko.Api.Endpoints.Flashcards.GetFlashcard;

[HttpGet("/flashcards/{FlashcardId:int}")]
public class GetFlashcardEndoint : Endpoint<GetFlashcardRequest, GetFlashcardResponse>
{
    private readonly IFlashcardRepo _flashcardRepository;

    public GetFlashcardEndoint(IFlashcardRepo flashcardRepository)
    {
        _flashcardRepository = flashcardRepository ?? throw new ArgumentNullException(nameof(flashcardRepository));
    }

    public override async Task HandleAsync(GetFlashcardRequest r, CancellationToken ct)
    {
        var flashcard = await _flashcardRepository.GetAsync(r.FlashcardId);
        if (flashcard is null)
        {
            await SendNotFoundAsync(cancellation: ct);
            return;
        }

        await SendAsync(flashcard.ToFlashcardResponse(), cancellation: ct);
    }
}
