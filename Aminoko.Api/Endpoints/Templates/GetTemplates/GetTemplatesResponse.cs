using Aminoko.Api.Models;

namespace Aminoko.Api.Endpoints.Templates.GetTemplates;

public class GetTemplatesResponse
{
    public int Page { get; set; }

    public int PageSize { get; set; }

    public int TotalPages { get; set; }

    public IEnumerable<TemplateDto> Templates { get; set; } = [];
}