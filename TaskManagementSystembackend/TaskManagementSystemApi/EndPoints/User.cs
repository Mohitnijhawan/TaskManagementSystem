using Carter;
using TaskManagementSystem.Application.Abstraction.IServices;

namespace TaskManagementSystemApi.EndPoints
{
    public class User : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder appbuilder)
        {
            var app = appbuilder.MapGroup("api/users").WithTags("users");

            app.MapGet("", async (IUserService UserService) =>
            {
                return await UserService.GetAllUsers();
            });

            app.MapGet("user-details", async (IUserService UserService) =>
            {
                return await UserService.UserProfile();
            });
        }
    }
}
