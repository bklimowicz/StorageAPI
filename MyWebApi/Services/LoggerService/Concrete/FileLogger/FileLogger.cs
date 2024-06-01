using System.Text;

namespace MyWebApi.Services.LoggerService.Concrete.FileLogger;

public class FileLogger : ILogger
{
    private readonly string _path;
    private const string FileName = "log.txt";
    
    public FileLogger(FileLoggerConfiguration configuration)
    {
        _path = configuration.Path;
        if (!File.Exists($"{_path}\\{FileName}"))
        {
            File.Create($"{_path}\\{FileName}");
        }
    }
    
    public void Log(string message)
    {
        File.AppendAllText($"{_path}\\{FileName}", $"{DateTime.Now} - {message}{Environment.NewLine}");
    }
}