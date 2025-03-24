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

        public async Task<string> AddAsync(Student _student)
        {
            var student =_studentRepository.GetTableNoTracking().Where(x => x.Name == _student.Name).FirstOrDefault();
            if (student==null)
            {
                await _studentRepository.AddAsync(_student);
                return "success";
            }
            return "Exists";
        }
    }
}
