
namespace SchoolProject.Core.Features.Students.Query.ResponseDTO
{
    public class GetStudentResponseById
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public int? DepartmentID { get; set; }
        public string DepartmentName { get; set; }
    }
}
