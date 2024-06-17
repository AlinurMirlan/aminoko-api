using Aminoko.TemplateGen;
using FastEndpoints;
using FluentValidation;

namespace Aminoko.Api.Endpoints.Templates.CreateTemplate;

public class CreateTemplateValidator : Validator<CreateTemplateRequest>
{
    public CreateTemplateValidator(ITemplateValidator templateValidator)
    {
        var validationErrors = string.Empty;
        RuleFor(x => x.UserId).NotEmpty();
        RuleFor(x => x.Name).NotNull();
        RuleFor(x => x.Body)
            .NotEmpty()
            .Must(templateBody => templateValidator.IsValid(templateBody, out validationErrors))
            .WithMessage(_ => validationErrors);
    }
}
