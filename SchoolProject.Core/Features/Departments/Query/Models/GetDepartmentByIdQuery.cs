using MediatR;
using SchoolProject.Core.Basies;
using SchoolProject.Core.Features.Departments.Query.ResponseDTO;

namespace SchoolProject.Core.Features.Departments.Query.Models
{
    public class GetDepartmentByIdQuery(int id) : IRequest<Response<GetDepartmentByIdResponse>>
    {
        public int Id { get; } = id;
    }
}
