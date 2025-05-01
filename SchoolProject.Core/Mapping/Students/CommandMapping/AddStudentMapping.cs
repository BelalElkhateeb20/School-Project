using SchoolProject.Core.Features.Students.Command.Models;
using SchoolProject.Data.Entities.Views;

namespace SchoolProject.Core.Mapping.Students
{
    public partial class StudentProfile
    {
        public void AddStudentMapping()
        {
            CreateMap<AddStudentCommand, Student>()
                .ForMember(dest => dest.DepartmentID, opt => opt.MapFrom(scr => scr.DepartmentID));
        }
    }
}
