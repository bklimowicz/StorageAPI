using Microsoft.AspNetCore.SignalR;

namespace MyWebApi.Hubs;

public class TestHub : Hub
{
    public async Task SendMessage(string message)
    {
        Console.WriteLine("Sending a message...");
        await Clients.All.SendAsync("ReceiveMessage", message);
    }

    public async Task Test()
    {
        Console.WriteLine("Awaiting 3 seconds...");
        await Task.Delay(TimeSpan.FromSeconds(3));
        Console.WriteLine("Done awaiting!");
    }
}