using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SchoolProject.infraStructure.Migrations
{
    /// <inheritdoc />
    public partial class AddStudentTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "Stud",
                table: "students",
                columns: new[] { "StudID", "Address", "DepartmentID", "NameAR", "NameEN", "Phone" },
                values: new object[,]
                {
                    { 1, "New York", 1, "جون سميث", "John Smith", "1234567890" },
                    { 2, "Cairo", 2, "علي أحمد", "Ali Ahmed", "9876543210" },
                    { 3, "Alexandria", null, "سارة كمال", "Sara Kamal", "01112345678" },
                    { 4, "Giza", 1, "فاطمة عادل", "Fatma Adel", "01234567890" },
                    { 5, "Tanta", 3, "محمد طارق", "Mohamed Tarek", "01098765432" },
                    { 6, "Mansoura", 2, "نور حسن", "Nour Hassan", "01555555555" },
                    { 7, "Aswan", null, "يوسف صالح", "Yousef Saleh", "01111111111" },
                    { 8, "Ismailia", 1, "ليلى مصطفى", "Laila Mostafa", "01222222222" },
                    { 9, "Zagazig", 2, "هاني عمر", "Hani Omar", "01033333333" },
                    { 10, "Luxor", 3, "منى إيهاب", "Mona Ehab", "01044444444" },
                    { 11, "Fayoum", 2, "كريم نبيل", "Kareem Nabil", "01255555555" },
                    { 12, "Minya", 1, "أميرة سمير", "Amira Samir", "01166666666" },
                    { 13, "Qena", null, "أسامة إبراهيم", "Osama Ibrahim", "01577777777" },
                    { 14, "Damanhur", 3, "نادين شريف", "Nadine Sherif", "01088888888" },
                    { 15, "Suez", 2, "حسام علي", "Hossam Ali", "01299999999" },
                    { 16, "Beni Suef", 1, "رنا فتحي", "Rana Fathy", "01012121212" },
                    { 17, "Damietta", null, "أحمد ياسين", "Ahmed Yassin", "01123232323" },
                    { 18, "El Mahalla", 2, "تامر عصام", "Tamer Essam", "01534343434" },
                    { 19, "Kafr El-Sheikh", 3, "شيماء فاروق", "Shaimaa Farouk", "01045454545" },
                    { 20, "Port Said", 1, "زياد عادل", "Ziad Adel", "01256565656" },
                    { 21, "Sohag", 2, "ندى إبراهيم", "Nada Ibrahim", "01167676767" },
                    { 22, "Matruh", null, "عمر رضا", "Omar Reda", "01578787878" },
                    { 23, "Beheira", 3, "آية مصطفى", "Aya Mostafa", "01089898989" },
                    { 24, "Gharbia", 1, "محمود خالد", "Mahmoud Khaled", "01290909090" },
                    { 25, "Qalyubia", 2, "ريم يونس", "Reem Younis", "01111122333" },
                    { 26, "Sharqia", null, "باسل عماد", "Bassel Emad", "01522233444" },
                    { 27, "Red Sea", 3, "فرح حاتم", "Farah Hatem", "01033344555" },
                    { 28, "New Valley", 1, "مصطفى عمرو", "Mostafa Amr", "01244455666" },
                    { 29, "North Sinai", 2, "جنى حسام", "Jana Hossam", "01155566777" },
                    { 30, "South Sinai", null, "أدهم فادي", "Adham Fady", "01566677888" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Stud",
                table: "students",
                keyColumn: "StudID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "Stud",
                table: "students",
                keyColumn: "StudID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "Stud",
                table: "students",
                keyColumn: "StudID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "Stud",
                table: "students",
                keyColumn: "StudID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                schema: "Stud",
                table: "students",
                keyColumn: "StudID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                schema: "Stud",
                table: "students",
                keyColumn: "StudID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                schema: "Stud",
                table: "students",
                keyColumn: "StudID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                schema: "Stud",
                table: "students",
                keyColumn: "StudID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                schema: "Stud",
                table: "students",
                keyColumn: "StudID",
                keyValue: 9);

            migrationBuilder.DeleteData(
                schema: "Stud",
                table: "students",
                keyColumn: "StudID",
                keyValue: 10);

            migrationBuilder.DeleteData(
                schema: "Stud",
                table: "students",
                keyColumn: "StudID",
                keyValue: 11);

            migrationBuilder.DeleteData(
                schema: "Stud",
                table: "students",
                keyColumn: "StudID",
                keyValue: 12);

            migrationBuilder.DeleteData(
                schema: "Stud",
                table: "students",
                keyColumn: "StudID",
                keyValue: 13);

            migrationBuilder.DeleteData(
                schema: "Stud",
                table: "students",
                keyColumn: "StudID",
                keyValue: 14);

            migrationBuilder.DeleteData(
                schema: "Stud",
                table: "students",
                keyColumn: "StudID",
                keyValue: 15);

            migrationBuilder.DeleteData(
                schema: "Stud",
                table: "students",
                keyColumn: "StudID",
                keyValue: 16);

            migrationBuilder.DeleteData(
                schema: "Stud",
                table: "students",
                keyColumn: "StudID",
                keyValue: 17);

            migrationBuilder.DeleteData(
                schema: "Stud",
                table: "students",
                keyColumn: "StudID",
                keyValue: 18);

            migrationBuilder.DeleteData(
                schema: "Stud",
                table: "students",
                keyColumn: "StudID",
                keyValue: 19);

            migrationBuilder.DeleteData(
                schema: "Stud",
                table: "students",
                keyColumn: "StudID",
                keyValue: 20);

            migrationBuilder.DeleteData(
                schema: "Stud",
                table: "students",
                keyColumn: "StudID",
                keyValue: 21);

            migrationBuilder.DeleteData(
                schema: "Stud",
                table: "students",
                keyColumn: "StudID",
                keyValue: 22);

            migrationBuilder.DeleteData(
                schema: "Stud",
                table: "students",
                keyColumn: "StudID",
                keyValue: 23);

            migrationBuilder.DeleteData(
                schema: "Stud",
                table: "students",
                keyColumn: "StudID",
                keyValue: 24);

            migrationBuilder.DeleteData(
                schema: "Stud",
                table: "students",
                keyColumn: "StudID",
                keyValue: 25);

            migrationBuilder.DeleteData(
                schema: "Stud",
                table: "students",
                keyColumn: "StudID",
                keyValue: 26);

            migrationBuilder.DeleteData(
                schema: "Stud",
                table: "students",
                keyColumn: "StudID",
                keyValue: 27);

            migrationBuilder.DeleteData(
                schema: "Stud",
                table: "students",
                keyColumn: "StudID",
                keyValue: 28);

            migrationBuilder.DeleteData(
                schema: "Stud",
                table: "students",
                keyColumn: "StudID",
                keyValue: 29);

            migrationBuilder.DeleteData(
                schema: "Stud",
                table: "students",
                keyColumn: "StudID",
                keyValue: 30);
        }
    }
}
