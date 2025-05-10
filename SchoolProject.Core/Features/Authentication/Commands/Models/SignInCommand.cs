using MediatR;
using SchoolProject.Core.Basies;
using SchoolProject.Data.Helpers;


namespace SchoolProject.Core.Features.Authentication.Commands.Models
{
    public class SignInCommand:IRequest<Response<JwtAuthRespone>>
    {
        public string UserName { get; set; }
        public string Passward { get; set; }

    }
}
