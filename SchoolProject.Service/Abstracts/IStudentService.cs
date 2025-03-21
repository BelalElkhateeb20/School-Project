using SchoolProject.Data.Entities;

namespace SchoolProject.Service.Abstracts
{
    public interface IStudentService
    {
        public Task<List<Student>> GetStudentsAsync();
        public Task<Student> GetByIdAsync(int id);

    }
}
