using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SchoolProject.infraStructure.Migrations
{
    /// <inheritdoc />
    public partial class AddInstractorSeedingData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Period",
                schema: "Sub",
                table: "subjects",
                type: "int",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Instructor",
                columns: new[] { "InsId", "Address", "DepartmentID", "ENameAr", "ENameEn", "Image", "Position", "Salary", "SupervisorId" },
                values: new object[,]
                {
                    { 1, "القاهرة", 9, "أحمد علي", "Ahmed Ali", null, "أستاذ", 12000m, null },
                    { 2, "الإسكندرية", 1, "منى حسن", "Mona Hassan", null, "معيد", 8000m, 2 },
                    { 3, "طنطا", 10, "سعيد عبد الله", "Saeed Abdullah", null, "دكتور", 11000m, null },
                    { 5, "الجيزة", 7, "علي إبراهيم", "Ali Ibrahim", null, "معيد", 7500m, null },
                    { 7, "سوهاج", 1, "مصطفى عبد الرحمن", "Mostafa Abdelrahman", null, "أستاذ", 13000m, null },
                    { 9, "دمياط", 5, "طارق حمدي", "Tarek Hamdy", null, "معيد", 7800m, null },
                    { 4, "المنصورة", 4, "فاطمة محمد", "Fatma Mohamed", null, "أستاذ مساعد", 9500m, 3 },
                    { 6, "أسيوط", 3, "نهى محمود", "Noha Mahmoud", null, "دكتور", 10000m, 5 },
                    { 8, "بورسعيد", 2, "إيمان السيد", "Eman ElSayed", null, "مدرس مساعد", 9000m, 7 },
                    { 10, "الفيوم", 3, "هالة عبد الفتاح", "Hala AbdelFattah", null, "مدرس", 8600m, 9 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Instructor",
                keyColumn: "InsId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Instructor",
                keyColumn: "InsId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Instructor",
                keyColumn: "InsId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Instructor",
                keyColumn: "InsId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Instructor",
                keyColumn: "InsId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Instructor",
                keyColumn: "InsId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Instructor",
                keyColumn: "InsId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Instructor",
                keyColumn: "InsId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Instructor",
                keyColumn: "InsId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Instructor",
                keyColumn: "InsId",
                keyValue: 9);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Period",
                schema: "Sub",
                table: "subjects",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
