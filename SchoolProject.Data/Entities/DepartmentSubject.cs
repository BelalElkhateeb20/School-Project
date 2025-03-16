using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SchoolProject.Data.Entities
{
    [Table(name: "departmentSubjects", Schema = "DepSub")]

    public class DepartmentSubject 
    {
        [Key]
        public int DeptSubID { get; set; }
        [ForeignKey("DepartmentID")]
        public int DepartmentID { get; set; }
        [ForeignKey("SubID")]
        public int SubID { get; set; }
        public virtual Department Department { get; set; }
        public virtual Subject Subject { get; set; }
    }
}
