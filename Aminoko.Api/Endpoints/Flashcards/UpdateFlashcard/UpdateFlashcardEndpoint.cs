using Aminoko.Api.Infrastructure.Exceptions;
using Aminoko.Api.Persistence.Repos;
using FastEndpoints;

namespace Aminoko.Api.Endpoints.Flashcards.UpdateFlashcard;

[HttpPut("/flashcards/{FlashcardId:int}")]
public class UpdateFlashcardEndpoint : Endpoint<UpdateFlashcardRequest>
{
    private readonly IFlashcardRepo _flashcardRepo;

    public UpdateFlashcardEndpoint(IFlashcardRepo flashcardRepo)
    {
        _flashcardRepo = flashcardRepo ?? throw new ArgumentNullException(nameof(flashcardRepo));
    }

    public override async Task HandleAsync(UpdateFlashcardRequest r, CancellationToken ct)
    {
        try
        {
            await _flashcardRepo.UpdateAsync(r.FlashcardId, r.ToFlashcard());
        }
        catch (BadRequestException e)
        {
            ThrowError(e.Message);
        }

        await SendNoContentAsync(cancellation: ct);
    }
}