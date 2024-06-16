using Aminoko.Api.Infrastructure.Exceptions;
using Aminoko.Api.Persistence.Models;
using Microsoft.EntityFrameworkCore;

namespace Aminoko.Api.Persistence.Repos;

public class FlashcardRepo : IFlashcardRepo
{
    private readonly ApplicationContext _context;

    public FlashcardRepo(ApplicationContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<Flashcard> AddAsync(Flashcard flashcard)
    {
        await _context.Flashcards.AddAsync(flashcard);
        await _context.SaveChangesAsync();

        return flashcard;
    }

    public async Task<Flashcard> GetAsync(int flashcardId) => 
        await _context.Flashcards.FindAsync(flashcardId) ?? throw new NotFoundException(nameof(Flashcard));

    public async Task UpdateAsync(int flashcardId, Flashcard updatedFlashcard)
    {
        Flashcard? flashcard = await _context.Flashcards.FindAsync(flashcardId) 
            ?? throw new NotFoundException(nameof(Flashcard));

        if (!string.IsNullOrEmpty(updatedFlashcard.Front))
        {
            flashcard.Front = updatedFlashcard.Front;
        }

        if (!string.IsNullOrEmpty(updatedFlashcard.Back))
        {
            flashcard.Back = updatedFlashcard.Back;
        }

        if (updatedFlashcard.RepetitionDate != default)
        {
            flashcard.RepetitionDate = updatedFlashcard.RepetitionDate;
        }

        if (updatedFlashcard.RetentionStats is not null)
        {
            if (flashcard.RetentionStats.ReviewDate != default)
            {
                flashcard.RetentionStats.ReviewDate = updatedFlashcard.RetentionStats.ReviewDate;
            }

            if (updatedFlashcard.RetentionStats.Difficulty is not null)
            {
                flashcard.RetentionStats.Difficulty = updatedFlashcard.RetentionStats.Difficulty;
            }

            if (updatedFlashcard.RetentionStats.Stability is not null)
            {
                flashcard.RetentionStats.Stability = updatedFlashcard.RetentionStats.Stability;
            }
        }


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

    public async Task<IEnumerable<int>> GetDueIdsAsync(string userId)
    {
        var dueIds = await _context.Flashcards
            .Where(f => f.Deck.UserId == userId && f.RepetitionDate <= DateTime.UtcNow)
            .Select(f => f.Id)
            .ToListAsync();

        return dueIds;
    }
}
