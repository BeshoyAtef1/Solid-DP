
using Microsoft.EntityFrameworkCore.Storage;
using WebApplication1.Data;

namespace WebApplication1.Middlewares
{
    public class TransactionMiddleware : IMiddleware
    {
        Context _dbContext;
        ILogger<TransactionMiddleware> _logger;


        public TransactionMiddleware(Context context, 
            ILogger<TransactionMiddleware> logger)
        {
            _dbContext = context;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext httpContext, RequestDelegate next)
        {
            //if (httpContext.Request.Method == "GET")
            //{
            //    await next(httpContext);
            //    return;
            //}

            IDbContextTransaction transaction = null;

            try
            {
                transaction = await _dbContext.Database.BeginTransactionAsync();

                next(httpContext);

                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();

                _logger.LogError("");

                throw;
            }
        }
    }
}
