namespace Aminoko.Api.Endpoints.Decks.SearchDecks;

public class SearchDecksRequest
{
    public required string UserId { get; set; } 

    public int Page { get; set; }

    public int PageSize { get; set; }

    public required string SearchTerm { get; set; }
}