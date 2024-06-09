using Aminoko.Api.Infrastructure.Exceptions;
using Aminoko.Api.Infrastructure.Mapping;
using Aminoko.Api.Persistence.Models;
using Aminoko.Api.Persistence.Repos;
using FastEndpoints;

namespace Aminoko.Api.Endpoints.Templates.CreateTemplate;

[HttpPost("/template")]
public sealed class CreateTemplateEndpoint : Endpoint<CreateTemplateRequest, CreateTemplateResponse>
{
    private readonly ITemplateRepo _templateRepo;

    public CreateTemplateEndpoint(ITemplateRepo deckRepo)
    {
        _templateRepo = deckRepo;
    }

    public override async Task HandleAsync(CreateTemplateRequest r, CancellationToken ct)
    {
        Template addedTemplate;
        try
        {
            addedTemplate = await _templateRepo.AddAsync(r.ToTemplate());
        }
        catch (BadRequestException e)
        {
            ThrowError(e.Message);
            return;
        }

        await SendCreatedAtAsync<CreateTemplateEndpoint>(
            new { templateId = addedTemplate.Id }, 
            addedTemplate.ToCreateTemplateResponse(), 
            cancellation: ct);
    }
}
