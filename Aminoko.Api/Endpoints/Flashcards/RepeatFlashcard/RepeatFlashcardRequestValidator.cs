using FastEndpoints;
using FluentValidation;

namespace Aminoko.Api.Endpoints.Flashcards.RepeatFlashcard;

public class RepeatFlashcardRequestValidator : Validator<RepeatFlashcardRequest>
{
    public RepeatFlashcardRequestValidator()
    {
        RuleFor(x => x.FlashcardId).GreaterThan(0);
        RuleFor(x => x.RepetitionResult).Must(repResult => repResult == 1 || repResult == 3);
    }
}
