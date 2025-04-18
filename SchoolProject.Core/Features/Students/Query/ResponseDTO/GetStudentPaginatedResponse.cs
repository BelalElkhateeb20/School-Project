

using System.Net;

namespace SchoolProject.Core.Features.Students.Query.ResponseDTO
{
    public class GetStudentPaginatedResponse(int studID, string name, string address, string departmentName)
    {
        public int StudID { get; set; } = studID;
        public string Name { get; set; } = name;
        public string Address { get; set; } = address;
        public string DepartmentName { get; set; } = departmentName;
    }
}
