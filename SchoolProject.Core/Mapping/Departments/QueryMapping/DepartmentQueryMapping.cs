using SchoolProject.Core.Features.Departments.Query.DTOs;
using SchoolProject.Core.Features.Departments.Query.ResponseDTO;
using SchoolProject.Data.Entities.Views;

namespace SchoolProject.Core.Mapping.Departments
{
    public partial class DepartmentProfile
    {
        public void GetDepartmentMapping()
        {
            CreateMap<Department, GetDepartmentByIdResponse>()
                .ForMember(dest => dest.DName, opt => opt.MapFrom(src => src.Localize(src.DNameAR, src.DNameEN)))
                .ForMember(dest=>dest.InstructorsDTO ,opt=>opt.MapFrom(src => src.Instructors))
                .ForMember(dest => dest.StudentsDTO, opt => opt.MapFrom(src => src.Students));

            CreateMap<Student, StudentDTO>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Localize(src.NameAR, src.NameEN)))
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address))
                .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.Phone))
                .ForMember(dest => dest.StudID, opt => opt.MapFrom(src => src.StudID));

            CreateMap<Instructor, InstractorDTO>()
                .ForMember(dest => dest.SupervisorId, opt => opt.MapFrom(src => src.SupervisorId))
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address))
                .ForMember(dest => dest.Salary, opt => opt.MapFrom(src => src.Salary))
                .ForMember(dest => dest.Position, opt => opt.MapFrom(src => src.Position))
                .ForMember(dest => dest.InsId, opt => opt.MapFrom(src => src.InsId))
                .ForMember(dest => dest.EName, opt => opt.MapFrom(src => src.Localize(src.ENameAr,src.ENameEn)))
                .ForMember(dest => dest.Image, opt => opt.MapFrom(src => src.Image));

            

        }
    }
}
