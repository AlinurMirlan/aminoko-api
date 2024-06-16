using Aminoko.Api.Models;
using Aminoko.Api.Persistence.Repos;
using FastEndpoints;

namespace Aminoko.Api.Endpoints.Decks.SearchDecks;

[HttpPost("/decks/search")]
public class SearchDecksEndpoint : Endpoint<SearchDecksRequest, SearchDecksResponse>
{
    private readonly IDeckRepo _deckRepo;

    public SearchDecksEndpoint(IDeckRepo deckRepo)
    {
        _deckRepo = deckRepo ?? throw new ArgumentNullException(nameof(deckRepo));
    }

    public override async Task HandleAsync(SearchDecksRequest r, CancellationToken ct)
    {
        var pagedDecks = await _deckRepo.SearchAsync(
            pageRequest: new PageRequest { Page = r.Page, PageSize = r.PageSize },
            userId: r.UserId,
            searchTerm: r.SearchTerm);

        await SendAsync(pagedDecks.ToSearchDecksResponse(), cancellation: ct);
    }
}
