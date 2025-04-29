
namespace SchoolProject.Core.Features.Departments.Query.DTOs
{
    public class InstractorDTO
    {
        public int InsId { get; set; }
        public string EName { get; set; }
        public string Address { get; set; }
        public string Position { get; set; }
        public int SupervisorId { get; set; }
        public decimal Salary { get; set; }
        public string Image { get; set; }
    }
}
