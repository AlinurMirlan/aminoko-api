using Aminoko.Api.Infrastructure.Exceptions;
using Aminoko.Api.Models;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace Aminoko.Api.Services.ContentGeneration;

public class DefinitionGenerator : IDefinitionGenerator
{
    private const string DefinitionApiBaseUrl = "https://api.wordnik.com/v4/word.json/";
    private readonly HttpClient _httpClient = new();
    private readonly string _apiKey;

    public DefinitionGenerator()
    {
        _httpClient.BaseAddress = new Uri(DefinitionApiBaseUrl);
        _apiKey = Environment.GetEnvironmentVariable("WORDNIK_API_KEY") ?? throw new ConfigurationException();
    }

    public async Task<string> GenerateDefinitionAsync(string word)
    {
        var response = await _httpClient.GetAsync($"{word.ToLowerInvariant()}/definitions?limit=200&includeRelated=false&useCanonical=false&includeTags=false&api_key={_apiKey}");
        if (!response.IsSuccessStatusCode)
        {
           return string.Empty;
        }

        var stringBuilder = new StringBuilder();
        var content = await response.Content.ReadAsStringAsync();
        var wordDefs = JsonSerializer.Deserialize<List<WordDefinition>>(content) ?? [];

        wordDefs.ForEach(w => w.Definition = Regex.Replace(w.Definition, "<.*?>", string.Empty));
        foreach (var wordDef in wordDefs)
        {
            var partOfSpeech = string.IsNullOrEmpty(wordDef.PartOfSpeech) ? string.Empty : $"({wordDef.PartOfSpeech}) ";
            stringBuilder.AppendLine($"{partOfSpeech}{wordDef.Word}: {wordDef.Definition}");
        }

        return stringBuilder.ToString();
    }
}
