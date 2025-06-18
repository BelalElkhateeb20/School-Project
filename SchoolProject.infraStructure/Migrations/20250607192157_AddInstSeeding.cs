using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SchoolProject.infraStructure.Migrations
{
    /// <inheritdoc />
    public partial class AddInstSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "instructors",
                columns: new[] { "InsId", "Address", "DepartmentID", "ENameAr", "ENameEn", "Email", "Image", "Position", "Salary", "SupervisorId", "UserId" },
                values: new object[,]
                {
                    { 1, "القاهرة", 9, "أحمد علي", "Ahmed Ali", "ahmed.ali@example.com", null, "أستاذ", 12000m, 1, 21 },
                    { 2, "الإسكندرية", 1, "منى حسن", "Mona Hassan", "mona.hassan@example.com", null, "معيد", 8000m, 2, 22 },
                    { 3, "طنطا", 10, "سعيد عبد الله", "Saeed Abdullah", "saeed.abdullah@example.com", null, "دكتور", 11000m, 3, 23 },
                    { 5, "الجيزة", 7, "علي إبراهيم", "Ali Ibrahim", "ali.ibrahim@example.com", null, "معيد", 7500m, null, 25 },
                    { 4, "المنصورة", 4, "فاطمة محمد", "Fatma Mohamed", "fatma.mohamed@example.com", null, "أستاذ مساعد", 9500m, 3, 24 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "instructors",
                keyColumn: "InsId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "instructors",
                keyColumn: "InsId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "instructors",
                keyColumn: "InsId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "instructors",
                keyColumn: "InsId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "instructors",
                keyColumn: "InsId",
                keyValue: 3);
        }
    }
}
