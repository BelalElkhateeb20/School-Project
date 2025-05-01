using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SchoolProject.infraStructure.Migrations
{
    /// <inheritdoc />
    public partial class AddSubjectSeedingData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "Sub",
                table: "subjects",
                columns: new[] { "SubID", "Period", "SubjectNameAR", "SubjectNameEN" },
                values: new object[,]
                {
                    { 1, 3, "رياضيات هندسية", "Engineering Mathematics" },
                    { 2, 3, "فيزياء للمهندسين", "Physics for Engineers" },
                    { 3, 3, "الديناميكا الحرارية", "Thermodynamics" },
                    { 4, 3, "ميكانيكا الموائع", "Fluid Mechanics" },
                    { 5, 2, "الرسم الهندسي", "Engineering Drawing" },
                    { 6, 3, "الاستاتيكا", "Statics" },
                    { 7, 3, "الديناميكا", "Dynamics" },
                    { 8, 2, "علم المواد", "Materials Science" },
                    { 9, 3, "الدوائر الكهربية", "Electrical Circuits" },
                    { 10, 3, "برمجة الحاسب", "Computer Programming" },
                    { 11, 1, "أخلاقيات الهندسة", "Engineering Ethics" },
                    { 12, 2, "الاقتصاد الهندسي", "Engineering Economy" },
                    { 13, 3, "نظم التحكم", "Control Systems" },
                    { 14, 3, "المعالجات الدقيقة", "Microprocessors" },
                    { 15, 3, "المنطق الرقمي", "Digital Logic" },
                    { 16, 3, "تحليل الإنشاءات", "Structural Analysis" },
                    { 17, 3, "الهيدروليكا", "Hydraulics" },
                    { 18, 3, "تصميم الماكينات", "Machine Design" },
                    { 19, 2, "تكنولوجيا اللحام", "Welding Technology" },
                    { 20, 2, "الهندسة البيئية", "Environmental Engineering" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Sub",
                table: "subjects",
                keyColumn: "SubID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "Sub",
                table: "subjects",
                keyColumn: "SubID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "Sub",
                table: "subjects",
                keyColumn: "SubID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "Sub",
                table: "subjects",
                keyColumn: "SubID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                schema: "Sub",
                table: "subjects",
                keyColumn: "SubID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                schema: "Sub",
                table: "subjects",
                keyColumn: "SubID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                schema: "Sub",
                table: "subjects",
                keyColumn: "SubID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                schema: "Sub",
                table: "subjects",
                keyColumn: "SubID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                schema: "Sub",
                table: "subjects",
                keyColumn: "SubID",
                keyValue: 9);

            migrationBuilder.DeleteData(
                schema: "Sub",
                table: "subjects",
                keyColumn: "SubID",
                keyValue: 10);

            migrationBuilder.DeleteData(
                schema: "Sub",
                table: "subjects",
                keyColumn: "SubID",
                keyValue: 11);

            migrationBuilder.DeleteData(
                schema: "Sub",
                table: "subjects",
                keyColumn: "SubID",
                keyValue: 12);

            migrationBuilder.DeleteData(
                schema: "Sub",
                table: "subjects",
                keyColumn: "SubID",
                keyValue: 13);

            migrationBuilder.DeleteData(
                schema: "Sub",
                table: "subjects",
                keyColumn: "SubID",
                keyValue: 14);

            migrationBuilder.DeleteData(
                schema: "Sub",
                table: "subjects",
                keyColumn: "SubID",
                keyValue: 15);

            migrationBuilder.DeleteData(
                schema: "Sub",
                table: "subjects",
                keyColumn: "SubID",
                keyValue: 16);

            migrationBuilder.DeleteData(
                schema: "Sub",
                table: "subjects",
                keyColumn: "SubID",
                keyValue: 17);

            migrationBuilder.DeleteData(
                schema: "Sub",
                table: "subjects",
                keyColumn: "SubID",
                keyValue: 18);

            migrationBuilder.DeleteData(
                schema: "Sub",
                table: "subjects",
                keyColumn: "SubID",
                keyValue: 19);

            migrationBuilder.DeleteData(
                schema: "Sub",
                table: "subjects",
                keyColumn: "SubID",
                keyValue: 20);
        }
    }
}
