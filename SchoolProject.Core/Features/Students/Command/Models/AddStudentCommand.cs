using MediatR;
using System.ComponentModel.DataAnnotations;

namespace SchoolProject.Core.Features.Students.Command.Models
{
    public class AddStudentCommand:IRequest<Basies.Response<string>>
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        public string Phone { get; set; }
        public int? DepartmentID { get; set; }
    }
}
