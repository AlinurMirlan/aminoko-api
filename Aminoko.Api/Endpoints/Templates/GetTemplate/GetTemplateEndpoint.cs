using Aminoko.Api.Persistence.Repos;
using FastEndpoints;

namespace Aminoko.Api.Endpoints.Templates.GetTemplate;

[HttpGet("/template/{TemplateId:int}")]
public sealed class GetTemplateEndpoint : Endpoint<GetTemplateRequest, GetTemplateResponse>
{
    private readonly ITemplateRepo _templateRepo;

    public GetTemplateEndpoint(ITemplateRepo templateRepo)
    {
        _templateRepo = templateRepo;
    }

    public override async Task HandleAsync(GetTemplateRequest r, CancellationToken ct)
    {
        var template = await _templateRepo.GetAsync(r.TemplateId);
        if (template is null)
        {
            await SendNotFoundAsync(cancellation: ct);
            return;
        }

        await SendAsync(template.ToGetTemplateResponse(), cancellation: ct);
    }
}