using FastEndpoints;
using FluentValidation;

namespace Aminoko.Api.Endpoints.Templates.SearchTemplates;

public class SearchTemplatesRequestValidator : Validator<SearchTemplatesRequest>
{
    public SearchTemplatesRequestValidator()
    {
        RuleFor(x => x.UserId).NotEmpty();
        RuleFor(x => x.SearchTerm).NotEmpty();
        RuleFor(x => x.Page).GreaterThan(0);
        RuleFor(x => x.PageSize).GreaterThan(0);
    }
}
