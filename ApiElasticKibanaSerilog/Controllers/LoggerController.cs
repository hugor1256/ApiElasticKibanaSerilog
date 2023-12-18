using ApiElasticKibanaSerilog.Record;
using ApiElasticKibanaSerilog.Service;
using Microsoft.AspNetCore.Mvc;

namespace ApiElasticKibanaSerilog.Controllers;

[ApiController]
[Route("[controller]")]
public class LoggerController : ControllerBase
{
    private readonly IloggerService _loggerService;
    private readonly ILogger<LoggerService> _logger;

    public LoggerController(IloggerService loggerService, ILogger<LoggerService> logger)
    {
        _loggerService = loggerService;
        _logger = logger;
    }

    [HttpPost]
    [Route("info/")]
    public async Task<IActionResult> LogInformation([FromBody] LoggerRequest request)
    {
        if (request == null)
            return BadRequest();

        _logger.LogInformation("dasaddaadsadsadsasdsada");
        return Ok();
    }
    
    [HttpPost]
    [Route("warning/")]
    public async Task<IActionResult> LogWarning([FromBody] LoggerRequest request)
    {
        if (request == null)
            return BadRequest();

        await _loggerService.LogWarning(request);
        return Ok();
    }
    
    [HttpPost]
    [Route("error/")]
    public async Task<IActionResult> LogError([FromBody] LoggerRequest request)
    {
        if (request == null)
            return BadRequest();

        await _loggerService.LogError(request);
        return Ok();
    }
}