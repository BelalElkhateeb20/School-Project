using MediatR;
using SchoolProject.Core.Features.User.Query.ResponseDTO;
using SchoolProject.Core.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.User.Query.Models
{
    public class GetUserPagination:IRequest<PaginatedResult<GetUserpaginatedResponse>>
    {
        public int pageSize { get; set; }
        public int pageNumber { get; set; }
    }
}
