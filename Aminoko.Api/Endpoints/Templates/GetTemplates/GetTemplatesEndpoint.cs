using Aminoko.Api.Models;
using Aminoko.Api.Persistence.Repos;
using FastEndpoints;

namespace Aminoko.Api.Endpoints.Templates.GetTemplates;

[HttpPost("/templates")]
public class GetTemplatesEndpoint : Endpoint<GetTemplatesRequest, GetTemplatesResponse>
{
    private readonly ITemplateRepo _templateRepo;

    public GetTemplatesEndpoint(ITemplateRepo templateRepo)
    {
        _templateRepo = templateRepo;
    }

    public override async Task HandleAsync(GetTemplatesRequest r, CancellationToken ct)
    {
        var pagedTemplates = await _templateRepo.GetAsync(r.UserId, new PageRequest
        {
            Page = r.Page,
            PageSize = r.PageSize
        });

        await SendAsync(pagedTemplates.ToGetTemplatesResponse(), cancellation: ct);
    }
}