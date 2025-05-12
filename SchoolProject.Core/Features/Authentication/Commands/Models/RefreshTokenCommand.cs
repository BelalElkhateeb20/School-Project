using MediatR;
using SchoolProject.Core.Basies;
using SchoolProject.Data.Helpers;

namespace SchoolProject.Core.Features.Authentication.Commands.Models
{
    public class RefreshTokenCommand:IRequest<Response<JwtAuthRespone>>
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}
