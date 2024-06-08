using Aminoko.Api.Models;
using Aminoko.Api.Persistence.Models;
using Aminoko.Api.Persistence.Repos;

namespace Aminoko.Api.Services;

public class IntervalCalculator : IIntervalCalculator
{
    private const double RetentionRate = 0.9;

    private readonly static List<double> w = [0.4, 0.6, 2.4, 5.8, 4.93, 0.94, 0.86, 0.01, 1.49, 0.14, 0.94, 2.18, 0.05, 0.34, 1.26, 0.29, 2.61];
    private readonly IRetentionStatsRepo _retentionStatsRepo;

    public IntervalCalculator(IRetentionStatsRepo retentionStatsRepo)
    {
        _retentionStatsRepo = retentionStatsRepo ?? throw new ArgumentNullException(nameof(retentionStatsRepo));
    }

    public async Task<double> CalculateIntervalAsync(RetentionStats retentionStats, RepetitionOutcome repetitionOutcome)
    {
        if (retentionStats.Equals(null))
        {
            throw new ArgumentNullException(nameof(retentionStats));
        }

        if (repetitionOutcome.Equals(null))
        {
            throw new ArgumentNullException(nameof(repetitionOutcome));
        }

        if (retentionStats.Difficulty is null || retentionStats.Stability is null)
        {
            retentionStats.Difficulty = InitialDifficulty((int)repetitionOutcome);
            retentionStats.Stability = InitialStability((int)repetitionOutcome);
            retentionStats.ReviewDate = DateTime.UtcNow;

            await _retentionStatsRepo.UpdateStatsAsync(retentionStats);

            return NextInterval(RetentionRate, retentionStats.Stability.Value);
        }

        retentionStats.Difficulty = NewDifficulty(retentionStats.Difficulty.Value, (int)repetitionOutcome);
        retentionStats.ReviewDate = DateTime.UtcNow;
        var daysSinceTheLastReview = (DateTime.UtcNow - retentionStats.ReviewDate).TotalDays;
        var retrievability = Retrievability(daysSinceTheLastReview, retentionStats.Difficulty.Value);
        retentionStats.Stability = NewStability(retentionStats.Difficulty.Value, retentionStats.Stability.Value, retrievability, (int)repetitionOutcome);

        await _retentionStatsRepo.UpdateStatsAsync(retentionStats);

        return NextInterval(RetentionRate, retentionStats.Stability.Value);
    }

    private static double InitialStability(int grade)
    {
        GradeCheck(grade);

        return w[grade - 1];
    }

    private static double InitialDifficulty(int grade)
    {
        GradeCheck(grade);

        return w[4] - (grade - 3) * w[5];
    }

    private static double NewDifficulty(double difficulty, int grade)
    {
        GradeCheck(grade);

        return w[7] * InitialDifficulty(3) + (1 - w[7]) * (difficulty - w[6] * (grade - 3));
    }

    private static double Retrievability(double t, double stability)
    {
        return Math.Pow(1 + t / (9 * stability), -1);
    }

    private static double NextInterval(double retrievability, double stability)
    {
        return 9 * stability * (1 / retrievability - 1);
    }

    private static double NewStability(double difficulty, double stability, double retrievability, int grade)
    {
        GradeCheck(grade);

        return stability * (Math.Exp(w[8]) * (11 - difficulty) * Math.Pow(stability, -w[9]) * (Math.Exp(w[10] * (1 - retrievability)) - 1) * w[15] * (grade == 2 ? w[16] : 1) + 1);
    }

    private static void GradeCheck(int grade)
    {
        if (grade < 1 || grade > 4)
        {
            throw new ArgumentException("Grade must be between 1 and 4", nameof(grade));
        }
    }
}
