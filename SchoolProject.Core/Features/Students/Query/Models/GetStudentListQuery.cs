
using MediatR;
using SchoolProject.Core.Features.Students.Query.Resopnse;
using SchoolProject.Data.Entities;

namespace SchoolProject.Core.Features.Students.Query.Models
{
    public class GetStudentListQuery:IRequest<List<GetStudentResponse>>
    {
    }
}
