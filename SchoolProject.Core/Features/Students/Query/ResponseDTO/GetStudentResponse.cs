using System.ComponentModel.DataAnnotations;

namespace SchoolProject.Core.Features.Students.Query.Resopnse
{
    public class GetStudentResponse //kind Of DTos
    {
        public int StudID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string DepartmentName { get; set; }
    }
}
