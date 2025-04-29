using Microsoft.Extensions.DependencyInjection;
using SchoolProject.infraStructure.Abstracts;
using SchoolProject.infraStructure.InfrastructureBases;
using SchoolProject.infraStructure.Repositories;

namespace SchoolProject.infraStructure
{
    public static class ModuleInfraStructureDependencies
    {
        public static IServiceCollection AddInfraStructureDependencies(this IServiceCollection services)
        {
             services.AddTransient<IStudentRepository, StudentRepository>();
             services.AddTransient<IDepartmentRepository, DepartmentRepository>();
            services.AddTransient(typeof (IGenericRepositoryAsync<>), typeof(GenericRepositoryAsync<>));
            return services;
        }
    }
}
