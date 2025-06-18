using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.Extensions.DependencyInjection;
using SchoolProject.Data.Helpers;
using SchoolProject.infraStructure.Abstracts;
using SchoolProject.infraStructure.Repositories;
using SchoolProject.Service.Abstracts;
using SchoolProject.Service.implementaion;
using SchoolProject.Service.Implementations;
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
            services.AddTransient<IAuthorizationService, AuthorizationService>();
            services.AddTransient<IRefreshTokenRepository, RefreshTokenRepository>();
            services.AddTransient<IApplicationUserService, ApplicationUserService>();
            services.AddTransient<IEmailsService, EmailsService>();
            //services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
            //services.AddTransient<IUrlHelper>(x =>
            //{
            //    var actionContext = x.GetRequiredService<IActionContextAccessor>().ActionContext;
            //    var factory = x.GetRequiredService<IUrlHelperFactory>();
            //    return factory.GetUrlHelper(actionContext);
            //});
            return services;
        }
    }
}
