using System.Net.Http.Headers;
using System.Net.Http.Json;
using open_ai_interaction.DTOs;

namespace open_ai_interaction.Services;

public static class OpenAiServices
{
    public static async Task<string> SendMessage(string message)
    {
        var apiUrl = "https://api.openai.com/v1/chat/completions";
        var apiKey = "Informe aqui sua API Key";

        using HttpClient client = new();
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);

        var response = await client.PostAsJsonAsync(apiUrl, new OpenAiRequest { Messages = new List<OpenAiMessage>{ new OpenAiMessage{ Role = "user", Content = message }}});
        response.EnsureSuccessStatusCode();

        var responseBody = await response.Content.ReadFromJsonAsync<OpenAiResponse>();
        if (responseBody?.Choices != null && responseBody.Choices.Count > 0) return responseBody.Choices[0].Message.Content;

        return "Nenhuma resposta do assistente encontrada na resposta da API.";
    }

    public static async Task<string> SendMessageDebug(string message)
    {
        await Task.Delay(1000);
        return message;
    }
}
