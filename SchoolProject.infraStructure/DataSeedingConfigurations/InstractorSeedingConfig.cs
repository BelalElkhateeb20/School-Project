using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolProject.Data.Entities.Views;

namespace SchoolProject.infraStructure.DataSeedingConfigurations
{
    public class InstractorSeedingConfig() : IEntityTypeConfiguration<Instructor>
    {
        public void Configure(EntityTypeBuilder<Instructor> builder)
        {
            builder.HasData(
      new Instructor { InsId = 1,UserId=21, ENameAr = "أحمد علي", ENameEn = "Ahmed Ali", Address = "القاهرة", Position = "أستاذ", Salary = 12000, DepartmentID = 9,SupervisorId=1, Email = "ahmed.ali@example.com"},
           new Instructor { InsId = 2,UserId=22,ENameAr = "منى حسن", ENameEn = "Mona Hassan", Address = "الإسكندرية", Position = "معيد", Salary = 8000, DepartmentID = 1, SupervisorId = 2, Email = "mona.hassan@example.com" },
           new Instructor { InsId = 3,UserId=23,ENameAr = "سعيد عبد الله", ENameEn = "Saeed Abdullah", Address = "طنطا", Position = "دكتور", Salary = 11000, DepartmentID = 10, Email = "saeed.abdullah@example.com",SupervisorId=3 },
           new Instructor { InsId = 4,UserId=24,ENameAr = "فاطمة محمد", ENameEn = "Fatma Mohamed", Address = "المنصورة", Position = "أستاذ مساعد", Salary = 9500, DepartmentID = 4, SupervisorId = 3, Email = "fatma.mohamed@example.com" },
           new Instructor { InsId = 5,UserId=25,ENameAr = "علي إبراهيم", ENameEn = "Ali Ibrahim", Address = "الجيزة", Position = "معيد", Salary = 7500, DepartmentID = 7, Email = "ali.ibrahim@example.com" ,SupervisorId =null}
            );
        }
    }
}
