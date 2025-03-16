
using MediatR;
using SchoolProject.Data.Entities;

namespace SchoolProject.Core.Features.Students.Query.Models
{
    public class GetStudentListQuery:IRequest<List<Student>>
    {
    }
}
