namespace MyWebApi.DataAccess.Models;

public class Log
{
    public Guid Id { get; init; }
    public string Text { get; init; }
    public DateTime LoggedOn { get; init; }
}