using SchoolProject.Core.Features.Students.Query.Resopnse;
using SchoolProject.Data.Entities;
namespace SchoolProject.Core.Mapping.Students
{
    public partial class StudentProfile
    {
        public void GetStudentMapping ()
        {
            CreateMap<Student,GetStudentResponse>()
            .ForMember(dest => dest.DepartmentName, opt => opt.MapFrom(x => x.Department.DName));
        }
    }
}
