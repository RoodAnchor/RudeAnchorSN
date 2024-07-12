using Microsoft.AspNetCore.Diagnostics;

namespace RudeAnchorSN.Utils
{
    public class CustomExceptionHandler : IExceptionHandler
    {
        private readonly ILogger<CustomExceptionHandler> _logger;

        public CustomExceptionHandler(ILogger<CustomExceptionHandler> logger)
        {
            _logger = logger;
        }

        public ValueTask<bool> TryHandleAsync(
            HttpContext httpContext,
            Exception exception,
            CancellationToken cancellationToken)
        {
            var exceptionMessage = exception.Message;

            _logger.LogError($"[{DateTime.Now.ToShortDateString()}] {exceptionMessage}");

            return ValueTask.FromResult( false );
        }
    }
}