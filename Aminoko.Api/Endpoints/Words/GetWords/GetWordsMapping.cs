using Aminoko.Api.Infrastructure.Mapping;
using Aminoko.Api.Models;
using Aminoko.Api.Persistence.Models;

namespace Aminoko.Api.Endpoints.Words.GetWords;

public static class GetWordsMapping
{
    public static GetWordsResponse ToGetWordsResponse(this PagedResult<Word> pagedWord)
    {
        return new GetWordsResponse
        {
            Page = pagedWord.Page,
            PageSize = pagedWord.PageSize,
            TotalPages = pagedWord.TotalPages,
            Words = pagedWord.Items.Select(w => w.ToWordDto())
        };
    }
}
