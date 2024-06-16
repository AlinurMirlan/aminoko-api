using Aminoko.Api.Persistence.Repos;
using FastEndpoints;

namespace Aminoko.Api.Endpoints.Decks.DeleteDeck;

[HttpDelete("/decks/{DeckId:int}")]
public sealed class DeleteDeckEndpoint : Endpoint<DeleteDeckRequest>
{
    private readonly IDeckRepo _deckRepo;

    public DeleteDeckEndpoint(IDeckRepo deckRepo)
    {
        _deckRepo = deckRepo ?? throw new ArgumentNullException(nameof(deckRepo));
    }

    public override async Task HandleAsync(DeleteDeckRequest r, CancellationToken ct)
    {
        await _deckRepo.DeleteAsync(r.DeckId);
        await SendNoContentAsync(cancellation: ct);
    }
}