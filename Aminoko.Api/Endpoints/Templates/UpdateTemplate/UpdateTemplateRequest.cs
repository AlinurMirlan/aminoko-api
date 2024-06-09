using Aminoko.Api.Models;

namespace Aminoko.Api.Endpoints.Templates.UpdateTemplate;

public class UpdateTemplateRequest
{
    public int TemplateId { get; set; }

    public required TemplateDto Template { get; set; }
}