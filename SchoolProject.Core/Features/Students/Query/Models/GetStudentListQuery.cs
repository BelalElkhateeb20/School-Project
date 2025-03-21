using MediatR;
using SchoolProject.Core.Basies;
using SchoolProject.Core.Features.Students.Query.Resopnse;
namespace SchoolProject.Core.Features.Students.Query.Models
{
    public class GetStudentListQuery:IRequest<Response<List<GetStudentResponse>>>
    {
    }
}
