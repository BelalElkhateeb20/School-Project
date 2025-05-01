using AutoMapper;
using SchoolProject.Core.Features.Students.Query.ResponseDTO;
using SchoolProject.Data.Entities.Views;

namespace SchoolProject.Core.Mapping.Students
{
    public partial class StudentProfile
    {
        public void GetStudentByIdMapping()
        {
            CreateMap<Student, GetStudentResponseById>()
            .ForMember(dest => dest.DepartmentName, opt => opt.MapFrom(src => src.Localize(src.Department.DNameAR, src.Department.DNameEN)))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(x => x.Localize(x.NameAR, x.NameEN)));
        }
    }
}
