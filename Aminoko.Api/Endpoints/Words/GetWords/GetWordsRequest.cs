using FastEndpoints;

namespace Aminoko.Api.Endpoints.Words.GetWords;

public class GetWordsRequest
{
    [QueryParam]
    public required string UserId { get; set; }

    [QueryParam]
    public int Page { get; set; }

    [QueryParam]
    public int PageSize { get; set; }
}