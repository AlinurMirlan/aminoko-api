namespace Aminoko.Api.Endpoints.Words.GetWords;

public class GetWordsRequest
{
    public required string UserId { get; set; }

    public int Page { get; set; }

    public int PageSize { get; set; }
}