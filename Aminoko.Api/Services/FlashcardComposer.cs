using Aminoko.Api.Endpoints.Flashcards.CreateFlashcard;
using Aminoko.Api.Persistence.Models;
using Aminoko.Api.Persistence.Repos;
using Aminoko.TemplateGen;
using Newtonsoft.Json;

namespace Aminoko.Api.Services;

public class FlashcardComposer : IFlashcardComposer
{
    private readonly FlashcardGen _flashcardGen;
    private readonly ITemplateRepo _templateRepo;
    private readonly IFlashcardRepo _flashcardRepo;

    public FlashcardComposer(FlashcardGen flashcardGen, ITemplateRepo templateRepo, IFlashcardRepo flashcardRepo)
    {
        _flashcardGen = flashcardGen;
        _templateRepo = templateRepo;
        _flashcardRepo = flashcardRepo;
    }

    public async Task<Flashcard> ComposeAsync(CreateFlashcardRequest flashcardGenRequest)
    {
        _flashcardGen.SetStatementWord(flashcardGenRequest.Word);
        _flashcardGen.SetStatementSentence(flashcardGenRequest.Sentence ?? string.Empty);
        var template = await _templateRepo.GetAsync(flashcardGenRequest.TemplateId);
        var flashcardRaw = _flashcardGen.GenerateFlashcard(template.Body);
        var flashcardFront = JsonConvert.SerializeObject(flashcardRaw.Front);
        var flashcardBack = JsonConvert.SerializeObject(flashcardRaw.Back);
        var flashcard = new Flashcard()
        {
            Word = new Word() { Name = flashcardGenRequest .Word },
            RetentionStats = new RetentionStats(),
            DeckId = flashcardGenRequest.DeckId,
            Front = flashcardFront,
            Back = flashcardBack
        };

        await _flashcardRepo.AddAsync(flashcard);
        return flashcard;
    }
}
