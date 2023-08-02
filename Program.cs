using open_ai_interaction.Services;

try
{
    do
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("Digite sua mensagem: ");
        Console.ResetColor();
        
        var message = Console.ReadLine();

        if (!string.IsNullOrWhiteSpace(message))
        {
            var response = await OpenAiServices.SendMessage(message);

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("\nAssistente: ");
            Console.ResetColor();
            Console.WriteLine($"{response}");
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\nFavor informar sua mensagem!");
        }

        Console.ForegroundColor = ConsoleColor.Blue;
        Console.Write("\n[Enter] ");
        Console.ResetColor();
        Console.Write("para continuar ou ");
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.Write("[Esc] ");
        Console.ResetColor();
        Console.WriteLine("para sair");
        
        Console.WriteLine();
    } while (Console.ReadKey(true).Key != ConsoleKey.Escape);    
}
catch (HttpRequestException ex)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine($"Erro na solicitação HTTP: {ex.Message}");
}
catch (Exception ex)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine($"Erro não tratado: {ex.Message}");
}
finally
{
    Console.ResetColor();
}
