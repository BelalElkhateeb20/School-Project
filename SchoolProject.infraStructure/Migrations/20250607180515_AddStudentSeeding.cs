using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SchoolProject.infraStructure.Migrations
{
    /// <inheritdoc />
    public partial class AddStudentSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "Stud",
                table: "students",
                columns: new[] { "StudID", "Address", "DepartmentID", "NameAR", "NameEN", "Phone", "UserId" },
                values: new object[,]
                {
                    { 1, "New York", 1, "جون سميث", "John Smith", "1234567890", 1 },
                    { 2, "Cairo", 2, "علي أحمد", "Ali Ahmed", "9876543210", 2 },
                    { 3, "Alexandria", null, "سارة كمال", "Sara Kamal", "01112345678", 3 },
                    { 4, "Giza", 1, "فاطمة عادل", "Fatma Adel", "01234567890", 4 },
                    { 5, "Tanta", 3, "محمد طارق", "Mohamed Tarek", "01098765432", 5 },
                    { 6, "Mansoura", 2, "نور حسن", "Nour Hassan", "01555555555", 6 },
                    { 7, "Aswan", null, "يوسف صالح", "Yousef Saleh", "01111111111", 7 },
                    { 8, "Ismailia", 1, "ليلى مصطفى", "Laila Mostafa", "01222222222", 8 },
                    { 9, "Zagazig", 2, "هاني عمر", "Hani Omar", "01033333333", 9 },
                    { 10, "Luxor", 3, "منى إيهاب", "Mona Ehab", "01044444444", 10 },
                    { 11, "Fayoum", 2, "كريم نبيل", "Kareem Nabil", "01255555555", 11 },
                    { 12, "Minya", 1, "أميرة سمير", "Amira Samir", "01166666666", 12 },
                    { 13, "Qena", null, "أسامة إبراهيم", "Osama Ibrahim", "01577777777", 13 },
                    { 14, "Damanhur", 3, "نادين شريف", "Nadine Sherif", "01088888888", 14 },
                    { 15, "Suez", 2, "حسام علي", "Hossam Ali", "01299999999", 15 },
                    { 16, "Beni Suef", 1, "رنا فتحي", "Rana Fathy", "01012121212", 16 },
                    { 17, "Damietta", null, "أحمد ياسين", "Ahmed Yassin", "01123232323", 17 },
                    { 18, "El Mahalla", 2, "تامر عصام", "Tamer Essam", "01534343434", 18 },
                    { 19, "Kafr El-Sheikh", 3, "شيماء فاروق", "Shaimaa Farouk", "01045454545", 19 },
                    { 20, "Port Said", 1, "زياد عادل", "Ziad Adel", "01256565656", 20 }
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
        }
    }
}
