using Aminoko.Api.Endpoints.Flashcards.GetFlashcardIds;
using FastEndpoints;
using FluentValidation;

namespace Aminoko.Api.Endpoints.Flashcards.GetDueFlashcardIds;

public class GetDueFlashcardIdsRequestValidator : Validator<GetDueFlashcardIdsRequest>
{
    public GetDueFlashcardIdsRequestValidator()
    {
        RuleFor(x => x.UserId).NotEmpty();
    }
}
