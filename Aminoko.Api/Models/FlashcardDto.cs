namespace Aminoko.Api.Models;

public class FlashcardDto
{
    public int Id { get; set; }

    public required string Front { get; set; }

    public required string Back { get; set; }

    public DateTime CreationDate { get; set; }
}
