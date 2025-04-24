using SchoolProject.Data.Commons;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace SchoolProject.Data.Entities
{
    [Table(name: "departments", Schema ="Dep")]
    public class Department: GeneralLocalizableEntity
    {
        public Department()
        {
            Students = new HashSet<Student>();
            DepartmentSubjects = new HashSet<DepartmentSubject>();
            Instructors = new HashSet<Instructor>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DID { get; set; }
        [StringLength(500)]
        public string? DNameEN { get; set; }
        [StringLength(500)]
        public string? DNameAR { get; set; }
        public int? InsManager { get; set; }

        [InverseProperty(("Department"))]
        public virtual ICollection<Student> Students { get; set; }
        [InverseProperty("Department")]

        public virtual ICollection<DepartmentSubject> DepartmentSubjects { get; set; }
        [InverseProperty("Department")]

        public virtual ICollection<Instructor> Instructors { get; set; }
        [ForeignKey("InsManager")]
        [InverseProperty("DepartmentManager")]
        public Instructor? Instructor { get; set; }

    }
}
