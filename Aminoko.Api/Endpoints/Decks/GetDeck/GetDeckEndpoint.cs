using Aminoko.Api.Persistence.Repos;
using FastEndpoints;

namespace Aminoko.Api.Endpoints.Decks.GetDeck;

[HttpGet("/decks/{DeckId:int}")]
public sealed class GetDeckEndpoint : Endpoint<GetDeckRequest, GetDeckResponse>
{
    private readonly IDeckRepo _deckRepo;

    public GetDeckEndpoint(IDeckRepo deckRepo)
    {
        _deckRepo = deckRepo ?? throw new ArgumentNullException(nameof(deckRepo));
    }

    public override async Task HandleAsync(GetDeckRequest r, CancellationToken ct)
    {
        var deck = await _deckRepo.GetAsync(r.DeckId);
        if (deck is null)
        {
            await SendNotFoundAsync(cancellation: ct);
            return;
        }

        await SendAsync(deck.ToGetDeckResponse(), cancellation: ct);
    }
}