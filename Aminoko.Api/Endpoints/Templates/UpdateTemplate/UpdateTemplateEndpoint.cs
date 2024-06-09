using Aminoko.Api.Infrastructure.Exceptions;
using Aminoko.Api.Persistence.Repos;
using FastEndpoints;

namespace Aminoko.Api.Endpoints.Templates.UpdateTemplate;

[HttpPut("/template/{TemplateId:int}")]
public sealed class UpdateTemplateEndpoint : Endpoint<UpdateTemplateRequest>
{
    private readonly ITemplateRepo _templateRepo;

    public UpdateTemplateEndpoint(ITemplateRepo templateRepo)
    {
        _templateRepo = templateRepo;
    }

    public override async Task HandleAsync(UpdateTemplateRequest r, CancellationToken ct)
    {
        try
        {
            await _templateRepo.UpdateAsync(r.TemplateId, r.ToTemplate());
        }
        catch (BadRequestException e)
        {
            ThrowError(e.Message);
        }

        await SendNoContentAsync(cancellation: ct);
    }
}