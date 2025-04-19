using AutoMapper;
using SchoolProject.Core.Features.Students.Command.Models;
using SchoolProject.Data.Entities;
namespace SchoolProject.Core.Mapping.Students
{
    public partial class StudentProfile
    {
        public void EditStudentMapping()
        {
            CreateMap<EditStudentCommand, Student>()
                .ForPath(dest => dest.Department.DID, opt => opt.MapFrom(scr => scr.DepartmentId))
                .ForPath(dest => dest.Department.DName,opt=>opt.Ignore())
                .ForMember(dest => dest.StudID, opt => opt.Ignore())
                .ForMember(dest => dest.Phone, opt => opt.MapFrom(scr => scr.phone));

        }
    }
}
