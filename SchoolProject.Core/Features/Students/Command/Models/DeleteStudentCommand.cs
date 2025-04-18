using MediatR;
using SchoolProject.Core.Basies;

namespace SchoolProject.Core.Features.Students.Command.Models
{
    public class DeleteStudentCommand(int id):IRequest<Response<string>>
    {
        public int Id { get; set; } = id;
    }
}
