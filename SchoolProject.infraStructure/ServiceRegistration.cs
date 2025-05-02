using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using SchoolProject.Data.Entities.Identity;
using SchoolProject.infraStructure.Data;
namespace SchoolProject.infraStructure
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddServiceRegistration(this IServiceCollection services)
        {
            
            services.AddIdentity<User, Role>(
                options =>
                {
                    options.Password.RequireDigit = true;
                    options.User.RequireUniqueEmail = true;
                    options.SignIn.RequireConfirmedAccount = true;
                }).AddEntityFrameworkStores<ApplicationDBContext>()
                .AddDefaultTokenProviders(); 


            return services; 
        }
    }
}
