using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entities;
using SchoolProject.infraStructure.Abstracts;
using SchoolProject.infraStructure.Data;

namespace SchoolProject.infraStructure.Repositories
{
    class StudentRepository(ApplicationDBContext context) : IStudentRepository
    {
        private readonly ApplicationDBContext _context = context;

        public async Task<List<Student>> GetStudentsAsync()
        {
            return await _context.students.Include(D=>D.Department).ToListAsync();
        }
    }
}
