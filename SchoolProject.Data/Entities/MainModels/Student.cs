using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using SchoolProject.Data.Commons;
namespace SchoolProject.Data.Entities.Views
{
    [Table(name: "students", Schema = "Stud")]

    public class Student: GeneralLocalizableEntity
    {
        public Student()
        {
            StudentSubjects = new HashSet<StudentSubjects>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StudID { get; set; }
        [StringLength(200)]
        public string? NameEN { get; set; } 
        [StringLength(200)]
        public string? NameAR { get; set; }
        [StringLength(500)]
        public string? Address { get; set; }
        [StringLength(500)]
        public string? Phone { get; set; }
        [ForeignKey("DepartmentID")]
        public int? DepartmentID { get; set; } //can be Null
        public virtual Department? Department { get; set; }

        [InverseProperty("Student")]

        public ICollection <StudentSubjects> StudentSubjects { get; set; }
    }
}
