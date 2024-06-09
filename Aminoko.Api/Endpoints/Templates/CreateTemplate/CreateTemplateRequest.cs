using Aminoko.Api.Models;

namespace Aminoko.Api.Endpoints.Templates.CreateTemplate;

public class CreateTemplateRequest
{
    public required string UserId { get; set; }

    public required TemplateDto Template { get; set; }
}