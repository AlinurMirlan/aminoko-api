using Aminoko.Api.Persistence.Models;
using Aminoko.Api.Persistence.Repos;
using FastEndpoints;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace Aminoko.Api.Endpoints.Auth.SignIn;

[HttpPost("auth/signin")]
[AllowAnonymous]
public sealed class SignInEndpoint : Endpoint<SignInRequest, SignInResponse>
{
    private readonly IJwtCredsRepo _jwtCredsRepo;
    private readonly UserManager<User> _userManager;

    public SignInEndpoint(IJwtCredsRepo jwtCredsRepo, UserManager<User> userManager)
    {
        _jwtCredsRepo = jwtCredsRepo ?? throw new ArgumentNullException(nameof(jwtCredsRepo));
        _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
    }

    public override async Task HandleAsync(SignInRequest r, CancellationToken ct)
    {
        var user = await _userManager.FindByEmailAsync(r.Email);
        if (user is null)
        {
            ThrowError("Invalid email or password");
        }

        var result = await _userManager.CheckPasswordAsync(user, r.Password);
        if (!result)
        {
            ThrowError("Invalid email or password");
        }

        var jwt = _jwtCredsRepo.CreateCreds(user);

        await SendAsync(new SignInResponse
        {
            Jwt = jwt.Token,
            Expiration = jwt.Expiration,
            UserId = user.Id
        }, cancellation: ct);
    }
}