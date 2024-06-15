using Aminoko.Api.Persistence.Repos;
using FastEndpoints;

namespace Aminoko.Api.Endpoints.Templates.DeleteTemplate;

[HttpDelete("/template/{TemplateId:int}")]
public sealed class DeleteTemplateEndpoint : Endpoint<DeleteTemplateRequest>
{
    private readonly ITemplateRepo _templateRepo;

    public DeleteTemplateEndpoint(ITemplateRepo templateRepo)
    {
        _templateRepo = templateRepo;
    }

    public override async Task HandleAsync(DeleteTemplateRequest r, CancellationToken ct)
    {
        await _templateRepo.DeleteAsync(r.TemplateId);
        await SendNoContentAsync(cancellation: ct);
    }
}