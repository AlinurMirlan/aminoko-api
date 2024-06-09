using Aminoko.Api.Infrastructure.Mapping;
using Aminoko.Api.Persistence.Models;

namespace Aminoko.Api.Endpoints.Decks.GetDeck;

public static class GetDeckMapping
{
    public static GetDeckResponse ToGetDeckResponse(this Deck deck)
    {
        return new GetDeckResponse
        {
            Deck = deck.ToDeckDto()
        };
    }
}
