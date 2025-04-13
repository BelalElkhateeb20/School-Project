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
        public async Task<string> EditAsync(Student _student)
        {
            if (_student == null)
            {
                return "Error To update";
            }
            await _studentRepository.UpdateAsync(_student);
            return "success";
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
    }
}
