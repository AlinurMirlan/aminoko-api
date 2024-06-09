namespace Aminoko.Api.Endpoints.Decks.CreateDeck;

public class CreateDeckRequest
{
    public required string UserId { get; set; }

    public required string Name { get; set; }
}
