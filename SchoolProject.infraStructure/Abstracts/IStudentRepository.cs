using SchoolProject.Data.Entities;
using SchoolProject.infraStructure.InfrastructureBases;
namespace SchoolProject.infraStructure.Abstracts
{
    public interface IStudentRepository:IGenericRepositoryAsync<Student>
    {
        public Task<List<Student>> GetStudentsAsync();
        public new Task<Student>GetStudentByIdWithIncludeAsync(int id);
        public new Task<Student>GetStudentByIdAsync(int id);
    }
}
