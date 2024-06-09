namespace Aminoko.Api.Endpoints.Decks.GetDecks;

public class GetDecksRequest
{
    public required string UserId { get; set; }

    public int Page { get; set; }

    public int PageSize { get; set; }
}