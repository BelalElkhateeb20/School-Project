using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entities.Identity;
using SchoolProject.infraStructure.Abstracts;
using SchoolProject.infraStructure.Data;
using SchoolProject.infraStructure.InfrastructureBases;

namespace SchoolProject.infraStructure.Repositories
{
    public class RoleRepository(ApplicationDBContext context) :GenericRepositoryAsync<Role>(context),IRoleRepository
    {
        private readonly DbSet<Role> _roles = context.Set<Role>();
    }
}
