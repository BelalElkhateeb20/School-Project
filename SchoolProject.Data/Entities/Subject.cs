using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace SchoolProject.Data.Entities
{
    [Table(name: "subjects",Schema = "Sub")]
    public class Subject
    {
        public Subject()
        {
            StudentsSubjects = new HashSet<StudentSubjects>();
            DepartmetsSubjects = new HashSet<DepartmentSubject>();
        }
        [Key]
        public int SubID { get; set; }
        [StringLength(500)]
        public string SubjectName { get; set; }
        public DateTime Period { get; set; }
        public virtual ICollection<StudentSubjects> StudentsSubjects { get; set; }
        public virtual ICollection<DepartmentSubject> DepartmetsSubjects { get; set; }
    }
}
