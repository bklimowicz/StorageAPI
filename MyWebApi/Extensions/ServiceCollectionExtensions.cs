using MyWebApi.Services;
using MyWebApi.Services.LoggerService;
using ILogger = MyWebApi.Services.LoggerService.ILogger;


namespace MyWebApi.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddLoggerService(this IServiceCollection services, Action<LoggerConfiguration> configureOptions)
    {
        var loggerConfiguration = new LoggerConfiguration();
        configureOptions(loggerConfiguration);
        
        services.AddTransient<ILogger>(_ => new LoggerService(loggerConfiguration));
    } 
}