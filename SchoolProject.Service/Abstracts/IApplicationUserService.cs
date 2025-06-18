using SchoolProject.Data.Entities.Identity;

namespace SchoolProject.Service.Abstracts
{
    public interface IApplicationUserService
    {
        public Task<string> AddAsyenc(User userName, string password ,string role ,int departmentid);
        public Task GenerateEmailToken(User user);
    }
}
