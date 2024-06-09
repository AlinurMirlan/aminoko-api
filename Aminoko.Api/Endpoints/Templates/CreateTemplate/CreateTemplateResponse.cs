using Aminoko.Api.Models;

namespace Aminoko.Api.Endpoints.Templates.CreateTemplate;

public class CreateTemplateResponse
{
    public required TemplateDto Template { get; set; }
}