using FastEndpoints;
using FluentValidation;

namespace Aminoko.Api.Endpoints.Templates.GetTemplates;

public class GetTemplatesValidator : Validator<GetTemplatesRequest>
{
    public GetTemplatesValidator()
    {
        RuleFor(x => x.UserId).NotEmpty();
        RuleFor(x => x.Page).GreaterThanOrEqualTo(1);
        RuleFor(x => x.PageSize).GreaterThanOrEqualTo(1);
    }
}
