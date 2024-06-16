namespace Aminoko.Api.Endpoints.Templates.SearchTemplates;

public class SearchTemplatesRequest
{
    public required string UserId { get; set; }

    public int Page { get; set; }

    public int PageSize { get; set; }

    public required string SearchTerm { get; set; }
}