﻿using Aminoko.Api.Models;
using Aminoko.Api.Persistence.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Aminoko.Api.Persistence.Repos;

public class JwtTokenRepo : IJwtTokenRepo
{
    private readonly IConfiguration _config;

    public JwtTokenRepo(IConfiguration config)
    {
        _config = config;
    }

    public Credentials CreateJwt(User user)
    {
        var claims = new Claim[]
        {
            new(JwtRegisteredClaimNames.Sub, user.Email ?? string.Empty),
            new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        var key = _config["Security:Tokens:Key"] ?? throw new InvalidOperationException("JWT security key is not set.");
        var audience = _config["Security:Tokens:Audience"] ?? throw new InvalidOperationException("JWT audience is not set.");
        var issuer = _config["Security:Tokens:Issuer"] ?? throw new InvalidOperationException("JWT issuer is not set.");

        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
        var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
        var expiration = DateTime.Now.AddHours(5);

        var jwtSecurityToken = new JwtSecurityToken
        (
            issuer: issuer,
            audience: audience,
            claims: claims,
            expires: expiration,
            signingCredentials: signingCredentials
        );

        string jwt = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
        return new Credentials
        {
            Jwt = jwt,
            Expiration = expiration,
            UserId = user.Id
        };
    }
}