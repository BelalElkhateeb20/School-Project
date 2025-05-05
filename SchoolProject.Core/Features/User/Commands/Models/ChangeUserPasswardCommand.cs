using MediatR;
using SchoolProject.Core.Basies;

namespace SchoolProject.Core.Features.User.Commands.Models
{
    public class ChangeUserPasswardCommand:IRequest<Response<string>>
    {
        public int Id { get; set; } 
        public string OldPassward { get; set; }
        public string NewPassward { get; set; }
        public string ConfirmPassward { get; set; }
    }
}
