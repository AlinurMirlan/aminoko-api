using Aminoko.Api.Models;
using Aminoko.Api.Persistence.Repos;

namespace Aminoko.Api.Services;

public class FlashcardRepManager : IFlashcardRepManager
{
    private const double RetentionRate = 0.9;

    private readonly static List<double> w = [0.4, 0.6, 2.4, 5.8, 4.93, 0.94, 0.86, 0.01, 1.49, 0.14, 0.94, 2.18, 0.05, 0.34, 1.26, 0.29, 2.61];
    private readonly IFlashcardRepo _flashcardRepo;

    public FlashcardRepManager(IFlashcardRepo flashcardRepo)
    {
        _flashcardRepo = flashcardRepo ?? throw new ArgumentNullException(nameof(flashcardRepo));
    }

    public async Task UpdateFlashcardRepetitionDate(int flashcardId, RepetitionOutcome repetitionOutcome)
    {
        if (flashcardId <= 0)
        {
            throw new ArgumentException(nameof(flashcardId));
        }

        if (repetitionOutcome.Equals(null))
        {
            throw new ArgumentNullException(nameof(repetitionOutcome));
        }

        var grade = (int)repetitionOutcome;
        if (grade < 1 || grade > 4)
        {
            throw new ArgumentException("Repetition outcome must be between 1 and 4", nameof(repetitionOutcome));
        }

        double nextInterval;
        var flashcard = await _flashcardRepo.GetAsync(flashcardId);
        var retentionStats = flashcard.RetentionStats;
        if (retentionStats.Difficulty is null || retentionStats.Stability is null)
        {
            retentionStats.Difficulty = InitialDifficulty(grade);
            retentionStats.Stability = InitialStability(grade);
            retentionStats.ReviewDate = DateTime.UtcNow;

            nextInterval = NextInterval(retentionStats.Stability.Value);

            flashcard.RepetitionDate = DateTime.UtcNow.AddDays(nextInterval);
            await _flashcardRepo.UpdateAsync(flashcard.Id, flashcard);
        }

        retentionStats.Difficulty = NewDifficulty(retentionStats.Difficulty.Value, grade);
        retentionStats.ReviewDate = DateTime.UtcNow;
        var daysSinceTheLastReview = (DateTime.UtcNow - retentionStats.ReviewDate.Value).TotalDays;
        var retrievability = Retrievability(daysSinceTheLastReview, retentionStats.Difficulty.Value);
        retentionStats.Stability = NewStability(retentionStats.Difficulty.Value, retentionStats.Stability.Value, retrievability, grade);

        nextInterval = NextInterval(retentionStats.Stability.Value);

        flashcard.RepetitionDate = DateTime.UtcNow.AddDays(nextInterval);
        await _flashcardRepo.UpdateAsync(flashcard.Id, flashcard);
    }

    private static double InitialStability(int grade) => w[grade - 1];

    private static double InitialDifficulty(int grade) => w[4] - (grade - 3) * w[5];

    private static double NewDifficulty(double difficulty, int grade) => 
        w[7] * InitialDifficulty(3) + (1 - w[7]) * (difficulty - w[6] * (grade - 3));

    private static double Retrievability(double t, double stability) 
        => Math.Pow(1 + t / (9 * stability), -1);
 
    private static double NextInterval(double stability) 
        => 9 * stability * (1 / RetentionRate - 1);

    private static double NewStability(double difficulty, double stability, double retrievability, int grade)
        => stability * (Math.Exp(w[8]) * (11 - difficulty) * Math.Pow(stability, -w[9]) * (Math.Exp(w[10] 
            * (1 - retrievability)) - 1) * (grade == 2 ? w[15] : 1) * (grade == 4 ? w[16] : 1) + 1);
}
