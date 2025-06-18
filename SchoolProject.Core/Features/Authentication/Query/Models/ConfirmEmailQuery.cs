using MediatR;
using SchoolProject.Core.Basies;

namespace SchoolProject.Core.Features.Authentication.Query.Models
{
    public class ConfirmEmailQuery:IRequest<Response<string>>
    {
        public int Userid { get; set; }
        public string Token { get; set; }
    }
}
