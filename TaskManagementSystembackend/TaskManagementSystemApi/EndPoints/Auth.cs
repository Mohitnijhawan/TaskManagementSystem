using System.Security.Claims;
using Carter;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Google;
using TaskManagementSystem.Application.Abstraction.IServices;
using TaskManagementSystem.Application.RRModel.Auth;

namespace TaskManagementSystemApi.EndPoints
{
    public class Auth : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder appbuilder)
        {
            var app = appbuilder.MapGroup("api/auth").WithTags("auth");
            app.MapPost("sign-up", async (IAuthService authService, SignUpRequest model) =>
            {
                return await authService.SignUp(model);

            }).DisableAntiforgery();

            app.MapPost("login", async (IAuthService authService, LoginRequest model) =>
            {
                return await authService.Login(model);

            }).DisableAntiforgery();

            app.MapGet("auth/google", async (HttpContext context) =>
            {
                var properties = new AuthenticationProperties
                {
                    RedirectUri = "/auth/google-response"
                };

                await context.ChallengeAsync(GoogleDefaults.AuthenticationScheme, properties);
            });

                                app.MapGet("auth/google-response", async (
                        HttpContext context,
                        IAuthService authService) =>
            {
                var result = await context.AuthenticateAsync();

                if (!result.Succeeded)
                    return Results.BadRequest("Google auth failed");

                var email = result.Principal.FindFirst(ClaimTypes.Email)?.Value;
                var name = result.Principal.FindFirst(ClaimTypes.Name)?.Value;

                var response = await authService.GoogleLogin(email!, name!);

                return Results.Redirect($"http://localhost:5173/oauth-success?token={response?.Value?.Token}");
            });

            app.MapPut("block-user/{id:guid}", async (Guid id, IAuthService authService) =>
            {
                return await authService.BlockUser(id);
            });

        }
    }
}
