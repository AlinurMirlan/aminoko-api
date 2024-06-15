namespace Aminoko.Api.Endpoints.Flashcards.UpdateFlashcard;

public class UpdateFlashcardRequest
{
    public int FlashcardId { get; set; }

    public required string Front { get; set; }

    public required string Back { get; set; }
}