using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TaskManagementSystem.Application.Abstraction.IRepository;
using TaskManagementSystem.Application.Abstraction.IUnitOfWork;
using TaskManagementSystem.Domain.Entities;
using TaskManagementSystem.Persistance.Data;
using TaskManagementSystem.Persistance.Repository;

namespace TaskManagementSystem.Persistance
{
    public static class AssemblyReference
    {
        public static IServiceCollection AddPersistanceService(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<TaskManagementSystemDbContext>
                (options => options.UseSqlServer(configuration.GetConnectionString
                (nameof(TaskManagementSystemDbContext))));
            services.AddScoped<IAuthRepository, AuthRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ITaskItemRepository, TaskRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            return services;
        }
    }
}
