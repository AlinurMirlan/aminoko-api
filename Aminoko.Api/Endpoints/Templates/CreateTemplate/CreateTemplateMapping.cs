using Aminoko.Api.Infrastructure.Mapping;
using Aminoko.Api.Persistence.Models;

namespace Aminoko.Api.Endpoints.Templates.CreateTemplate;

public static class CreateTemplateMapping
{
    public static CreateTemplateResponse ToCreateTemplateResponse(this Template template)
    {
        return new CreateTemplateResponse
        {
            Template = template.ToTemplateDto()
        };
    }

    public static Template ToTemplate(this CreateTemplateRequest request)
    {
        return new Template
        {
            UserId = request.UserId,
            Name = request.Name,
            Body = request.Body
        };
    }
}