using MediatR;
using SchoolProject.Core.Basies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.User.Commands.Models
{
    public class DeleteUserCommand(int id) : IRequest<Response<string>>
    {
        public int Id { get; } = id;
    }
}
