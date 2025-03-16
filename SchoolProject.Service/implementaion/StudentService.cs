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
    }
}
