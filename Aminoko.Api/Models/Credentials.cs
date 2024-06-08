namespace Aminoko.Api.Models;

public class Credentials
{
    public required string Jwt { get; set; }

    public DateTime Expiration { get; set; }

    public required string UserId { get; set; }
}
