using Aminoko.Api.Models;
using Aminoko.Api.Persistence.Models;

namespace Aminoko.Api.Services;

public interface IIntervalCalculator
{
    public Task<double> CalculateIntervalAsync(RetentionStats retentionStats, RepetitionOutcome repetitionOutcome);
}
