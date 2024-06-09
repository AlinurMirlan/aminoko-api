using FastEndpoints;
using FluentValidation;

namespace Aminoko.Api.Endpoints.Decks.CreateDeck;

public class CreateDeckRequestValidator : Validator<CreateDeckRequest>
{
    public CreateDeckRequestValidator()
    {
        RuleFor(x => x.Name).NotEmpty();
        RuleFor(x => x.UserId).NotEmpty();
    }
}
