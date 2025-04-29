using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entities;
using SchoolProject.infraStructure.Abstracts;
using SchoolProject.infraStructure.Data;
using SchoolProject.infraStructure.InfrastructureBases;

namespace SchoolProject.infraStructure.Repositories
{
    public class StudentRepository(ApplicationDBContext context) : GenericRepositoryAsync<Student>(context), IStudentRepository
    {
        private readonly DbSet<Student> _students = context.Set<Student>();
        public async Task<List<Student>> GetStudentsAsync()
        {
            return await _students.Include(D=>D.Department).ToListAsync();
        }
        public new async Task<Student> GetStudentByIdAsync(int id)
        {
            var student = await GetTableNoTracking()
                .Where(s => s.StudID == id)
                .FirstOrDefaultAsync();
            return student;
        }
        
        public async Task<Student> GetStudentByIdWithIncludeAsync(int id)
        {
            var student = await GetTableNoTracking()

               .Include(D => D.Department)
               .Where(s => s.StudID == id)
               .FirstOrDefaultAsync();
                       return student;
        }
    }
}
