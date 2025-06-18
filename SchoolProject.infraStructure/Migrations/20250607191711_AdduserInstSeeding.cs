using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SchoolProject.infraStructure.Migrations
{
    /// <inheritdoc />
    public partial class AdduserInstSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "Code", "ConcurrencyStamp", "Country", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Supervisor", "TwoFactorEnabled", "UserName", "UserType" },
                values: new object[,]
                {
                    { 21, 0, "القاهرة", "Code1001", "CON_STAMP_INST1", "Egypt", "ahmed.ali@example.com", false, "Ahmed Ali", false, null, "AHMED.ALI@EXAMPLE.COM", "AHMED.ALI", "AQAAAAEAACcQAAAAEPvR3R5T8J7f8K9L0M1N2O3P4Q5R6S7T8U9V0W1X2Y3Z4A5B6C7D8E9F0G1H2I3J4K5L6M7N8O9P==", null, false, "SEC_STAMP_INST1", true, false, "ahmed.ali", 2 },
                    { 22, 0, "الإسكندرية", "Code1002", "CON_STAMP_INST2", "Egypt", "mona.hassan@example.com", false, "Mona Hassan", false, null, "MONA.HASSAN@EXAMPLE.COM", "MONA.HASSAN", "AQAAAAEAACcQAAAAEN0B4C5D6E7F8G9H0I1J2K3L4M5N6O7P8Q9R0S1T2U3V4W5X6Y7Z8A9B0C1D2E3F4G5H6I7J8K9L==", null, false, "SEC_STAMP_INST2", false, false, "mona.hassan", 2 },
                    { 23, 0, "طنطا", "Code1003", "CON_STAMP_INST3", "Egypt", "saeed.abdullah@example.com", false, "Saeed Abdullah", false, null, "SAEED.ABDULLAH@EXAMPLE.COM", "SAEED.ABDULLAH", "AQAAAAEAACcQAAAAEM1N2O3P4Q5R6S7T8U9V0W1X2Y3Z4A5B6C7D8E9F0G1H2I3J4K5L6M7N8O9P0Q1R2S3T4U5V6W==", null, false, "SEC_STAMP_INST3", false, false, "saeed.abdullah", 2 },
                    { 24, 0, "المنصورة", "Code1004", "CON_STAMP_INST4", "Egypt", "fatma.mohamed@example.com", true, "Fatma Mohamed", false, null, "FATMA.MOHAMED@EXAMPLE.COM", "FATMA.MOHAMED", "AQAAAAEAACcQAAAAEN4E5F6G7H8I9J0K1L2M3N4O5P6Q7R8S9T0U1V2W3X4Y5Z6A7B8C9D0E1F2G3H4I5J6K7L8M9N==", null, false, "SEC_STAMP_INST4", false, false, "fatma.mohamed", 2 },
                    { 25, 0, "الجيزة", "Code1005", "CON_STAMP_INST5", "Egypt", "ali.ibrahim@example.com", true, "Ali Ibrahim", false, null, "ALI.IBRAHIM@EXAMPLE.COM", "ALI.IBRAHIM", "AQAAAAEAACcQAAAAEN5F6G7H8I9J0K1L2M3N4O5P6Q7R8S9T0U1V2W3X4Y5Z6A7B8C9D0E1F2G3H4I5J6K7L8M9N0O==", null, false, "SEC_STAMP_INST5", true, false, "ali.ibrahim", 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 25);
        }
    }
}
