using SchoolProject.Data.Commons;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace SchoolProject.Data.Entities
{
    [Table(name: "subjects",Schema = "Sub")]
    public class Subject: GeneralLocalizableEntity
    {
        public Subject()
        {
            StudentsSubjects = new HashSet<StudentSubjects>();
            DepartmetsSubjects = new HashSet<DepartmentSubject>();
        }
        [Key]
        public int SubID { get; set; }
        [StringLength(500)]
        public string SubjectNameEN { get; set; }
        [StringLength(500)]
        public string SubjectNameAR { get; set; }
        public DateTime Period { get; set; }
        public virtual ICollection<StudentSubjects> StudentsSubjects { get; set; }
        public virtual ICollection<DepartmentSubject> DepartmetsSubjects { get; set; }
    }
}
