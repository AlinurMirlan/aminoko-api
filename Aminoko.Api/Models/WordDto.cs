namespace Aminoko.Api.Models;

public class WordDto
{
    public int Id { get; set; }

    public required string Name { get; set; }

    public DateTime CreationDate { get; set; }
}
