
using Bogus.DataSets;

namespace SchoolProject.Core.Features.User.Query.ResponseDTO
{
    public class GetUserByIdResponse
    {
        public string? FullName { get; set; }
        public string Email { get; set; } 
        public string? Address { get; set; }
        public string? PhoneNumber { get; set; } 
    }
}
