using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolProject.Data.Entities.Views;
namespace SchoolProject.infraStructure.DataSeedingConfigurations
{
    public class SubjectSeedingConfig : IEntityTypeConfiguration<Subject>
    {
        public void Configure(EntityTypeBuilder<Subject> builder)
        {
            builder.HasData(
           new Subject { SubID = 1, SubjectNameEN = "Engineering Mathematics", SubjectNameAR = "رياضيات هندسية", Period = 3 },
           new Subject { SubID = 2, SubjectNameEN = "Physics for Engineers", SubjectNameAR = "فيزياء للمهندسين", Period = 3 },
           new Subject { SubID = 3, SubjectNameEN = "Thermodynamics", SubjectNameAR = "الديناميكا الحرارية", Period = 3 },
           new Subject { SubID = 4, SubjectNameEN = "Fluid Mechanics", SubjectNameAR = "ميكانيكا الموائع", Period = 3 },
           new Subject { SubID = 5, SubjectNameEN = "Engineering Drawing", SubjectNameAR = "الرسم الهندسي", Period = 2 },
           new Subject { SubID = 6, SubjectNameEN = "Statics", SubjectNameAR = "الاستاتيكا", Period = 3 },
           new Subject { SubID = 7, SubjectNameEN = "Dynamics", SubjectNameAR = "الديناميكا", Period = 3 },
           new Subject { SubID = 8, SubjectNameEN = "Materials Science", SubjectNameAR = "علم المواد", Period = 2 },
           new Subject { SubID = 9, SubjectNameEN = "Electrical Circuits", SubjectNameAR = "الدوائر الكهربية", Period = 3 },
           new Subject { SubID = 10, SubjectNameEN = "Computer Programming", SubjectNameAR = "برمجة الحاسب", Period = 3 },
           new Subject { SubID = 11, SubjectNameEN = "Engineering Ethics", SubjectNameAR = "أخلاقيات الهندسة", Period = 1 },
           new Subject { SubID = 12, SubjectNameEN = "Engineering Economy", SubjectNameAR = "الاقتصاد الهندسي", Period = 2 },
           new Subject { SubID = 13, SubjectNameEN = "Control Systems", SubjectNameAR = "نظم التحكم", Period = 3 },
           new Subject { SubID = 14, SubjectNameEN = "Microprocessors", SubjectNameAR = "المعالجات الدقيقة", Period = 3 },
           new Subject { SubID = 15, SubjectNameEN = "Digital Logic", SubjectNameAR = "المنطق الرقمي", Period = 3 },
           new Subject { SubID = 16, SubjectNameEN = "Structural Analysis", SubjectNameAR = "تحليل الإنشاءات", Period = 3 },
           new Subject { SubID = 17, SubjectNameEN = "Hydraulics", SubjectNameAR = "الهيدروليكا", Period = 3 },
           new Subject { SubID = 18, SubjectNameEN = "Machine Design", SubjectNameAR = "تصميم الماكينات", Period = 3 },
           new Subject { SubID = 19, SubjectNameEN = "Welding Technology", SubjectNameAR = "تكنولوجيا اللحام", Period = 2 },
           new Subject { SubID = 20, SubjectNameEN = "Environmental Engineering", SubjectNameAR = "الهندسة البيئية", Period = 2 }
               );
        }
    }
}
