using FastEndpoints;
using FluentValidation;

namespace Aminoko.Api.Endpoints.Decks.UpdateDeck;

public class UpdateDeckRequestValidator : Validator<UpdateDeckRequest>
{
    public UpdateDeckRequestValidator()
    {
        RuleFor(x => x.DeckId).GreaterThan(0);
        RuleFor(x => x.Name).NotNull();
    }
}
