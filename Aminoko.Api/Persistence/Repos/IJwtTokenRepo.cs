using Aminoko.Api.Models;
using System.Security.Claims;

namespace Aminoko.Api.Persistence.Repos;

public interface IJwtTokenRepo
{
    public JwtCredentials CreateJwt(params Claim[] claims);
}
