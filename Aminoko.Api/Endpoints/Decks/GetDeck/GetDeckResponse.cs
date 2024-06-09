using Aminoko.Api.Models;

namespace Aminoko.Api.Endpoints.Decks.GetDeck;

public class GetDeckResponse
{
    public required DeckDto Deck { get; set; }
}
