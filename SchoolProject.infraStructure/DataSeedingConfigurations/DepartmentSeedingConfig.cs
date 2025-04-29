using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolProject.Data.Entities;


namespace SchoolProject.infraStructure.Configurations
{
    public class DepartmentSeedingConfig : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.HasData(
            new Department { DID = 1, DNameEN = "Engineering", DNameAR = "الهندسة" },
            new Department { DID = 2, DNameEN = "Medicine", DNameAR = "الطب" },
            new Department { DID = 3, DNameEN = "Commerce", DNameAR = "التجارة" },
            new Department { DID = 4, DNameEN = "Law", DNameAR = "الحقوق" },
            new Department { DID = 5, DNameEN = "Pharmacy", DNameAR = "الصيدلة" },
            new Department { DID = 6, DNameEN = "Dentistry", DNameAR = "طب الأسنان" },
            new Department { DID = 7, DNameEN = "Computer Science", DNameAR = "علوم الحاسب" },
            new Department { DID = 8, DNameEN = "Arts", DNameAR = "الآداب" },
            new Department { DID = 9, DNameEN = "Agriculture", DNameAR = "الزراعة" },
            new Department { DID = 10, DNameEN = "Education", DNameAR = "التربية" },
            new Department { DID = 11, DNameEN = "Nursing", DNameAR = "التمريض" },
            new Department { DID = 12, DNameEN = "Science", DNameAR = "العلوم" },
            new Department { DID = 13, DNameEN = "Veterinary Medicine", DNameAR = "الطب البيطري" },
            new Department { DID = 14, DNameEN = "Physical Education", DNameAR = "التربية الرياضية" },
            new Department { DID = 15, DNameEN = "Tourism and Hotels", DNameAR = "السياحة والفنادق" }
        );
        }
    }
}
