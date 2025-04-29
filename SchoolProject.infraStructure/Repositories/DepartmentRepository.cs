using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entities;
using SchoolProject.infraStructure.Abstracts;
using SchoolProject.infraStructure.Data;
using SchoolProject.infraStructure.InfrastructureBases;

namespace SchoolProject.infraStructure.Repositories
{
    public class DepartmentRepository(ApplicationDBContext context) : GenericRepositoryAsync<Department>(context), IDepartmentRepository
    {
        private readonly DbSet<Department> _departments = context.Set<Department>();


    }
}
