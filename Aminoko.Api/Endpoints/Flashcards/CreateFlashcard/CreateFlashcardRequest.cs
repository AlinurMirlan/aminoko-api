namespace Aminoko.Api.Endpoints.Flashcards.CreateFlashcard;

public class CreateFlashcardRequest
{
    public required string Word { get; set; }

    public string? Sentence { get; set; }

    public int DeckId { get; set; }

    public int TemplateId { get; set; }
}