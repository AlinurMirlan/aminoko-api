using FastEndpoints;
using FluentValidation;

namespace Aminoko.Api.Endpoints.Decks.GetDecks;

public class GetDecksRequestValidator : Validator<GetDecksRequest>
{
    public GetDecksRequestValidator()
    {
        RuleFor(x => x.UserId).NotEmpty();
        RuleFor(x => x.Page).GreaterThanOrEqualTo(1);
        RuleFor(x => x.PageSize).GreaterThanOrEqualTo(1);
    }
}
