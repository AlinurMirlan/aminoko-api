using System.Text.Json.Serialization;

namespace Aminoko.Api.Models;

public class WordDefinition
{
    [JsonPropertyName("word")]
    public required string Word { get; set; }

    [JsonPropertyName("text")]
    public required string Definition { get; set; }

    [JsonPropertyName("partOfSpeech")]
    public string? PartOfSpeech { get; set; }
}

