﻿using MediatR;
using SchoolProject.Core.Basies;
namespace SchoolProject.Core.Features.User.Commands.Models
{
    public class UpdateUserCommand: IRequest<Response<string>>
    {
        public int Id { get; set; }
        public string? UserName { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public string? PhoneNumber { get; set; }
    }
}
