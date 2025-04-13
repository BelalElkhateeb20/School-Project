﻿using SchoolProject.Data.Entities;

namespace SchoolProject.Service.Abstracts
{
    public interface IStudentService
    {
        public Task<List<Student>> GetStudentsAsync();
        public Task<Student> GetByIdAsync(int id);
        public Task<string> AddAsync(Student student );
        public Task<string> EditAsync(Student student);
        public Task<bool> IsNameExistAsync(string name);
        public Task<bool> IsNameExistExludeSelfAsync(string name,int id);




    }
}
