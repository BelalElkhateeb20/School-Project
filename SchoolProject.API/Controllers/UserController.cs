using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.API.Base;
using SchoolProject.Core.Features.User.Commands.Models;
using SchoolProject.Core.Features.User.Query.Models;
using SchoolProject.Core.Features.Users.Commands.Models;
using SchoolProject.Data.Router;


namespace SchoolProject.API.Controllers
{

    [ApiController]
    [Authorize]
    public class UserController : AppController
    {
        [HttpPost]
        [AllowAnonymous]
        [Route(Router.User.perfix)]
        public async Task<IActionResult> AddUserAsync(  AddUserCommand addUser )
        {
            var response = await Mediator.Send(addUser);
            return NewResult(response);
        }

        [HttpGet]
        [Route(Router.User.Paginate)]
        public async Task<IActionResult> GetUserAsync([FromQuery]GetUserPagination getUserPagination )
        {
            var response = await Mediator.Send(getUserPagination);
            return Ok(response);
        }

        [HttpGet]
        [Route(Router.User.GetById)]
        public async Task<IActionResult> GetUserByIdAsync([FromRoute] int id )
        {
            var response = await Mediator.Send(new GetUserByIdQuery(id));
            return NewResult(response);
        }
        [HttpPut]
        [Route(Router.User.Update)]
        public async Task<IActionResult> UpdateUserAsync([FromForm] UpdateUserCommand update)
        {
            var response = await Mediator.Send(update);
            return NewResult(response);
        } 
        [HttpDelete]
        [Route(Router.User.Delete)]
        public async Task<IActionResult> DeleteUserAsync(int id)
        {
            var response = await Mediator.Send(new DeleteUserCommand(id));
            return NewResult(response);
        }
        [HttpPut]
        [Route(Router.User.ChangeUserPassward)]
        public async Task<IActionResult> ChangePasswardUserAsync(ChangeUserPasswardCommand changeUser)
        {
            var response = await Mediator.Send( changeUser);
            return NewResult(response);
        }
    }

}
