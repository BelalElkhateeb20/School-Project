using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolProject.Data.Entities.Views;

namespace SchoolProject.Infrustructure.Configurations
{
    public class StudentSubjectConfigurations : IEntityTypeConfiguration<StudentSubjects>
    {
        public void Configure(EntityTypeBuilder<StudentSubjects> builder)
        {
            builder
               .HasKey(x => new { x.SubID, x.StudID });


            builder.HasOne(ds => ds.Student)
                     .WithMany(d => d.StudentSubjects)
                     .HasForeignKey(ds => ds.StudID);

            builder.HasOne(ds => ds.Subject)
                 .WithMany(d => d.StudentsSubjects)
                 .HasForeignKey(ds => ds.SubID);

        }
    }
}
