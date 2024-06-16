using OpenAI_API;
using OpenAI_API.Models;

namespace Aminoko.Api.Services.ContentGeneration;

public class TextGenerator : ITextGenerator
{
    private readonly IOpenAIAPI _openApi;

    public TextGenerator(IOpenAIAPI openApi)
    {
        _openApi = openApi ?? throw new ArgumentNullException(nameof(openApi));
    }

    public async Task<string> GenerateTextAsync(string query)
    {
        var chat = _openApi.Chat.CreateConversation();
        chat.Model = Model.ChatGPTTurbo;
        chat.AppendUserInput(query);
        var textGen = await chat.GetResponseFromChatbotAsync();
        return textGen.ToString();
    }
}
