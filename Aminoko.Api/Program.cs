using Amazon;
using Amazon.S3;
using Aminoko.Api.Infrastructure.Exceptions;
using Aminoko.Api.Persistence;
using Aminoko.Api.Persistence.Models;
using Aminoko.Api.Persistence.Repos;
using Aminoko.Api.Services;
using Aminoko.Api.Services.ContentConversion;
using Aminoko.Api.Services.ContentGeneration;
using Aminoko.TemplateGen;
using Aminoko.TemplateGen.Converters;
using FastEndpoints;
using FastEndpoints.Security;
using FastEndpoints.Swagger;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OpenAI_API;

var builder = WebApplication.CreateBuilder();

var config = builder.Configuration;

builder.Services
.AddFastEndpoints()
.SwaggerDocument()
.AddAuthorization()
.AddDbContext<ApplicationContext>(options =>
{
    options.UseLazyLoadingProxies();
    options.UseNpgsql(config.GetConnectionString("DefaultConnection"));
})
.AddIdentity<User, IdentityRole>((options) =>
{
    options.User.RequireUniqueEmail = true;
})
.AddEntityFrameworkStores<ApplicationContext>();

builder.Services
.AddAuthenticationJwtBearer(options =>
    options.SigningKey = config["Security:Tokens:Key"]
        ?? throw new ConfigurationException("JWT security key is not set up."))
.AddAuthentication(o =>
    o.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme);

builder.Services
.AddScoped<IDeckRepo, DeckRepo>()
.AddScoped<ITemplateRepo, TemplateRepo>()
.AddSingleton<ITemplateValidator, TemplateValidator>()
.AddScoped<IWordRepo, WordRepo>()
.AddScoped<IJwtTokenRepo, JwtTokenRepo>()
.AddScoped<IJwtCredsRepo, JwtCredsRepo>()
.AddScoped<IFlashcardRepo, FlashcardRepo>()
.AddSingleton<IOpenAIAPI, OpenAIAPI>()
.AddSingleton<IAudioGenerator, AudioGenerator>()
.AddSingleton<IDefinitionGenerator, DefinitionGenerator>()
.AddSingleton<IImageGenerator, ImageGenerator>()
.AddSingleton<ITranslationGenerator, TranslationGenerator>()
.AddSingleton<ITextGenerator, TextGenerator>()
.AddSingleton<InlineConverterBase, InlineConverter>()
.AddSingleton<BlockConverterBase, BlockConverter>()
.AddSingleton<IFlashcardBuilder, FlashcardBuilder>()
.AddSingleton<FlashcardGen>()
.AddScoped<IFlashcardComposer, FlashcardComposer>()
.AddScoped<IFlashcardRepManager, FlashcardRepManager>()
.AddSingleton<IAmazonS3, AmazonS3Client>(_ => new AmazonS3Client("#", "#", RegionEndpoint.USEast1));

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
