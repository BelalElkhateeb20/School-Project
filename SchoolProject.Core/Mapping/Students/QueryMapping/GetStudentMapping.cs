using SchoolProject.Core.Features.Students.Query.Resopnse;
using SchoolProject.Data.Entities.Views;
namespace SchoolProject.Core.Mapping.Students
{
    public partial class StudentProfile
    {
        public void GetStudentMapping ()
        {
            CreateMap<Student,GetStudentResponse>()
            .ForMember(dest => dest.DepartmentName, opt => opt.MapFrom(src=>src.Localize(src.Department.DNameAR, src.Department.DNameEN)))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src=>src.Localize(src.NameAR, src.NameEN)));
        }
    }
}
