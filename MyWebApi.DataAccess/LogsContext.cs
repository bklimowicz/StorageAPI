using Microsoft.EntityFrameworkCore;
using MyWebApi.DataAccess.Models;

namespace MyWebApi.DataAccess;

public class LogsContext : DbContext
{
    public LogsContext(DbContextOptions<LogsContext> options) : base(options)
    {
    }

    public DbSet<Log> Logs { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Log>().ToTable("Logs");
    }
}