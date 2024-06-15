namespace Aminoko.Api.Endpoints.Decks.UpdateDeck;

public class UpdateDeckRequest
{
    public int DeckId { get; set; }

    public required string Name { get; set; }
}
