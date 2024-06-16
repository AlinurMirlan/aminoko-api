using Aminoko.Api.Models;
using Aminoko.Api.Persistence.Repos;
using FastEndpoints;

namespace Aminoko.Api.Endpoints.Templates.SearchTemplates;

[HttpPost("/templates/search")]
public class SearchTemplatesEndpoint : Endpoint<SearchTemplatesRequest, SearchTemplatesResponse>
{
    private readonly ITemplateRepo _templateRepo;

    public SearchTemplatesEndpoint(ITemplateRepo templateRepo)
    {
        _templateRepo = templateRepo;
    }

    public override async Task HandleAsync(SearchTemplatesRequest r, CancellationToken ct)
    {
        var pagedTemplates = await _templateRepo.SearchAsync(
            pageRequest: new PageRequest { Page = r.Page, PageSize = r.PageSize },
            userId: r.UserId,
            searchTerm: r.SearchTerm);

        await SendAsync(pagedTemplates.ToSearchTemplatesResponse(), cancellation: ct);
    }
}
