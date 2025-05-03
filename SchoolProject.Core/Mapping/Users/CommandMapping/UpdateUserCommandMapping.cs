

using SchoolProject.Core.Features.User.Commands.Models;
using SchoolProject.Core.Features.Users.Commands.Models;
using SchoolProject.Data.Entities.Identity;

namespace SchoolProject.Core.Mapping.Users
{
    public partial class UserProfile
    {
        public void UpdateUserCommandMapping()
        {
            CreateMap<User, UpdateUserCommand>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());


        }
    }
}
