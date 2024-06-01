namespace MyWebApi.Services.LoggerService;

public class LoggerService : ILogger
{
    private readonly LoggerConfiguration _config;

    public LoggerService(LoggerConfiguration config)
    {
        _config = config;
    }

    public void Log(string message)
    {
        foreach (var strategy in _config.Strategies)
        {
            strategy.Log(message);
        }
    }
    
}