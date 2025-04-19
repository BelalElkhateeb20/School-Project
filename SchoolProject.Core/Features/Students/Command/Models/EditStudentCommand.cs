using MediatR;
using SchoolProject.Core.Basies;
namespace SchoolProject.Core.Features.Students.Command.Models
{
    public class EditStudentCommand:IRequest<Response<string>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string phone { get; set; }
        public int DepartmentId { get; set; }
        //public string DepartmentName { get; set; }
    }
}
