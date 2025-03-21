using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using SchoolProject.Data.Entities;
using SchoolProject.infraStructure.Abstracts;
using SchoolProject.Service.Abstracts;
namespace SchoolProject.Service.implementaion
{
    public class StudentService(IStudentRepository studentRepository) : IStudentService
    {
        private readonly IStudentRepository _studentRepository = studentRepository;

        public async Task<List<Student>> GetStudentsAsync()
        {
            return await _studentRepository.GetStudentsAsync();
        }
        public async Task<Student> GetByIdAsync(int id)
        {
            var student = await _studentRepository.GetStudentByIdAsync(id);

            return student!;
        }
        
    }
}
