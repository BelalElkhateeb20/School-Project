using Microsoft.AspNetCore.Mvc;
using SchoolProject.API.Base;
using SchoolProject.Core.Features.Users.Commands.Models;
using SchoolProject.Data.Router;


namespace SchoolProject.API.Controllers
{

    [ApiController]
    public class UserController : AppController
    {
        [HttpPost]
        [Route(Router.User.perfix)]
        public async Task<IActionResult> AddUserAsync(  AddUserCommand addUser )
        {
            var response = await Mediator.Send(addUser);

            return NewResult(response);
        }
    }
}
