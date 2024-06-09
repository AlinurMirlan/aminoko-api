namespace Aminoko.Api.Models;

public class DeckDto
{
    public int Id { get; set; }

    public required string UserId { get; set; }

    public required string Name { get; set; }

    public DateTime CreationDate { get; set; }
}
