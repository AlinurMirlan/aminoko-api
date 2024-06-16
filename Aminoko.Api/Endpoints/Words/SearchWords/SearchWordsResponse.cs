using Aminoko.Api.Models;

namespace Aminoko.Api.Endpoints.Words.SearchWords;

public class SearchWordsResponse
{
    public int Page { get; set; }

    public int PageSize { get; set; }

    public int TotalPages { get; set; }

    public List<WordDto> Words { get; set; } = [];
}