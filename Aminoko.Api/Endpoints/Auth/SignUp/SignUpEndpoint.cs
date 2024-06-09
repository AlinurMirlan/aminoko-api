using Aminoko.Api.Persistence.Models;
using Aminoko.Api.Persistence.Repos;
using FastEndpoints;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace Aminoko.Api.Endpoints.Auth.SignUp;

[HttpPost("auth/signup")]
[AllowAnonymous]
public sealed class SignUpEndpoint : Endpoint<SignUpRequest, SignUpResponse>
{
    private readonly UserManager<User> _userManager;
    private readonly IJwtCredsRepo _jwtCredsRepo;

    public SignUpEndpoint(IJwtCredsRepo jwtCredsRepo, UserManager<User> userManager)
    {
        _jwtCredsRepo = jwtCredsRepo;
        _userManager = userManager;
    }

    public override async Task HandleAsync(SignUpRequest r, CancellationToken c)
    {
        var user = new User
        {
            Email = r.Email,
            UserName = r.Email
        };

        var result = await _userManager.CreateAsync(user, r.Password);
        if (!result.Succeeded)
        {
            ThrowError(result.Errors.First().Description);
        }

        var jwt = _jwtCredsRepo.CreateCreds(user);

        await SendAsync(new SignUpResponse
        {
            Jwt = jwt.Token,
            Expiration = jwt.Expiration,
            UserId = user.Id
        }, cancellation: c);
    }
}