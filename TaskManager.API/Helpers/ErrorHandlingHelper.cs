using Microsoft.AspNetCore.Diagnostics;

namespace TaskManager.API.Helpers
{
    public class ErrorHandlingHelper : IExceptionHandler
    {
        private readonly ILogger<ErrorHandlingHelper> logger;
        public ErrorHandlingHelper(ILogger<ErrorHandlingHelper> logger)
        {
            this.logger = logger;
        }
        public ValueTask<bool> TryHandleAsync(
            HttpContext httpContext,
            Exception exception,
            CancellationToken cancellationToken)
        {
            var exceptionMessage = exception.Message;
            logger.LogError("Error Message: {exceptionMessage}, Time of occurrence {time}", exceptionMessage, DateTime.UtcNow);
            return ValueTask.FromResult(false);
        }
    }
}
