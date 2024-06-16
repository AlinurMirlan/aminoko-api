using Aminoko.Api.Models;

namespace Aminoko.Api.Endpoints.Templates.SearchTemplates;

public class SearchTemplatesResponse
{
    public int Page { get; set; }

    public int PageSize { get; set; }

    public int TotalPages { get; set; }

    public List<TemplateDto> Templates { get; set; } = [];
}