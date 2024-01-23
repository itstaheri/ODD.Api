using LoggerService.Model;
using LoggerService.Services;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace LoggerService.Implement
{
    public class SeriLogService : ILoggerService
    {

        private readonly ILogger<SeriLogService> _logger;

        public SeriLogService(ILogger<SeriLogService> logger)
        {
            _logger = logger;
        }

        public void Log(LogServiceLevel logLevel, string message)
        {

            if (string.IsNullOrEmpty(message) )
            {
                _logger.LogError( JsonConvert.SerializeObject(new LogModel { LogLevel = logLevel.ToString(), Message = message, DateTime = DateTime.Now.ToString() }));
            }
            switch (logLevel)
            {
                case LogServiceLevel.Trace:
                    _logger.LogTrace( JsonConvert.SerializeObject(new LogModel { LogLevel = logLevel.ToString(), Message = message, DateTime = DateTime.Now.ToString() }));
                    break;
                case LogServiceLevel.Warning:
                    _logger.LogWarning(JsonConvert.SerializeObject(new LogModel { LogLevel = logLevel.ToString(), Message = message, DateTime = DateTime.Now.ToString()}));
                    break;
                case LogServiceLevel.Error:
                    _logger.LogError( JsonConvert.SerializeObject(new LogModel { LogLevel = logLevel.ToString(), Message = message, DateTime = DateTime.Now.ToString() }));
                    break;
                
                case LogServiceLevel.Information:
                    _logger.LogInformation( JsonConvert.SerializeObject(new LogModel { LogLevel = logLevel.ToString(), Message = message, DateTime = DateTime.Now.ToString()}));
                    break;
                default:
                    break;
            }
        }
    }
}
