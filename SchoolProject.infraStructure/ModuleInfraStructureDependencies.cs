using Microsoft.Extensions.DependencyInjection;
using SchoolProject.infraStructure.Abstracts;
using SchoolProject.infraStructure.Repositories;

namespace SchoolProject.infraStructure
{
    public static class ModuleInfraStructureDependencies
    {
        public static IServiceCollection AddInfraStructureDependencies(this IServiceCollection services)
        {
            return services.AddTransient<IStudentRepository, StudentRepository>();
        }
    }
}
