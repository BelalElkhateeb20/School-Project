using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SchoolProject.infraStructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedingDepartmentData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "Dep",
                table: "departments",
                columns: new[] { "DID", "DNameAR", "DNameEN", "InsManager" },
                values: new object[,]
                {
                    { 1, "الهندسة", "Engineering", null },
                    { 2, "الطب", "Medicine", null },
                    { 3, "التجارة", "Commerce", null },
                    { 4, "الحقوق", "Law", null },
                    { 5, "الصيدلة", "Pharmacy", null },
                    { 6, "طب الأسنان", "Dentistry", null },
                    { 7, "علوم الحاسب", "Computer Science", null },
                    { 8, "الآداب", "Arts", null },
                    { 9, "الزراعة", "Agriculture", null },
                    { 10, "التربية", "Education", null },
                    { 11, "التمريض", "Nursing", null },
                    { 12, "العلوم", "Science", null },
                    { 13, "الطب البيطري", "Veterinary Medicine", null },
                    { 14, "التربية الرياضية", "Physical Education", null },
                    { 15, "السياحة والفنادق", "Tourism and Hotels", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Dep",
                table: "departments",
                keyColumn: "DID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "Dep",
                table: "departments",
                keyColumn: "DID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "Dep",
                table: "departments",
                keyColumn: "DID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "Dep",
                table: "departments",
                keyColumn: "DID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                schema: "Dep",
                table: "departments",
                keyColumn: "DID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                schema: "Dep",
                table: "departments",
                keyColumn: "DID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                schema: "Dep",
                table: "departments",
                keyColumn: "DID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                schema: "Dep",
                table: "departments",
                keyColumn: "DID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                schema: "Dep",
                table: "departments",
                keyColumn: "DID",
                keyValue: 9);

            migrationBuilder.DeleteData(
                schema: "Dep",
                table: "departments",
                keyColumn: "DID",
                keyValue: 10);

            migrationBuilder.DeleteData(
                schema: "Dep",
                table: "departments",
                keyColumn: "DID",
                keyValue: 11);

            migrationBuilder.DeleteData(
                schema: "Dep",
                table: "departments",
                keyColumn: "DID",
                keyValue: 12);

            migrationBuilder.DeleteData(
                schema: "Dep",
                table: "departments",
                keyColumn: "DID",
                keyValue: 13);

            migrationBuilder.DeleteData(
                schema: "Dep",
                table: "departments",
                keyColumn: "DID",
                keyValue: 14);

            migrationBuilder.DeleteData(
                schema: "Dep",
                table: "departments",
                keyColumn: "DID",
                keyValue: 15);
        }
    }
}
