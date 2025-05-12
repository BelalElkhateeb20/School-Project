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
        [HttpPost]
        [Route(Router.Authentication.RefreshToken)]
        public async Task<IActionResult> RefreshToken( RefreshTokenCommand refreshToken)
        {
            var response = await Mediator.Send(refreshToken);
            return NewResult(response);
        }
        [HttpPost]
        [Route(Router.Authentication.ValidateToken)]
        public async Task<IActionResult> ValidateToken( [FromForm]ValidateTokenCommand  validateToken)
        {
            var response = await Mediator.Send(validateToken);
            return NewResult(response);
        }
    }

}
