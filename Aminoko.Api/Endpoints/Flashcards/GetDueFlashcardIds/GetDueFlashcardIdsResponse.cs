namespace Aminoko.Api.Endpoints.Flashcards.GetFlashcardIds;

public class GetDueFlashcardIdsResponse
{
    public IEnumerable<int> FlashcardIds { get; set; } = [];
}