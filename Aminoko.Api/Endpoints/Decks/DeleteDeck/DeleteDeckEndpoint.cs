using Aminoko.Api.Persistence.Repos;
using FastEndpoints;

namespace Aminoko.Api.Endpoints.Decks.DeleteDeck;

[HttpDelete("/deck")]
public sealed class DeleteDeckEndpoint : Endpoint<DeleteDeckRequest>
{
    private readonly IDeckRepo _deckRepo;

    public DeleteDeckEndpoint(IDeckRepo deckRepo)
    {
        _deckRepo = deckRepo;
    }

    public override async Task HandleAsync(DeleteDeckRequest r, CancellationToken ct)
    {
        await _deckRepo.DeleteAsync(r.DeckId);
        await SendNoContentAsync(cancellation: ct);
    }
}