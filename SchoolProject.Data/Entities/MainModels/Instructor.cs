using SchoolProject.Data.Commons;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace SchoolProject.Data.Entities.Views
{
    public class Instructor : GeneralLocalizableEntity
    {
        public Instructor()
        {
            Instructors = new HashSet<Instructor>();
            Ins_Subjects = new HashSet<Ins_Subject>();
        }
        [Key]
        public int InsId { get; set; }
        public string? ENameAr { get; set; }
        public string? ENameEn { get; set; }
        public string? Address { get; set; }
        public string? Position { get; set; }
        public int? SupervisorId { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal? Salary { get; set; }
        public string? Image { get; set; }

        [ForeignKey(nameof(DepartmentID))]
        public int DepartmentID { get; set; }
        [InverseProperty("Instructors")]
        public Department? Department { get; set; }

        [InverseProperty("Instructor")]
        public Department? DepartmentManager { get; set; }


        [ForeignKey("SupervisorId")]
        [InverseProperty("Instructors")]
        public Instructor? Supervisor { get; set; }

        [InverseProperty("Supervisor")]
        public virtual ICollection <Instructor> Instructors { get; set; }


        [InverseProperty("Instructor")]
        public virtual ICollection <Ins_Subject> Ins_Subjects { get; set; }
    }
}
