namespace MyWebApi.Services.LoggerService.Concrete.ConsoleLogger;

public class ConsoleLogger : ILogger
{
    public void Log(string message)
    {
        Console.WriteLine(message);
    }
}