using Microsoft.AspNetCore.Mvc;
using ILogger = MyWebApi.Services.LoggerService.ILogger;

namespace MyWebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TestController : ControllerBase
{
    private readonly ILogger _loggerService;
    
    public TestController(ILogger loggerService)
    {
        _loggerService = loggerService;
    }
    
    [HttpGet]
    public IActionResult Get()
    {
        _loggerService.Log("Sample text");
        return Ok("Hello World!");
    }
}