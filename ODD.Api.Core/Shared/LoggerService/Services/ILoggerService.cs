using LoggerService.Model;

namespace LoggerService.Services
{
    public interface ILoggerService
    {
        public void Log(Model.LogServiceLevel logLevel,string message);
    }
}