using Aminoko.Api.Infrastructure.Mapping;
using Aminoko.Api.Models;
using Aminoko.Api.Persistence.Models;

namespace Aminoko.Api.Endpoints.Words.SearchWords;

public static class SearchWordsMapping
{
    public static SearchWordsResponse ToSearchWordsResponse(this PagedResult<Word> pagedWord)
    {
        return new SearchWordsResponse
        {
            Page = pagedWord.Page,
            PageSize = pagedWord.PageSize,
            TotalPages = pagedWord.TotalPages,
            Words = pagedWord.Items.Select(w => w.ToWordDto()).ToList()
        };
    }
}
