using Microsoft.AspNetCore.Mvc;
using MyWebApi.DataAccess;
using MyWebApi.DataAccess.Models;
using ILogger = MyWebApi.Services.LoggerService.ILogger;

namespace MyWebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TestController : ControllerBase
{
    private readonly ILogger _loggerService;
    private readonly LogsContext _dbContext;
    
    public TestController(ILogger loggerService, LogsContext dbContext)
    {
        _loggerService = loggerService;
        _dbContext = dbContext;
    }
    
    [HttpGet]
    public IActionResult Get()
    {
        _loggerService.Log("Sample text");
        return Ok("Hello World!");
    }
}