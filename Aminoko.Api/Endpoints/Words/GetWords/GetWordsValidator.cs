using FastEndpoints;
using FluentValidation;

namespace Aminoko.Api.Endpoints.Words.GetWords;

public class GetWordsValidator : Validator<GetWordsRequest>
{
    public GetWordsValidator()
    {
        RuleFor(x => x.UserId).NotEmpty();
        RuleFor(x => x.Page).GreaterThan(0);
        RuleFor(x => x.PageSize).GreaterThan(0);
    }
}
