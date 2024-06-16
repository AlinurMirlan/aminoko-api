using FastEndpoints;

namespace Aminoko.Api.Endpoints.Decks.GetDecks;

public class GetDecksRequest
{
    [QueryParam]
    public required string UserId { get; set; }

    [QueryParam]
    public int Page { get; set; }

    [QueryParam]
    public int PageSize { get; set; }
}