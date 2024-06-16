using Aminoko.Api.Infrastructure.Mapping;
using Aminoko.Api.Models;
using Aminoko.Api.Persistence.Models;

namespace Aminoko.Api.Endpoints.Templates.SearchTemplates;

public static class SearchTemplatesMapping
{
    public static SearchTemplatesResponse ToSearchTemplatesResponse(this PagedResult<Template> pagedTemplate)
    {
        return new SearchTemplatesResponse
        {
            Page = pagedTemplate.Page,
            PageSize = pagedTemplate.PageSize,
            TotalPages = pagedTemplate.TotalPages,
            Templates = pagedTemplate.Items.Select(t => t.ToTemplateDto()).ToList()
        };
}   }
