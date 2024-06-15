using FastEndpoints;
using FluentValidation;

namespace Aminoko.Api.Endpoints.Templates.CreateTemplate;

public class CreateTemplateValidator : Validator<CreateTemplateRequest>
{
    public CreateTemplateValidator()
    {
        RuleFor(x => x.UserId).NotEmpty();
        RuleFor(x => x.Name).NotNull();
        RuleFor(x => x.Body).NotEmpty();
    }
}
