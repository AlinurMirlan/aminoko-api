namespace Aminoko.Api.Services.ContentGeneration;

public interface IDefinitionGenerator
{
    public Task<string> GenerateDefinitionAsync(string word);

}
