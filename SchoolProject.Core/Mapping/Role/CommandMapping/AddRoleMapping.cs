using SchoolProject.Core.Features.Authorization.Commands.Models;




namespace SchoolProject.Core.Mapping.Role
{
    public partial class RoleProfile
    {
        public void AddRoleMapping()
        {
            CreateMap<AddRoleCommand, Data.Entities.Identity.Role>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.RoleName));

        }
    }
}
