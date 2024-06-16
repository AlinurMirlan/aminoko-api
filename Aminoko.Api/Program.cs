using Aminoko.Api.Infrastructure.Exceptions;
using Aminoko.Api.Persistence;
using Aminoko.Api.Persistence.Repos;
using Aminoko.Api.Services;
using Aminoko.Api.Services.ContentConversion;
using Aminoko.Api.Services.ContentGeneration;
using Aminoko.TemplateGen;
using Aminoko.TemplateGen.Converters;
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
        ?? throw new ConfigurationException("JWT security key is not set up."))
.AddAuthorization()
.AddDbContext<ApplicationContext>(options =>
{
    options.UseNpgsql(config.GetConnectionString("DefaultConnection"));
})
.AddSingleton<IDeckRepo, DeckRepo>()
.AddSingleton<ITemplateRepo, TemplateRepo>()
.AddSingleton<ITemplateValidator, TemplateValidator>()
.AddSingleton<IWordRepo, WordRepo>()
.AddSingleton<IJwtCredsRepo, JwtCredsRepo>()
.AddSingleton<IFlashcardRepo, FlashcardRepo>()
.AddSingleton<IAudioGenerator, AudioGenerator>()
.AddSingleton<IDefinitionGenerator, DefinitionGenerator>()
.AddSingleton<IImageGenerator, ImageGenerator>()
.AddSingleton<ITranslationGenerator, TranslationGenerator>()
.AddSingleton<ITextGenerator, TextGenerator>()
.AddSingleton<InlineConverterBase, InlineConverter>()
.AddSingleton<BlockConverterBase, BlockConverter>()
.AddSingleton<IFlashcardBuilder, FlashcardBuilder>()
.AddSingleton<IFlashcardGen, FlashcardGen>()
.AddSingleton<IFlashcardComposer, FlashcardComposer>()
.AddSingleton<IFlashcardRepManager, FlashcardRepManager>();

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
