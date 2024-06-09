using Aminoko.Api.Infrastructure.Mapping;
using Aminoko.Api.Persistence.Models;

namespace Aminoko.Api.Endpoints.Templates.GetTemplate;

public static class GetTemplateMapping
{
    public static GetTemplateResponse ToGetTemplateResponse(this Template template)
    {
        return new GetTemplateResponse
        {
            Template = template.ToTemplateDto()
        };
    }
}