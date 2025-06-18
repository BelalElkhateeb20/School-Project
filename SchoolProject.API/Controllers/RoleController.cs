using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.API.Base;
using SchoolProject.Core.Features.Authorization.Commands.Models;
using SchoolProject.Data.Router;

namespace SchoolProject.API.Controllers
{
    [ApiController]
    [Authorize(Roles ="Student")]
    public class RoleController : AppController
    {
        [HttpPost]
        [Route(Router.Authorization.AddRole)]
        public async Task<IActionResult> AddRoleAsync(AddRoleCommand addRole)
        {
            var resopnse = await Mediator.Send(addRole);
            return NewResult(resopnse);
        }
    }
}
