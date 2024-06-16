using OpenAI_API;
using OpenAI_API.Models;

namespace Aminoko.Api.Services.ContentGeneration;

public class TranslationGenerator : ITranslationGenerator
{
    private const string SystemMessage = "You are an English-Russian translator.";
    private readonly IOpenAIAPI _openApi;

    public TranslationGenerator(IOpenAIAPI openApi)
    {
        _openApi = openApi ?? throw new ArgumentNullException(nameof(openApi));
    }

    public async Task<string> GenerateTranslationAsync(string text)
    {
        var chat = _openApi.Chat.CreateConversation();
        chat.Model = Model.ChatGPTTurbo;
        chat.AppendSystemMessage(SystemMessage);
        chat.AppendUserInput($"Translate: {text}");
        var textGen = await chat.GetResponseFromChatbotAsync();
        return textGen.ToString();
    }
}
