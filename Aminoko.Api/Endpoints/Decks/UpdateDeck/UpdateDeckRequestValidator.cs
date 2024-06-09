using FastEndpoints;
using FluentValidation;

namespace Aminoko.Api.Endpoints.Decks.UpdateDeck;

public class UpdateDeckRequestValidator : Validator<UpdateDeckRequest>
{
    public UpdateDeckRequestValidator()
    {
        RuleFor(x => x.DeckId).GreaterThan(0);
        RuleFor(x => x.Deck).NotNull();
        RuleFor(x => x.Deck.Id).GreaterThan(0);
        RuleFor(x => x.Deck.UserId).NotEmpty();
        RuleFor(x => x.Deck.Name).NotEmpty();
    }
}
