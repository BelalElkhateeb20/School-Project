using Microsoft.Extensions.DependencyInjection;
using SchoolProject.Data.Helpers;
using SchoolProject.infraStructure.Abstracts;
using SchoolProject.infraStructure.Repositories;
using SchoolProject.Service.Abstracts;
using SchoolProject.Service.implementaion;
using System.Collections.Concurrent;

namespace SchoolProject.Service
{
    public static class ModuleServiceDependencies
    {
        public static IServiceCollection AddServiceDependencies(this IServiceCollection services)
        {
            services.AddTransient<IStudentService, StudentService>();
            services.AddTransient<IDepartmentService, DepartmentService>();
            services.AddTransient<IAuthenticationService, AuthenticationService>();
            services.AddTransient<IRefreshTokenRepository, RefreshTokenRepository>();

            return services;
        }
    }
}
