using FastEndpoints;
using FluentValidation;

namespace Aminoko.Api.Endpoints.Templates.UpdateTemplate;

public class UpdateTemplateRequestValidator : Validator<UpdateTemplateRequest>
{
    public UpdateTemplateRequestValidator()
    {
        RuleFor(x => x.TemplateId).GreaterThan(0);
        RuleFor(x => x.Template).NotNull();
        RuleFor(x => x.Template.Id).GreaterThan(0);
        RuleFor(x => x.Template.UserId).NotEmpty();
        RuleFor(x => x.Template.Name).NotEmpty();
    }
}
