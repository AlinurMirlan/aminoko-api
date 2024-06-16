using FastEndpoints;
using FluentValidation;

namespace Aminoko.Api.Endpoints.Decks.SearchDecks;

public class SearchDecksRequestValidator : Validator<SearchDecksRequest>
{
    public SearchDecksRequestValidator()
    {
        RuleFor(x => x.UserId).NotEmpty();
        RuleFor(x => x.Page).GreaterThan(0);
        RuleFor(x => x.PageSize).GreaterThan(0);
        RuleFor(x => x.SearchTerm).NotEmpty();
    }
}
