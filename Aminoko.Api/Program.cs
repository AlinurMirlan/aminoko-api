using Aminoko.Api.Persistence;
using FastEndpoints;
using FastEndpoints.Security;
using FastEndpoints.Swagger;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder();

var config = builder.Configuration;

builder.Services
.AddFastEndpoints()
.SwaggerDocument()
.AddAuthenticationJwtBearer(options => 
    options.SigningKey = config["Security:Tokens:Key"] 
        ?? throw new InvalidOperationException("JWT security key is not set up."))
.AddAuthorization()
.AddDbContext<ApplicationContext>(options =>
{
    options.UseNpgsql(config.GetConnectionString("DefaultConnection"));
});

var app = builder.Build();

app.UseFastEndpoints(options =>
{
    options.Endpoints.RoutePrefix = "api";
    options.Serializer.Options.PropertyNameCaseInsensitive = true;
})
.UseSwaggerGen()
.UseAuthentication()
.UseAuthorization();

await app.RunAsync();
