using Microsoft.AspNetCore.Mvc;

namespace MyWebApi.Extensions;

public static class ControllerBaseExtensions
{
    public static IActionResult BadRequestWithException(this ControllerBase controllerBase, string text, Exception exception)
    {
        Console.WriteLine($"{DateTime.Now.ToUniversalTime()} - Exception: {exception}");
        return controllerBase.BadRequest(text);
    }
}