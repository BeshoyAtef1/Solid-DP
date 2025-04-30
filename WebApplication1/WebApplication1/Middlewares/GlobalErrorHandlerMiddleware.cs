
using WebApplication1.Data;
using WebApplication1.ViewModels;

namespace WebApplication1.Middlewares
{
    public class GlobalErrorHandlerMiddleware : IMiddleware
    {
        ILogger<GlobalErrorHandlerMiddleware> _logger;

        public GlobalErrorHandlerMiddleware(ILogger<GlobalErrorHandlerMiddleware> logger)
        {
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                ErrorResponseViewModel errorResponse = new ErrorResponseViewModel { ErrorCode = ErrorCode.UnExcepectedError};

                await context.Response.WriteAsJsonAsync(errorResponse);
            }
        }
    }
}
