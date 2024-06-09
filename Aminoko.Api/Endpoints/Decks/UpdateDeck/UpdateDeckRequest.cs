using Aminoko.Api.Models;

namespace Aminoko.Api.Endpoints.Decks.UpdateDeck;

public class UpdateDeckRequest
{
    public int DeckId { get; set; }

    public required DeckDto Deck { get; set; }
}
