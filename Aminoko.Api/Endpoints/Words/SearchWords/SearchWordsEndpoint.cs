using Aminoko.Api.Models;
using Aminoko.Api.Persistence.Repos;
using FastEndpoints;

namespace Aminoko.Api.Endpoints.Words.SearchWords;

[HttpGet("/words/search")]
public class SearchWordsEndpoint : Endpoint<SearchWordsRequest, SearchWordsResponse>
{
    private readonly IWordRepo _wordRepo;

    public SearchWordsEndpoint(IWordRepo wordRepo)
    {
        _wordRepo = wordRepo ?? throw new ArgumentNullException(nameof(wordRepo));
    }

    public override async Task HandleAsync(SearchWordsRequest r, CancellationToken ct)
    {
        var pagedWords = await _wordRepo.SearchAsync(
            userId: r.UserId,
            pageRequest: new PageRequest { Page = r.Page, PageSize = r.PageSize },
            searchTerm: r.SearchTerm);

        await SendAsync(pagedWords.ToSearchWordsResponse(), cancellation: ct);
    }
}
