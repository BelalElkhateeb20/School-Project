using Azure;
using MediatR;
using SchoolProject.Core.Features.Students.Query.ResponseDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Students.Query.Models
{
    public class GetStudentByIDQuery(int id) : IRequest<Basies.Response<GetStudentResponseById>> // الجزء الى بيدخل فيه الداتا 
    {
        public int Id { get; } = id;
    }
}
