using Aminoko.Api.Models;
using Aminoko.Api.Persistence.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Aminoko.Api.Persistence.Repos;

public class JwtCredsRepo : IJwtCredsRepo
{
    private readonly IJwtTokenRepo _jwtTokenRepo;

    public JwtCredsRepo(IJwtTokenRepo jwtTokenRepo)
    {
        _jwtTokenRepo = jwtTokenRepo;
    }

    public JwtCredentials CreateCreds(User user)
    {
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.Email ?? string.Empty),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        var jwt = _jwtTokenRepo.CreateJwt(claims);

        return new JwtCredentials
        {
            Token = jwt.Token,
            Expiration = jwt.Expiration
        };
    }
}
