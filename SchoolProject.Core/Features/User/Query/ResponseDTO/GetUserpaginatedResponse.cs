using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.User.Query.ResponseDTO
{
    public class GetUserpaginatedResponse(string fullname , string email, string address, string phoneNumber)
    {
        public string? FullName { get; set; } = fullname;
        public string Email { get; set; } = email;
        public string? Address { get; set; } = address;
        public string? PhoneNumber { get; set; } = phoneNumber;
    }
}
