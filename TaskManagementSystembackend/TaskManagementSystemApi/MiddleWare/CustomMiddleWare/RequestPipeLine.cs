using Carter;
using TaskManagementSystemApi.MiddleWare.ResultResponseMiddleWare;

namespace TaskManagementSystemApi.MiddleWare.CustomMiddleWare
{
    public static class RequestPipeLine
    {
        public static WebApplication UseCustomMiddleWare(this WebApplication app)
        {

            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }
            app.UseCors(options =>
            {
                options.SetIsOriginAllowed(_ => true).AllowAnyMethod().AllowAnyHeader();
            });
            app.UseHttpsRedirection();
            app.UseExceptionHandler();
            app.UseAuthentication();
            app.UseAuthorization();
            app.MapCarter();
            app.UseResultResponseMiddleware();
            app.Run();
            return app;
        }
    }
}
