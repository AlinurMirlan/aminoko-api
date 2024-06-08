namespace Aminoko.Template.Models;

public record Flashcard(IEnumerable<Block> Front, IEnumerable<Block> Back);
