using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace SchoolProject.Data.Entities
{
    [Table(name: "students", Schema = "Stud")]

    public class Student
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StudID { get; set; }
        [StringLength(200)]
        public string Name { get; set; }
        [StringLength(500)]
        public string Address { get; set; }
        [StringLength(500)]
        public string Phone { get; set; }
        [ForeignKey("DepartmentID")]
        public int? DepartmentID { get; set; } //can be Null
        public virtual Department Department { get; set; }
    }
}
