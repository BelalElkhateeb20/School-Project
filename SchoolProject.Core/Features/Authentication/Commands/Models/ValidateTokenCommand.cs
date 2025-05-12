using MediatR;
using SchoolProject.Core.Basies;
using SchoolProject.Data.Helpers;

namespace SchoolProject.Core.Features.Authentication.Commands.Models
{
    public class ValidateTokenCommand:IRequest<Response<TokenValidatedResult>>
    {
        public string AccessToken { get; set; }
    }
}
