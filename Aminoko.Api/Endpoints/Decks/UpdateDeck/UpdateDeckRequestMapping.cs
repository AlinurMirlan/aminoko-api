using Aminoko.Api.Infrastructure.Mapping;
using Aminoko.Api.Persistence.Models;

namespace Aminoko.Api.Endpoints.Decks.UpdateDeck;

public static class UpdateDeckRequestMapping
{
    public static Deck ToDeck(this UpdateDeckRequest request)
    {
        return request.Deck.ToDeck();
    }
}
