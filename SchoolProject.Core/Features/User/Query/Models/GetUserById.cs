using MediatR;
using SchoolProject.Core.Basies;
using SchoolProject.Core.Features.User.Query.ResponseDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.User.Query.Models
{
    public class GetUserByIdQuery(int id) : IRequest<Response<GetUserByIdResponse>>
    {
        public int Id { get; } = id;
    }
}
