using SchoolProject.Core.Features.Students.Command.Models;
using SchoolProject.Data.Entities.Views;
namespace SchoolProject.Core.Mapping.Students
{
    public partial class StudentProfile
    {
        public void EditStudentMapping()
        {
            CreateMap<EditStudentCommand, Student>()
                .ForMember(dest => dest.StudID, opt => opt.Ignore())
                .ForMember(dest => dest.Phone, opt => opt.MapFrom(scr => scr.phone));

        }
    }
}
