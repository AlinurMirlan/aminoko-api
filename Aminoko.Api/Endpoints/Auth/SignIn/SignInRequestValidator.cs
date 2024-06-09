using FastEndpoints;
using FluentValidation;

namespace Aminoko.Api.Endpoints.Auth.SignIn;

public class SignInRequestValidator : Validator<SignInRequest>
{
    public SignInRequestValidator()
    {
        RuleFor(x => x.Email).NotEmpty().EmailAddress();
        RuleFor(x => x.Password).NotEmpty();
    }
}
