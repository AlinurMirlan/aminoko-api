namespace Aminoko.Api.Endpoints.Templates.UpdateTemplate;

public class UpdateTemplateRequest
{
    public int TemplateId { get; set; }

    public required string Name { get; set; }

    public required string Body { get; set; }
}