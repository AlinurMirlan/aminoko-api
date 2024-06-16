namespace Aminoko.Api.Services.ContentGeneration;

public interface IImageGenerator
{
    public Task<string> GenerateImageAsync(string query);
}
