namespace Aminoko.Api.Services.ContentGeneration;

public interface ITranslationGenerator
{
    public Task<string> GenerateTranslationAsync(string text);
}
