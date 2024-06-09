using Aminoko.Api.Models;

namespace Aminoko.Api.Endpoints.Templates.GetTemplate;

public class GetTemplateResponse
{
    public required TemplateDto Template { get; set; }
}