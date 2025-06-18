using MediatR;
using SchoolProject.Core.Basies;

namespace SchoolProject.Core.Features.Users.Commands.Models
{
    public class AddUserCommand:IRequest<Response<string>>
    {
        public string UserName { get; set; }
        public string? FullNameEN { get; set; }
        public string? FullNameAR { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public string? Address { get; set; }
        public string? PhoneNumber { get; set; }
        public int DeparmentID { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
