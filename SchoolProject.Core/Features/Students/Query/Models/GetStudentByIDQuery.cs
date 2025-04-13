
using MediatR;
using SchoolProject.Core.Features.Students.Query.ResponseDTO;


namespace SchoolProject.Core.Features.Students.Query.Models
{
    public class GetStudentByIDQuery(int id) : IRequest<Basies.Response<GetStudentResponseById>> // الجزء الى بيدخل فيه الداتا 
    {
        public int Id { get; } = id;

    }
}
