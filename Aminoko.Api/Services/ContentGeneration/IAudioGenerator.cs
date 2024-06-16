namespace Aminoko.Api.Services.ContentGeneration;

public interface IAudioGenerator
{
    public Task<string> GenerateAudioAsync(string text);
}
