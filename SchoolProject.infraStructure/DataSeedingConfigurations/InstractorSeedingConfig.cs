using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolProject.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.infraStructure.DataSeedingConfigurations
{
    public class InstractorSeedingConfig() : IEntityTypeConfiguration<Instructor>
    {
        public void Configure(EntityTypeBuilder<Instructor> builder)
        {
            builder.HasData(
      new Instructor { InsId = 1, ENameAr = "أحمد علي", ENameEn = "Ahmed Ali", Address = "القاهرة", Position = "أستاذ", Salary = 12000, DepartmentID = 9 },
           new Instructor { InsId = 2, ENameAr = "منى حسن", ENameEn = "Mona Hassan", Address = "الإسكندرية", Position = "معيد", Salary = 8000, DepartmentID = 1, SupervisorId = 2 },
           new Instructor { InsId = 3, ENameAr = "سعيد عبد الله", ENameEn = "Saeed Abdullah", Address = "طنطا", Position = "دكتور", Salary = 11000, DepartmentID = 10 },
           new Instructor { InsId = 4, ENameAr = "فاطمة محمد", ENameEn = "Fatma Mohamed", Address = "المنصورة", Position = "أستاذ مساعد", Salary = 9500, DepartmentID = 4, SupervisorId = 3 },
           new Instructor { InsId = 5, ENameAr = "علي إبراهيم", ENameEn = "Ali Ibrahim", Address = "الجيزة", Position = "معيد", Salary = 7500, DepartmentID = 7 },
           new Instructor { InsId = 6, ENameAr = "نهى محمود", ENameEn = "Noha Mahmoud", Address = "أسيوط", Position = "دكتور", Salary = 10000, DepartmentID = 3, SupervisorId = 5 },
           new Instructor { InsId = 7, ENameAr = "مصطفى عبد الرحمن", ENameEn = "Mostafa Abdelrahman", Address = "سوهاج", Position = "أستاذ", Salary = 13000, DepartmentID = 1 },
           new Instructor { InsId = 8, ENameAr = "إيمان السيد", ENameEn = "Eman ElSayed", Address = "بورسعيد", Position = "مدرس مساعد", Salary = 9000, DepartmentID = 2, SupervisorId = 7 },
           new Instructor { InsId = 9, ENameAr = "طارق حمدي", ENameEn = "Tarek Hamdy", Address = "دمياط", Position = "معيد", Salary = 7800, DepartmentID = 5 },
           new Instructor { InsId = 10, ENameAr = "هالة عبد الفتاح", ENameEn = "Hala AbdelFattah", Address = "الفيوم", Position = "مدرس", Salary = 8600, DepartmentID = 3, SupervisorId = 9}
            );
        }
    }
}
