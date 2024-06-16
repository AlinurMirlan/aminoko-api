using FastEndpoints;

namespace Aminoko.Api.Endpoints.Words.SearchWords;

public class SearchWordsRequest
{
    [QueryParam]
    public required string UserId { get; set; }

    [QueryParam]
    public int Page { get; set; }

    [QueryParam]
    public int PageSize { get; set; }

    [QueryParam]
    public required string SearchTerm { get; set; }
}