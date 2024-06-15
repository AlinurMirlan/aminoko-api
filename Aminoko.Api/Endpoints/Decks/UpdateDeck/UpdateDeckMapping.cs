using Aminoko.Api.Persistence.Models;

namespace Aminoko.Api.Endpoints.Decks.UpdateDeck;

public static class UpdateDeckMapping
{
    public static Deck ToDeck(this UpdateDeckRequest r)
    {
        return new Deck
        {
            Id = r.DeckId,
            Name = r.Name
        };
    }
}
