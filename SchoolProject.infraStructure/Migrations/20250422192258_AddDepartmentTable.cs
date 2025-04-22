using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SchoolProject.infraStructure.Migrations
{
    /// <inheritdoc />
    public partial class AddDepartmentTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "Dep",
                table: "departments",
                columns: new[] { "DID", "DNameAR", "DNameEN" },
                values: new object[,]
                {
                    { 1, "الهندسة", "Engineering" },
                    { 2, "الطب", "Medicine" },
                    { 3, "التجارة", "Commerce" },
                    { 4, "الحقوق", "Law" },
                    { 5, "الصيدلة", "Pharmacy" },
                    { 6, "طب الأسنان", "Dentistry" },
                    { 7, "علوم الحاسب", "Computer Science" },
                    { 8, "الآداب", "Arts" },
                    { 9, "الزراعة", "Agriculture" },
                    { 10, "التربية", "Education" },
                    { 11, "التمريض", "Nursing" },
                    { 12, "العلوم", "Science" },
                    { 13, "الطب البيطري", "Veterinary Medicine" },
                    { 14, "التربية الرياضية", "Physical Education" },
                    { 15, "السياحة والفنادق", "Tourism and Hotels" }
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
