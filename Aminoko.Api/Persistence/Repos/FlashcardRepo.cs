using Aminoko.Api.Infrastructure.Exceptions;
using Aminoko.Api.Persistence.Models;
using Aminoko.Api.Services;
using Microsoft.EntityFrameworkCore;

namespace Aminoko.Api.Persistence.Repos;

public class FlashcardRepo : IFlashcardRepo
{
    private readonly ApplicationContext _context;

    public FlashcardRepo(ApplicationContext context)
    {
        _context = context;
    }

    public async Task<Flashcard> GenerateAsync(Flashcard flashcard)
    {
        if (await _context.Decks.FindAsync(flashcard.DeckId) is null)
        {
            throw new NotFoundException(nameof(Deck));
        }

        flashcard = (await _context.Flashcards.AddAsync(flashcard)).Entity;
        await _context.SaveChangesAsync();
        return flashcard;
    }

    public async Task<Flashcard> GetAsync(int flashcardId) => 
        await _context.Flashcards.FindAsync(flashcardId) ?? throw new NotFoundException(nameof(Flashcard));

    public async Task UpdateAsync(int flashcardId, Flashcard updatedFlashcard)
    {
        Flashcard? flashcard = await _context.Flashcards.FindAsync(flashcardId) 
            ?? throw new NotFoundException(nameof(Flashcard));

        flashcard.Front = updatedFlashcard.Front;
        flashcard.Back = updatedFlashcard.Back;
        flashcard.DeckId = updatedFlashcard.DeckId;

        await _context.SaveChangesAsync();
    }

    public async Task UpdateRepetitionDateAsync(int flashcardId, DateTime repetitionDate)
    {
        Flashcard? flashcard = await _context.Flashcards.FindAsync(flashcardId) 
            ?? throw new NotFoundException(nameof(Flashcard));

        flashcard.RepetitionDate = repetitionDate;

        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int flashcardId)
    {
        Flashcard? flashcard = await _context.Flashcards.FindAsync(flashcardId);
        if (flashcard is not null)
        {
            _context.Remove(flashcard);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<IEnumerable<int>> GetDueIdsAsync()
    {
        IEnumerable<int> dueIds = await _context.Flashcards
            .Where(f => f.RepetitionDate <= DateTime.Today)
            .Select(f => f.Id)
            .ToListAsync();

        return dueIds;
    }
}
