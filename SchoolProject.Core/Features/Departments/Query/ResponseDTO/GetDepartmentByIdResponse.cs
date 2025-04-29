
using SchoolProject.Core.Features.Departments.Query.DTOs;
using SchoolProject.Data.Entities;
using System.ComponentModel.DataAnnotations;

namespace SchoolProject.Core.Features.Departments.Query.ResponseDTO
{
    public class GetDepartmentByIdResponse
    {
        public string? DName { get; set; }
        //public string? Address { get; set; }
        //public string? Phone { get; set; }
        public List<StudentDTO> StudentsDTO { get; set; } = [];
        public List<InstractorDTO> InstructorsDTO { get; set; } = [];
    }
}
