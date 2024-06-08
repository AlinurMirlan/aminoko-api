using Aminoko.Api.Models;
using Aminoko.Api.Persistence.Models;

namespace Aminoko.Api.Persistence.Repos;

public interface IJwtTokenRepo
{
    public Credentials CreateJwt(User user);
}
