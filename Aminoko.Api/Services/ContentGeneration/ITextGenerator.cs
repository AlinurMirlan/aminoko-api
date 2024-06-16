namespace Aminoko.Api.Services.ContentGeneration;

public interface ITextGenerator
{
    public Task<string> GenerateTextAsync(string query);
}
