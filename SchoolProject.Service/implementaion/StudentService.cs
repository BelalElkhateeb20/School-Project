﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Localization;
using SchoolProject.Data.Entities.Views;
using SchoolProject.Data.Enums;
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
                var student = _studentRepository.GetTableNoTracking().Where(x => x.NameEN == _student.NameEN).FirstOrDefault();
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
            var trans = _studentRepository.BeginTransaction();
            try
            {
                if (_student == null)
                {
                    return "Error To update";
                }
                await _studentRepository.UpdateAsync(_student);
                trans.Commit();
                return "success";
            }
            catch
            {
                trans.Rollback();
                return "Error To update";
            }

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
            var student =await _studentRepository.GetTableNoTracking().Where(x => x.NameEN == name).FirstOrDefaultAsync();
            if (student == null)
            {
                return false;
            }
            return true;
        }

        public async Task<bool> IsNameExistExludeSelfAsync(string name, int id)
        {
            var student = await _studentRepository.GetTableNoTracking().Where(x => x.NameEN == name&&x.StudID==id).FirstOrDefaultAsync();
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

        public IQueryable<Student> FilterQueryPaginate(StudentOrderingEnum orderingEnum, string search)
        {
            var queryable = GetStudentsQuerable();

            // Fixing the issue by replacing 'Contains' with a valid condition
            if (search!=null)
            {
                return GetStudentsQuerable()
                .Where(x => x.NameEN.Contains(search) || x.Address.Contains(search) || x.Department.DNameEN.Contains(search)); // Replace "someValue" with the actual value to filter by
            }
            queryable = orderingEnum switch
            {
                StudentOrderingEnum.Name => queryable.OrderBy(x => x.NameEN),
                StudentOrderingEnum.Address => queryable.OrderBy(x => x.Address),
                StudentOrderingEnum.DepartmentName => queryable.OrderBy(x => x.Department.DNameEN),
                _ => queryable.OrderBy(x => x.StudID)
            };

            return queryable;
        }

        public Task<bool> DepartmebtNameISExistAsync(int id)
        {
           return _studentRepository.GetTableNoTracking().AnyAsync(x=>x.DepartmentID.Equals(id));
        }
    }
}
