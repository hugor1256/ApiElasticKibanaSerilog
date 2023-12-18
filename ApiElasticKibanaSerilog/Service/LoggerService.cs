using ApiElasticKibanaSerilog.Record;
using Serilog.Context;

namespace ApiElasticKibanaSerilog.Service
{
    
public class LoggerService : IloggerService
{
    private readonly ILogger<LoggerService> _logger;

    public LoggerService(ILogger<LoggerService> logger)
    {
        _logger = logger;
    }
    
    public async Task LogInformation(LoggerRequest request)
    {
        var date = DateTime.UtcNow;
        using (LogContext.PushProperty("ApplicationName", request.ApplicationName))
        using (LogContext.PushProperty("LogMessage", request.Message))
        using (LogContext.PushProperty("Date", date))
        {
            await Task.Run(() => _logger.LogInformation($"(Loeg level: Information " +
                                                        $"ApplicationName:{request.ApplicationName}) LogMessage:{request.Message} Date:{date}"));
        }
    }
    
    // public async Task LogInformation(string request)
    // {
    //     var date = DateTime.UtcNow;
    //     using (LogContext.PushProperty("ApplicationName", request.ApplicationName))
    //     using (LogContext.PushProperty("LogMessage", request.Message))
    //     using (LogContext.PushProperty("Date", date))
    //     {
    //         await Task.Run(() => _logger.LogInformation($"(Loeg level: Information " +
    //                                                     $"ApplicationName:{request.ApplicationName}) LogMessage:{request.Message} Date:{date}"));
    //     }
    // }

    public Task LogInformation(string request)
    {
        throw new NotImplementedException();
    }

    public async Task LogWarning(LoggerRequest request)
    {
        var date = DateTime.UtcNow;
        using (LogContext.PushProperty("ApplicationName", request.ApplicationName))
        using (LogContext.PushProperty("LogMessage", request.Message))
        using (LogContext.PushProperty("Date", date))
        {
            await Task.Run(() => _logger.LogWarning($"(Loeg level: Warning " +
                                                        $"ApplicationName:{request.ApplicationName}) LogMessage:{request.Message} Date:{date}"));
        }
    }

    public async Task LogError(LoggerRequest request)
    {
        var date = DateTime.UtcNow;
        using (LogContext.PushProperty("ApplicationName", request.ApplicationName))
        using (LogContext.PushProperty("LogMessage", request.Message))
        using(LogContext.PushProperty("InnerMessage", request.InnerMessage))
        using(LogContext.PushProperty("Stacktrace", request.StackTrace))
        using (LogContext.PushProperty("Date", date))
        {
            await Task.Run(() => _logger.LogError($"(Loeg level: Error " +
                                                    $"ApplicationName:{request.ApplicationName}) LogMessage:{request.Message} Date:{date}"));
        }
    }
}
}

