namespace Aminoko.TemplateGen.Models;

public record Flashcard(IEnumerable<Block> Front, IEnumerable<Block> Back);
