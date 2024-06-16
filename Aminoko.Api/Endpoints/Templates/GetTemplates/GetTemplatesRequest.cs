using FastEndpoints;

namespace Aminoko.Api.Endpoints.Templates.GetTemplates;

public class GetTemplatesRequest
{
    [QueryParam]
    public required string UserId { get; set; }

    [QueryParam]
    public int Page { get; set; }

    [QueryParam]
    public int PageSize { get; set; }
}