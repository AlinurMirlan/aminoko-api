using Aminoko.Api.Models;
using Aminoko.Api.Persistence.Models;

namespace Aminoko.Api.Persistence.Repos;

public interface IJwtCredsRepo
{
    public JwtCredentials CreateCreds(User user);
}
