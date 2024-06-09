using Aminoko.Api.Infrastructure.Mapping;
using Aminoko.Api.Models;
using Aminoko.Api.Persistence.Models;

namespace Aminoko.Api.Endpoints.Decks.GetDecks;

public static class GetDecksMapping
{
    public static GetDecksResponse ToGetDecksResponse(this PagedResult<Deck> pagedDecks)
    {
        return new GetDecksResponse
        {
            Page = pagedDecks.Page,
            PageSize = pagedDecks.PageSize,
            TotalPages = pagedDecks.TotalPages,
            Decks = pagedDecks.Items.Select(deck => deck.ToDeckDto())
        };
    }
}
