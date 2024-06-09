using Aminoko.Api.Models;
using Aminoko.Api.Persistence.Repos;
using FastEndpoints;

namespace Aminoko.Api.Endpoints.Decks.GetDecks;

[HttpPost("/decks")]
public class GetDecksEndpoint : Endpoint<GetDecksRequest, GetDecksResponse>
{
    private readonly IDeckRepo _deckRepo;

    public GetDecksEndpoint(IDeckRepo deckRepo)
    {
        _deckRepo = deckRepo;
    }

    public override async Task HandleAsync(GetDecksRequest r, CancellationToken ct)
    {
        var pagedDecks = await _deckRepo.GetAsync(r.UserId, new PageRequest
        {
            Page = r.Page,
            PageSize = r.PageSize
        });

        await SendAsync(pagedDecks.ToGetDecksResponse(), cancellation: ct);
    }
}
