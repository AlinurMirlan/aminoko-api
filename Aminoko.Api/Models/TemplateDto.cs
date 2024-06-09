namespace Aminoko.Api.Models;

public class TemplateDto
{
    public int Id { get; set; }

    public required string UserId { get; set; }

    public required string Name { get; set; }

    public required string Body { get; set; }

    public DateTime CreationDate { get; set; }
}
