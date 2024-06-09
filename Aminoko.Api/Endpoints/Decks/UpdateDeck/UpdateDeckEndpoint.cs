using Aminoko.Api.Infrastructure.Exceptions;
using Aminoko.Api.Persistence.Repos;
using FastEndpoints;

namespace Aminoko.Api.Endpoints.Decks.UpdateDeck;

[HttpPut("/deck/{DeckId:int}")]
public sealed class UpdateDeckEndpoint : Endpoint<UpdateDeckRequest>
{
    private readonly IDeckRepo _deckRepo;

    public UpdateDeckEndpoint(IDeckRepo deckRepo)
    {
        _deckRepo = deckRepo;
    }

    public override async Task HandleAsync(UpdateDeckRequest r, CancellationToken ct)
    {
        try
        {
            await _deckRepo.UpdateAsync(r.DeckId, r.ToDeck());
        }
        catch (BadRequestException e)
        {
            ThrowError(e.Message);
        }

        await SendNoContentAsync(cancellation: ct);
    }
}