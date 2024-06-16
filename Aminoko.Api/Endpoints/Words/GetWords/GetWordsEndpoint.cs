using Aminoko.Api.Models;
using Aminoko.Api.Persistence.Repos;
using FastEndpoints;

namespace Aminoko.Api.Endpoints.Words.GetWords;

public class GetWordsEndpoint : Endpoint<GetWordsRequest, GetWordsResponse>
{
    private readonly IWordRepo _wordRepo;

    public GetWordsEndpoint(IWordRepo wordRepo)
    {
        _wordRepo = wordRepo;
    }

    public override async Task HandleAsync(GetWordsRequest r, CancellationToken ct)
    {
        var pagedWords = await _wordRepo.GetAsync(r.UserId, new PageRequest
        {
            Page = r.Page,
            PageSize = r.PageSize
        });

        await SendAsync(pagedWords.ToGetWordsResponse(), cancellation: ct);
    }
}
