using FastEndpoints;
using FluentValidation;

namespace Aminoko.Api.Endpoints.Templates.CreateTemplate;

public class CreateTemplateValidator : Validator<CreateTemplateRequest>
{
    public CreateTemplateValidator()
    {
        RuleFor(x => x.UserId).NotEmpty();
        RuleFor(x => x.Template).NotNull();
        RuleFor(x => x.Template.Name).NotEmpty();
        RuleFor(x => x.Template.Body).NotEmpty();
    }
}
