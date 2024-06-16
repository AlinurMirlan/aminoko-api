using Aminoko.Api.Models;

namespace Aminoko.Api.Endpoints.Words.GetWords;

public class GetWordsResponse
{
    public int Page { get; set; }

    public int PageSize { get; set; }

    public int TotalPages { get; set; }

    public IEnumerable<WordDto> Words { get; set; } = [];
}