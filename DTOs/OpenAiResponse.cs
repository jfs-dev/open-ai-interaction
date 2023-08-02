namespace open_ai_interaction.DTOs;

public class OpenAiResponse
{
    public List<OpenAiChoice> Choices { get; set;} = new();
}
