using MediatR;
using SchoolProject.Core.Features.Students.Query.ResponseDTO;
using SchoolProject.Core.Wrappers;
using SchoolProject.Data.Enums;
namespace SchoolProject.Core.Features.Students.Query.Models
{
    public class GetStudentPaginatedQuery:IRequest<PaginatedResult<GetStudentPaginatedResponse>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public StudentOrderingEnum OrderBy { get; set; }
        public string? Search { get; set; }
    }
}
