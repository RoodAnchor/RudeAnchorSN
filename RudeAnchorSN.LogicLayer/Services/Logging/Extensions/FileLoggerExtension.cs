using Microsoft.Extensions.Logging;
using RudeAnchorSN.LogicLayer.Services.Logging.Providers;

namespace RudeAnchorSN.LogicLayer.Services.Logging.Extensions
{
    public static class FileLoggerExtension
    {
        public static ILoggingBuilder AddFileLogger(this ILoggingBuilder builder) 
        {
            builder.AddProvider(new FileLoggerProvider());

            return builder;
        }
    }
}
