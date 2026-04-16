using Microsoft.AspNetCore.Diagnostics;

namespace TaskManagementSystemApi
{
    using Microsoft.AspNetCore.Diagnostics;
    using TaskManagementSystem.Domain.Entities;
    using TaskManagementSystem.Persistance.Data;

    public class GlobalExceptionHandler : IExceptionHandler
    {
        private readonly IServiceScopeFactory _scopeFactory;

        public GlobalExceptionHandler(IServiceScopeFactory scopeFactory)
        {
            _scopeFactory = scopeFactory;
        }

        public async ValueTask<bool> TryHandleAsync(
        HttpContext httpContext,
        Exception exception,
        CancellationToken cancellationToken)
        {
            using var scope = _scopeFactory.CreateScope();

            var db = scope.ServiceProvider.GetRequiredService<TaskManagementSystemDbContext>();

            var error = new ErrorLog
            {
                Message = exception.Message,
                StackTrace = exception.StackTrace,
                Source = exception.Source,
            };

            db.ErrorLogs.Add(error);
            await db.SaveChangesAsync(cancellationToken);

            httpContext.Response.StatusCode = 500;
            await httpContext.Response.WriteAsJsonAsync("Something went wrong");

            return true;
        }
    }
}


