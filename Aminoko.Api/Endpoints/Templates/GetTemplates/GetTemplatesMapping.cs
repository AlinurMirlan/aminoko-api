using Aminoko.Api.Infrastructure.Mapping;
using Aminoko.Api.Models;
using Aminoko.Api.Persistence.Models;

namespace Aminoko.Api.Endpoints.Templates.GetTemplates;

public static class GetTemplatesMapping
{
    public static GetTemplatesResponse ToGetTemplatesResponse(this PagedResult<Template> pagedTemplate)
    {
        return new GetTemplatesResponse
        {
            Page = pagedTemplate.Page,
            PageSize = pagedTemplate.PageSize,
            TotalPages = pagedTemplate.TotalPages,
            Templates = pagedTemplate.Items.Select(x => x.ToTemplateDto())
        };
    }
}
