using System.ComponentModel.DataAnnotations.Schema;


namespace SchoolProject.Data.Entities.Views
{
    [Table(name: "departmentSubjects", Schema = "DepSub")]

    public class DepartmentSubject 
    {
        [ForeignKey("DepartmentID")]
        public int DepartmentID { get; set; }
        [ForeignKey("SubID")]
        public int SubID { get; set; }
        [InverseProperty("DepartmentSubjects")]
        public virtual Department? Department { get; set; }
        [InverseProperty("DepartmetsSubjects")]
        public virtual Subject? Subject { get; set; }
    }
}
