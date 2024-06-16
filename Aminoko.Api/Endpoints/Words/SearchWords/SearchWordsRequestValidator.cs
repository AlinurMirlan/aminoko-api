using FastEndpoints;
using FluentValidation;

namespace Aminoko.Api.Endpoints.Words.SearchWords;

public class SearchWordsRequestValidator : Validator<SearchWordsRequest>
{
    public SearchWordsRequestValidator()
    {
        RuleFor(x => x.UserId).NotEmpty();
        RuleFor(x => x.Page).GreaterThan(0);
        RuleFor(x => x.PageSize).GreaterThan(0);
        RuleFor(x => x.SearchTerm).NotEmpty();
    }
}
