namespace Aminoko.Api.Endpoints.Auth.SignUp;

public sealed class SignUpResponse
{
    public required string Jwt { get; set; }

    public DateTime Expiration { get; set; }

    public required string UserId { get; set; }
}
