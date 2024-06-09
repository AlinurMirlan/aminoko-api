namespace Aminoko.Api.Endpoints.Auth.SignIn;

public sealed class SignInResponse
{
    public required string Jwt { get; set; }

    public DateTime Expiration { get; set; }

    public required string UserId { get; set; }
}
