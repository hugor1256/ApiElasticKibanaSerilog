using ApiElasticKibanaSerilog.Record;

namespace ApiElasticKibanaSerilog.Service
{
    
public interface IloggerService
{
    // Task LogInformation(LoggerRequest request);
    Task LogInformation(string request);
    Task LogWarning(LoggerRequest request);
    Task LogError(LoggerRequest request);
}
}

