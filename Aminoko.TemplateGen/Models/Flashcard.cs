namespace Aminoko.TemplateGen.Models;

public class Flashcard
{
    public IEnumerable<Block> Front { get; set; }

    public IEnumerable<Block> Back { get; set; }

    public Flashcard(IEnumerable<Block> front, IEnumerable<Block> back)
    {
        Front = front;
        Back = back;
    }
}
