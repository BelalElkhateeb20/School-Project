using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entities.Views;
using SchoolProject.infraStructure.Abstracts;
using SchoolProject.Service.Abstracts;

namespace SchoolProject.Service.implementaion
{
    public class DepartmentService(IDepartmentRepository departmentRepository) : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository = departmentRepository;
        public async Task<Department> GetByIdWitheIncludeAsync(int id)
        {
            var department = await _departmentRepository.GetTableNoTracking()
                .Where(x => x.DID == id)
                .Include(x => x.Students)
                .Include(x => x.Instructors)
                .FirstOrDefaultAsync();

            return department;
        }   
    }
}
