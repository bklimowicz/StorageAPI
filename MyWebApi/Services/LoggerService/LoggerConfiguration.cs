using MyWebApi.Services.LoggerService.Concrete;
using MyWebApi.Services.LoggerService.Concrete.ConsoleLogger;
using MyWebApi.Services.LoggerService.Concrete.DatabaseLogger;
using MyWebApi.Services.LoggerService.Concrete.FileLogger;

namespace MyWebApi.Services.LoggerService;

public class LoggerConfiguration
{
    public List<ILogger> Strategies { get; } = new();

    public void AddConsoleLogger()
    {
        Strategies.Add(new ConsoleLogger());
    }

    public void AddFileLogger(Func<FileLoggerConfiguration> configuration)
    {
        var logger = new FileLogger(configuration());
        
        Strategies.Add(logger);
    }
    
    public void AddDatabaseLogger()
    {
        Strategies.Add(new DatabaseLogger());
    }
}