namespace Aminoko.Api.Endpoints.Words.SearchWords;

public class SearchWordsRequest
{
    public required string UserId { get; set; }

    public int Page { get; set; }

    public int PageSize { get; set; }

    public required string SearchTerm { get; set; }
}