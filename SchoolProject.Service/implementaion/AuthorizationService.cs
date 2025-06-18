using Microsoft.AspNetCore.Identity;
using SchoolProject.Data.Entities.Identity;
using SchoolProject.Data.Enums;
using SchoolProject.infraStructure.Data;
using SchoolProject.Service.Abstracts;


namespace SchoolProject.Service.implementaion
{
    public class AuthorizationService(RoleManager<Role> roleManager,ApplicationDBContext dBContext ) : IAuthorizationService
    {
        private readonly RoleManager<Role> _roleManager = roleManager;
        private readonly ApplicationDBContext _dBContext = dBContext;

        public async Task<ResultStatus> AddRoleAsync(Role role)
        {
            var trans = await _dBContext.Database.BeginTransactionAsync();
            try
            {
                var roleIsexistornot = IsRoleExistsAsync(role.Name);

                if (await roleIsexistornot) return ResultStatus.AlreadyExists;
                 var response= await _roleManager.CreateAsync(role);
                if (response.Succeeded)
                {
                    trans.Commit();
                    return ResultStatus.CreatedSuccessflly;
                }
                return ResultStatus.Failed;
            }
            catch
            {
                trans.Rollback();
                return ResultStatus.Failed;
            }

        }
        public async Task<bool> IsRoleExistsAsync(string rolename)
        {
            var _role= await _roleManager.RoleExistsAsync(rolename);
            return _role;
        }
    }
}
