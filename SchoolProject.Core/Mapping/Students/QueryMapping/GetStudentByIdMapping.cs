using AutoMapper;
using SchoolProject.Core.Features.Students.Query.ResponseDTO;
using SchoolProject.Data.Entities;

namespace SchoolProject.Core.Mapping.Students
{
    public partial class StudentProfile
    {
        public void GetStudentByIdMapping()
        {
            CreateMap<Student, GetStudentResponseById>()
            .ForMember(dest => dest.DepartmentName, opt => opt.MapFrom(x => x.Department.DName));
        }
    }
}
