using Aminoko.Api.Persistence.Repos;
using FastEndpoints;

namespace Aminoko.Api.Endpoints.Flashcards.GetFlashcardIds;

public class GetDueFlashcardIdsEndpoint : EndpointWithoutRequest<GetDueFlashcardIdsResponse>
{
    private readonly IFlashcardRepo _flashcardRepo;

    public GetDueFlashcardIdsEndpoint(IFlashcardRepo flashcardRepo)
    {
        _flashcardRepo = flashcardRepo;
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        IEnumerable<int> flashcardIds = await _flashcardRepo.GetDueIdsAsync();
        await SendOkAsync(new GetDueFlashcardIdsResponse { FlashcardIds = flashcardIds }, cancellation: ct);
    }
}
