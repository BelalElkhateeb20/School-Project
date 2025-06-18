
using SchoolProject.Data.Entities.Identity;
using SchoolProject.Data.Enums;

namespace SchoolProject.Service.Abstracts
{
    public interface IAuthorizationService
    {
        public Task<ResultStatus> AddRoleAsync(Role role);
        public Task<bool> IsRoleExistsAsync(string rolename);
    }
}
