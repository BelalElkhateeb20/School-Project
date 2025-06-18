
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolProject.Data.Entities.Views;


namespace SchoolProject.Data.Configurations
{

    public class StudentSeedingConfig : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasData(
    new Student { StudID = 1, NameEN = "John Smith", NameAR = "جون سميث", Address = "New York", Phone = "1234567890", DepartmentID = 1, UserId = 1 },
    new Student { StudID = 2, NameEN = "Ali Ahmed", NameAR = "علي أحمد", Address = "Cairo", Phone = "9876543210", DepartmentID = 2, UserId = 2 },
    new Student { StudID = 3, NameEN = "Sara Kamal", NameAR = "سارة كمال", Address = "Alexandria", Phone = "01112345678", DepartmentID = null, UserId = 3 },
    new Student { StudID = 4, NameEN = "Fatma Adel", NameAR = "فاطمة عادل", Address = "Giza", Phone = "01234567890", DepartmentID = 1, UserId = 4 },
    new Student { StudID = 5, NameEN = "Mohamed Tarek", NameAR = "محمد طارق", Address = "Tanta", Phone = "01098765432", DepartmentID = 3, UserId = 5 },
    new Student { StudID = 6, NameEN = "Nour Hassan", NameAR = "نور حسن", Address = "Mansoura", Phone = "01555555555", DepartmentID = 2, UserId = 6 },
    new Student { StudID = 7, NameEN = "Yousef Saleh", NameAR = "يوسف صالح", Address = "Aswan", Phone = "01111111111", DepartmentID = null, UserId = 7 },
    new Student { StudID = 8, NameEN = "Laila Mostafa", NameAR = "ليلى مصطفى", Address = "Ismailia", Phone = "01222222222", DepartmentID = 1, UserId = 8 },
    new Student { StudID = 9, NameEN = "Hani Omar", NameAR = "هاني عمر", Address = "Zagazig", Phone = "01033333333", DepartmentID = 2, UserId = 9 },
    new Student { StudID = 10, NameEN = "Mona Ehab", NameAR = "منى إيهاب", Address = "Luxor", Phone = "01044444444", DepartmentID = 3, UserId = 10 },

    new Student { StudID = 11, NameEN = "Kareem Nabil", NameAR = "كريم نبيل", Address = "Fayoum", Phone = "01255555555", DepartmentID = 2, UserId = 11 },
    new Student { StudID = 12, NameEN = "Amira Samir", NameAR = "أميرة سمير", Address = "Minya", Phone = "01166666666", DepartmentID = 1, UserId = 12 },
    new Student { StudID = 13, NameEN = "Osama Ibrahim", NameAR = "أسامة إبراهيم", Address = "Qena", Phone = "01577777777", DepartmentID = null, UserId = 13 },
    new Student { StudID = 14, NameEN = "Nadine Sherif", NameAR = "نادين شريف", Address = "Damanhur", Phone = "01088888888", DepartmentID = 3, UserId = 14 },
    new Student { StudID = 15, NameEN = "Hossam Ali", NameAR = "حسام علي", Address = "Suez", Phone = "01299999999", DepartmentID = 2, UserId = 15 },
    new Student { StudID = 16, NameEN = "Rana Fathy", NameAR = "رنا فتحي", Address = "Beni Suef", Phone = "01012121212", DepartmentID = 1, UserId = 16 },
    new Student { StudID = 17, NameEN = "Ahmed Yassin", NameAR = "أحمد ياسين", Address = "Damietta", Phone = "01123232323", DepartmentID = null, UserId = 17 },
    new Student { StudID = 18, NameEN = "Tamer Essam", NameAR = "تامر عصام", Address = "El Mahalla", Phone = "01534343434", DepartmentID = 2, UserId = 18 },
    new Student { StudID = 19, NameEN = "Shaimaa Farouk", NameAR = "شيماء فاروق", Address = "Kafr El-Sheikh", Phone = "01045454545", DepartmentID = 3, UserId = 19 },
    new Student { StudID = 20, NameEN = "Ziad Adel", NameAR = "زياد عادل", Address = "Port Said", Phone = "01256565656", DepartmentID = 1, UserId = 20 }

);

        }
    }

}
