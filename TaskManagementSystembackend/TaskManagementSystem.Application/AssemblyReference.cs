using Microsoft.Extensions.DependencyInjection;
using TaskManagementSystem.Application.Abstraction.IServices;
using TaskManagementSystem.Application.Services;
using TaskManagementSystemApi.AssemblyMarker;

namespace TaskManagementSystem.Application
{
    public static class AssemblyReference
    {
        public static IServiceCollection AddApplicationService(this IServiceCollection services)
        {
            services.AddAutoMapper(cfg => { cfg.LicenseKey = "eyJhbGciOiJSUzI1NiIsImtpZCI6Ikx1Y2t5UGVubnlTb2Z0d2FyZUxpY2Vuc2VLZXkvYmJiMTNhY2I1OTkwNGQ4OWI0Y2IxYzg1ZjA4OGNjZjkiLCJ0eXAiOiJKV1QifQ.eyJpc3MiOiJodHRwczovL2x1Y2t5cGVubnlzb2Z0d2FyZS5jb20iLCJhdWQiOiJMdWNreVBlbm55U29mdHdhcmUiLCJleHAiOiIxODA2NDUxMjAwIiwiaWF0IjoiMTc3NDk1NTU0MyIsImFjY291bnRfaWQiOiIwMTlkNDM5NzgzOTI3ZGM4OTE1ZjZlYWZiMzhlM2FmZCIsImN1c3RvbWVyX2lkIjoiY3RtXzAxa24xc2dlZjFoMmZzYnAyZDdwajhhd3ZhIiwic3ViX2lkIjoiLSIsImVkaXRpb24iOiIwIiwidHlwZSI6IjIifQ.X5Zq6EDCinhTnvZ5IzYn5WDQmIat2OGX4EME9M9cSy9FvfHvcx2gMPkp1H5Dj4YaKufPRsAyon8Tf_-zvhtGp3hCteFEyyzZH8mN8BPIG8b5WqOe4lVXTlwmkw8bg6UABrYGRVENTamlipx1lc15PY_HVB03PJgOb3mLOmfNRwWfHJS2zz7Ac-ipoHLC079UwUjvQ6qq4PqRSH7PWZbP-TVWsSP3Ek-rR5GkgEod1ml4eiBWsAYUSYVsKkM0EF-DQ75RH3axYqW4uWWAHUHAWEYaAOA8GaCS41aj1Waowhs40kelFheY9MZ9FNKMhIGknOB5tLs_MYiIgHV78IUTfQ"; }, typeof(AssemblyMarker));
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<ITaskService, TaskService>();
            services.AddScoped<IUserService, UserService>();
            return services;
        }
    }
}