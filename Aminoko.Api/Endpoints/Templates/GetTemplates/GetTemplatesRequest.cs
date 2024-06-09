namespace Aminoko.Api.Endpoints.Templates.GetTemplates;

public class GetTemplatesRequest
{
    public required string UserId { get; set; }

    public int Page { get; set; }

    public int PageSize { get; set; }
}