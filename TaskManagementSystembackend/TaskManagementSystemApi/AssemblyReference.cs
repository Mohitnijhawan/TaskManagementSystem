using System.Text;
using Carter;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using TaskManagementSystem.Application;
using TaskManagementSystem.InfraStructure;
using TaskManagementSystem.Persistance;

namespace TaskManagementSystemApi
{
    public static class AssemblyReference
    {

        public static IServiceCollection AddApiService(this IServiceCollection services, IConfiguration configuration)
        {
            
            services.AddCors();

            services.AddOpenApi();
            services.AddCarter();
            services.AddHttpContextAccessor();

            services.AddExceptionHandler<GlobalExceptionHandler>();
            services.AddProblemDetails();

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidAudience = configuration["JWT:Audience"],
                    ValidateAudience = true,
                    ValidIssuer = configuration["JWT:Issuer"],
                    ValidateIssuer = true,
                    ValidateIssuerSigningKey = true,
                    RequireExpirationTime = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Key"]!))
                };
            });

            services.AddAuthorization();
            services.AddApplicationService()
                    .AddPersistanceService(configuration)
                    .AddInfraStructureService();

            return services;
        }
    }
};



