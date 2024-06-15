using FastEndpoints;
using FluentValidation;

namespace Aminoko.Api.Endpoints.Flashcards.UpdateFlashcard;

public class UpdateFlashcardValidator : Validator<UpdateFlashcardRequest>
{
    public UpdateFlashcardValidator()
    {
        RuleFor(x => x.FlashcardId).GreaterThan(0);
        RuleFor(x => x.Front).NotEmpty();
        RuleFor(x => x.Back).NotEmpty();
    }
}
