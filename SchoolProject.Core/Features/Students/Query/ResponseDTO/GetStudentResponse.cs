using System.ComponentModel.DataAnnotations;

namespace SchoolProject.Core.Features.Students.Query.Resopnse
{
    public class GetStudentResponse //kind Of DTos
    {
        public int StudID { get; set; }
        [StringLength(200)]
        public string Name { get; set; }
        [StringLength(500)]
        public string Address { get; set; }
        [StringLength(500)]
        public string DepartmentName { get; set; }
    }
}
