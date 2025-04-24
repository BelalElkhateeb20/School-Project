using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;



namespace SchoolProject.Data.Entities
{
    public class Ins_Subject
    {
        [Key]
        public int InsId { get; set; }
        [Key]
        public int SubId { get; set; }

        [ForeignKey(nameof(InsId))]
        [InverseProperty("Ins_Subjects")]
        public Instructor? Instructor { get; set; }


        [ForeignKey(nameof(SubId))]
        [InverseProperty("Ins_Subjects")]
        public Subject? Subject { get; set; }
    }
}
