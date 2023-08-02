namespace open_ai_interaction.DTOs;

public class OpenAiRequest
{
    public string Model { get; set;} = "gpt-3.5-turbo";
    public List<OpenAiMessage> Messages { get; set;} = new();
    public double Temperature { get; set;} = 0.7;
}
