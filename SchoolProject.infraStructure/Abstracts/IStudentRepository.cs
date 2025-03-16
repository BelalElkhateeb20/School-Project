﻿using SchoolProject.Data.Entities;

namespace SchoolProject.infraStructure.Abstracts
{
    public interface IStudentRepository
    {
        public Task<List<Student>> GetStudentsAsync();
    }
}
