using Microsoft.EntityFrameworkCore;
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
        public async Task<Student> GetByIdWitheIncludeAsync(int id)
        {
            var student = await _studentRepository.GetStudentByIdWithIncludeAsync(id);

            return student!;
        }


        public async Task<string> AddAsync(Student _student)
        {
            var trans =_studentRepository.BeginTransaction();
            try
            {
                var student = _studentRepository.GetTableNoTracking().Where(x => x.Name == _student.Name).FirstOrDefault();
                if (student == null)
                {
                    await _studentRepository.AddAsync(_student);
                    trans.Commit();
                    return "success";
                }
                return "Exists";
            }
            catch
            {
                trans.Rollback();
                return "Error To Add";
            }

        }
        public async Task<string> EditAsync(Student _student)
        {
            if (_student == null)
            {
                return "Error To update";
            }
            await _studentRepository.UpdateAsync(_student);
            return "success";
        }
        public async Task<string> DeleteAsync(Student _student)
        {
            var trans=  _studentRepository.BeginTransaction();
            try
            {
                if (_student == null)
                {
                    return "Error To Delete";
                }
                await _studentRepository.DeleteAsync(_student);
                trans.Commit();
                return "success";
            }
            catch
            {
                trans.Rollback();
                return "Error To Delete";
            }
        }
        public async Task<bool> IsNameExistAsync(string name)
        {
            var student =await _studentRepository.GetTableNoTracking().Where(x => x.Name == name).FirstOrDefaultAsync();
            if (student == null)
            {
                return false;
            }
            return true;
        }

        public async Task<bool> IsNameExistExludeSelfAsync(string name, int id)
        {
            var student = await _studentRepository.GetTableNoTracking().Where(x => x.Name == name&&x.StudID==id).FirstOrDefaultAsync();
            if (student == null)
            {
                return false;
            }
            return true;
        }

        public IQueryable<Student> GetStudentsQuerable()
        {
            return _studentRepository.GetTableNoTracking()
                .Include(x => x.Department)
                .AsQueryable();
        }

        public IQueryable<Student> FilterQueryPaginate(string search)
        {
            //var queryable = _studentRepository.GetTableNoTracking()
            //    .Include(x => x.Department)
            //    .AsQueryable();
            // Fixing the issue by replacing 'Contains' with a valid condition
             return GetStudentsQuerable()
                .Where(x => x.Name.Contains(search)||x.Address.Contains(search)||x.Department.DName.Contains(search)); // Replace "someValue" with the actual value to filter by

            
        }
    }
}
