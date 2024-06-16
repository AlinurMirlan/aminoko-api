using Aminoko.Api.Infrastructure.Mapping;
using Aminoko.Api.Models;
using Aminoko.Api.Persistence.Models;

namespace Aminoko.Api.Endpoints.Decks.SearchDecks;

public static class SearchDecksMapping
{
    public static SearchDecksResponse ToSearchDecksResponse(this PagedResult<Deck> pagedDecks)
    {
        return new SearchDecksResponse
        {
            Page = pagedDecks.Page,
            PageSize = pagedDecks.PageSize,
            TotalPages = pagedDecks.TotalPages,
            Decks = pagedDecks.Items.Select(d => d.ToDeckDto()).ToList()
        };
    }
}
