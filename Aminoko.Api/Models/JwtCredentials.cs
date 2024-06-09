namespace Aminoko.Api.Models;

public class JwtCredentials
{
    public required string Token { get; set; }

    public DateTime Expiration { get; set; }
}
