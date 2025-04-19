using SchoolProject.Data.Entities;
using SchoolProject.Data.Enums;

namespace SchoolProject.Service.Abstracts
{
    public interface IStudentService
    {
        public Task<List<Student>> GetStudentsAsync();
        public Task<Student> GetByIdWitheIncludeAsync(int id);
        public Task<Student> GetByIdAsync(int id);
        public Task<string> AddAsync(Student student );
        public Task<string> EditAsync(Student student);
        public Task<string> DeleteAsync(Student student);
        public Task<bool> IsNameExistAsync(string name);
        public Task<bool> IsNameExistExludeSelfAsync(string name,int id);
        public IQueryable<Student> GetStudentsQuerable();
        public IQueryable<Student> FilterQueryPaginate(StudentOrderingEnum orderingEnum,  string search);






    }
}
