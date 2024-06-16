using Aminoko.Api.Persistence.Repos;
using FastEndpoints;

namespace Aminoko.Api.Endpoints.Flashcards.GetFlashcardIds;

[HttpGet("/flashcards/due/user/{UserId}")]
public class GetDueFlashcardIdsEndpoint : Endpoint<GetDueFlashcardIdsRequest, GetDueFlashcardIdsResponse>
{
    private readonly IFlashcardRepo _flashcardRepo;

    public GetDueFlashcardIdsEndpoint(IFlashcardRepo flashcardRepo)
    {
        _flashcardRepo = flashcardRepo ?? throw new ArgumentNullException(nameof(flashcardRepo));
    }

    public override async Task HandleAsync(GetDueFlashcardIdsRequest r, CancellationToken ct)
    {
        IEnumerable<int> flashcardIds = await _flashcardRepo.GetDueIdsAsync(r.UserId);
        await SendOkAsync(new GetDueFlashcardIdsResponse { FlashcardIds = flashcardIds }, cancellation: ct);
    }
}
