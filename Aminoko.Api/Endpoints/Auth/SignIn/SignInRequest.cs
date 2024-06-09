namespace Aminoko.Api.Endpoints.Auth.SignIn;

public sealed class SignInRequest
{
    public required string Email { get; set; }

    public required string Password { get; set; }
}
