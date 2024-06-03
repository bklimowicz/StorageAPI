using MyWebApi.DataAccess;
using MyWebApi.DataAccess.Models;

namespace MyWebApi.Services.LoggerService.Concrete.DatabaseLogger;

public class DatabaseLogger : ILogger
{
    private readonly LogsContext _context;

    public DatabaseLogger(LogsContext context)
    {
        _context = context;
    }
    
    public void Log(string message)
    {
        _context.Logs.Add(new Log
        {
            Id = Guid.NewGuid(),
            Text = message,
            LoggedOn = DateTime.UtcNow
        });
        _context.SaveChanges();
    }
}