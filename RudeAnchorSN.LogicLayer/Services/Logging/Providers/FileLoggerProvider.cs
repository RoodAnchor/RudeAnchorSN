using Microsoft.Extensions.Logging;
using RudeAnchorSN.LogicLayer.Services.Logging.Loggers;

namespace RudeAnchorSN.LogicLayer.Services.Logging.Providers
{

    [ProviderAlias("FileLogger")]
    public class FileLoggerProvider : ILoggerProvider
    {
        public ILogger CreateLogger(string categoryName)
        {
            return new FileLogger();
        }

        public void Dispose() { }
    }
}
