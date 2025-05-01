using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolProject.Data.Entities.Views
{
    [Table(name: "studentSubjects", Schema = "StuSub")]
    public class StudentSubjects
    {
        [Key]
        public int StudSubID { get; set; }
        public int StudID { get; set; }
        public int SubID { get; set; }
        public decimal? grade { get; set; }

        [ForeignKey("StudID")]

        [InverseProperty("StudentSubjects")]

        public virtual Student? Student { get; set; }

        [ForeignKey("SubID")]
        [InverseProperty("StudentsSubjects")]

        public virtual Subject? Subject { get; set; }



    }
}
