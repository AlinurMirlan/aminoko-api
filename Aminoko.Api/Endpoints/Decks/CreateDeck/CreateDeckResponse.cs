using Aminoko.Api.Models;

namespace Aminoko.Api.Endpoints.Decks.CreateDeck;

public class CreateDeckResponse
{
    public required DeckDto Deck { get; set; }
}
