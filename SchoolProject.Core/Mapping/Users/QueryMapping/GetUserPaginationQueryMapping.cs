

using Bogus.DataSets;
using SchoolProject.Core.Features.User.Query.ResponseDTO;
using SchoolProject.Data.Entities.Identity;

namespace SchoolProject.Core.Mapping.Users
{
    public partial class UserProfile
    {
        public void GetUserPaginationQueryMapping()
        {
            CreateMap<User, GetUserpaginatedResponse>();
        }
    }
}
