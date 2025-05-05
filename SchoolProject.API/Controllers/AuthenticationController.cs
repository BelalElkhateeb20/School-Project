using Microsoft.AspNetCore.Mvc;
using SchoolProject.API.Base;
using SchoolProject.Core.Features.Authentication.Commands.Models;
using SchoolProject.Data.Router;

namespace SchoolProject.API.Controllers
{

    [ApiController]
    public class AuthenticationController : AppController
    {
        [HttpPost]
        [Route(Router.Authentication.SignIn)]
        public async Task<IActionResult> SignInAsync([FromForm] SignInCommand signInCommand )
        {
            var response = await Mediator.Send(signInCommand);
            return NewResult(response);
        }
    }
}
