using FastEndpoints;
using FluentValidation;

namespace Aminoko.Api.Endpoints.Auth.SignUp;

public class SignUpRequestValidator : Validator<SignUpRequest>
{
    public SignUpRequestValidator()
    {
        RuleFor(x => x.Email).NotEmpty().EmailAddress();
        RuleFor(x => x.Password).NotEmpty();
    }
}
