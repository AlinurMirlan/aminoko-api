namespace Aminoko.Api.Endpoints.Auth.SignUp;

public sealed class SignUpRequest
{
    public required string Email { get; set; }

    public required string Password { get; set; }
}
