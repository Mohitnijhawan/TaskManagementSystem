using Microsoft.Extensions.DependencyInjection;
using TaskManagementSystem.Application.Abstraction.AppEncryption;
using TaskManagementSystem.Application.Abstraction.Identity;
using TaskManagementSystem.Application.Abstraction.IJWTProvider;
using TaskManagementSystem.InfraStructure.Identity;

namespace TaskManagementSystem.InfraStructure
{
    public static class AssemblyReference
    {
        public static IServiceCollection AddInfraStructureService(this IServiceCollection services)
        {
            services.AddScoped<IAppEncryption, AppEncryption.AppEncryption>();
            services.AddScoped<IJWTProvider, JWTProvider.JWTProvider>();
            services.AddScoped<IHttpContextService, HttpContextService>();
            return services;
        }
    }
}
