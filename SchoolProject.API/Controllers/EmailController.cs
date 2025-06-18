using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.API.Base;
using SchoolProject.Core.Features.Authentication.Commands.Models;
using SchoolProject.Core.Features.Emails.Commands.Models;
using SchoolProject.Data.Router;

namespace SchoolProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : AppController
    {
        [HttpPost]
        [Route(Router.Email.SendEmail)]
        public async Task<IActionResult> SendEmailAsync([FromForm] SendEmailCommand sendEmail)
        {
            var response = await Mediator.Send(sendEmail);
            return NewResult(response);
        }
    }
}
