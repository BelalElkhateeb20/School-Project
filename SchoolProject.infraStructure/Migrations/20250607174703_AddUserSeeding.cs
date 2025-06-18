using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SchoolProject.infraStructure.Migrations
{
    /// <inheritdoc />
    public partial class AddUserSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "Code", "ConcurrencyStamp", "Country", "DepartmentID", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Supervisor", "TwoFactorEnabled", "UserName", "UserType" },
                values: new object[,]
                {
                    { 1, 0, "123 Main St", "Code1", "CON_STAMP_USER1", "Egypt", 5, "john.smith@example.com", false, "John Smith", false, null, "JOHN.SMITH@EXAMPLE.COM", "JOHN.SMITH", "b4Xi+yJjC7uAwW2h7JqHgEPvQNkyukUcCKQJVJV7Hcw=", null, false, "SEC_STAMP_USER1", false, false, "john.smith", 1 },
                    { 2, 0, "456 Oak Ave", "Code2", "CON_STAMP_USER2", "Egypt", 2, "ali.ahmed@example.com", false, "Ali Ahmed", false, null, "ALI.AHMED@EXAMPLE.COM", "ALI.AHMED", "j/L0kmTWDDI+z8EtdWsfqSJK24rZzsNXh7XcClqdNJY=", null, false, "SEC_STAMP_USER2", false, false, "ali.ahmed", 1 },
                    { 3, 0, "789 Pine Ln", "Code3", "CON_STAMP_USER3", "Egypt", 6, "sara.kamal@example.com", false, "Sara Kamal", false, null, "SARA.KAMAL@EXAMPLE.COM", "SARA.KAMAL", "mzHt/LwX97iHnoLsyO9nUosJ1I7F/54buWUqL0V646M=", null, false, "SEC_STAMP_USER3", false, false, "sara.kamal", 1 },
                    { 4, 0, "101 Elm St", "Code4", "CON_STAMP_USER4", "Egypt", 8, "fatma.adel@example.com", false, "Fatma Adel", false, null, "FATMA.ADEL@EXAMPLE.COM", "FATMA.ADEL", "Mw/DDLpeE+CgfHyyjy5O1lEsx5+UIx0NOw02ZqK2HjY=", null, false, "SEC_STAMP_USER4", false, false, "fatma.adel", 1 },
                    { 5, 0, "202 Birch Ct", "Code5", "CON_STAMP_USER5", "Egypt", 10, "mohamed.tarek@example.com", false, "Mohamed Tarek", false, null, "MOHAMED.TAREK@EXAMPLE.COM", "MOHAMED.TAREK", "fFvW7rprIKAbYotMRpBQuTG1ix/fX4pnRUjycbWed64=", null, false, "SEC_STAMP_USER5", false, false, "mohamed.tarek", 1 },
                    { 6, 0, "303 Cedar Dr", "Code6", "CON_STAMP_USER6", "Egypt", 7, "nour.hassan@example.com", false, "Nour Hassan", false, null, "NOUR.HASSAN@EXAMPLE.COM", "NOUR.HASSAN", "P3NdVltqV/V3I9VzH8CHVXlhXzMQ7UX+syFaXvQy2lU=", null, false, "SEC_STAMP_USER6", false, false, "nour.hassan", 1 },
                    { 7, 0, "404 Aspen Ave", "Code7", "CON_STAMP_USER7", "Egypt", 5, "yousef.saleh@example.com", false, "Yousef Saleh", false, null, "YOUSEF.SALEH@EXAMPLE.COM", "YOUSEF.SALEH", "G16gR2aMN5lQ7bw1f8bZccqevw3WYHPC0ns8Nf0q1m4=", null, false, "SEC_STAMP_USER7", false, false, "yousef.saleh", 1 },
                    { 8, 0, "505 Willow Rd", "Code8", "CON_STAMP_USER8", "Egypt", 1, "laila.mostafa@example.com", false, "Laila Mostafa", false, null, "LAILA.MOSTAFA@EXAMPLE.COM", "LAILA.MOSTAFA", "0aUJGH7GJspxFy3zkX4EhU6Aw/kBtNwO1HZ8+n8mtSo=", null, false, "SEC_STAMP_USER8", false, false, "laila.mostafa", 1 },
                    { 9, 0, "606 Poplar Ct", "Code9", "CON_STAMP_USER9", "Egypt", 6, "hani.omar@example.com", false, "Hani Omar", false, null, "HANI.OMAR@EXAMPLE.COM", "HANI.OMAR", "kv7glHpXBb7Z3rfqDWoZsWxSEfz/epw4//Fgh+dVuG0=", null, false, "SEC_STAMP_USER9", false, false, "hani.omar", 1 },
                    { 10, 0, "707 Sycamore Dr", "Code10", "CON_STAMP_USER10", "Egypt", 6, "mona.ehab@example.com", false, "Mona Ehab", false, null, "MONA.EHAB@EXAMPLE.COM", "MONA.EHAB", "KUXsYmNVlgJrC5kBqvLAC6v+jP1bp9H1lZZsGk3jxk0=", null, false, "SEC_STAMP_USER10", false, false, "mona.ehab", 1 },
                    { 11, 0, "808 Dogwood Ln", "Code11", "CON_STAMP_USER11", "Egypt", 9, "kareem.nabil@example.com", false, "Kareem Nabil", false, null, "KAREEM.NABIL@EXAMPLE.COM", "KAREEM.NABIL", "1HszA3+L5W9LLQ1gkUHXw+5QCE1NNh0lJ2pi9Or1pnU=", null, false, "SEC_STAMP_USER11", false, false, "kareem.nabil", 1 },
                    { 12, 0, "909 Holly Blvd", "Code12", "CON_STAMP_USER12", "Egypt", 10, "amira.samir@example.com", false, "Amira Samir", false, null, "AMIRA.SAMIR@EXAMPLE.COM", "AMIRA.SAMIR", "NEvp1D3TiCv8elXe3zJvyyNGOh6mCQ6DA7o9LrqZ5rs=", null, false, "SEC_STAMP_USER12", false, false, "amira.samir", 1 },
                    { 13, 0, "111 Acacia Cir", "Code13", "CON_STAMP_USER13", "Egypt", 2, "osama.ibrahim@example.com", false, "Osama Ibrahim", false, null, "OSAMA.IBRAHIM@EXAMPLE.COM", "OSAMA.IBRAHIM", "TklpDNqv9Y4VK+tUKcA6tdxL5Sh7LeZ9PtRmXHqrdNg=", null, false, "SEC_STAMP_USER13", false, false, "osama.ibrahim", 1 },
                    { 14, 0, "222 Banyan Pl", "Code14", "CON_STAMP_USER14", "Egypt", 2, "nadine.sherif@example.com", false, "Nadine Sherif", false, null, "NADINE.SHERIF@EXAMPLE.COM", "NADINE.SHERIF", "1Q7QfPPl+znQZuBx+pAfZx+rOC3y+UX1I/SoIQrLrKM=", null, false, "SEC_STAMP_USER14", false, false, "nadine.sherif", 1 },
                    { 15, 0, "333 Cypress Dr", "Code15", "CON_STAMP_USER15", "Egypt", 5, "hossam.ali@example.com", false, "Hossam Ali", false, null, "HOSSAM.ALI@EXAMPLE.COM", "HOSSAM.ALI", "5mpKYbOTqZckZKoXrrD9zrScV4gso4yd7hJQ4+rh3nM=", null, false, "SEC_STAMP_USER15", false, false, "hossam.ali", 1 },
                    { 16, 0, "444 Date Palm Ave", "Code16", "CON_STAMP_USER16", "Egypt", null, "rana.fathy@example.com", false, "Rana Fathy", false, null, "RANA.FATHY@EXAMPLE.COM", "RANA.FATHY", "6oJUK3OozE93tWHNgX++y0GLKzVb0xHqMlzkk+AmIkQ=", null, false, "SEC_STAMP_USER16", false, false, "rana.fathy", 1 },
                    { 17, 0, "555 Elderberry Way", "Code17", "CON_STAMP_USER17", "Egypt", null, "ahmed.yassin@example.com", false, "Ahmed Yassin", false, null, "AHMED.YASSIN@EXAMPLE.COM", "AHMED.YASSIN", "FGgFdeM7tGTfW6fEVxdNrgZP4a0Zcv0G82Y2xSThUXY=", null, false, "SEC_STAMP_USER17", false, false, "ahmed.yassin", 1 },
                    { 18, 0, "666 Fir Path", "Code18", "CON_STAMP_USER18", "Egypt", 8, "tamer.essam@example.com", false, "Tamer Essam", false, null, "TAMER.ESSAM@EXAMPLE.COM", "TAMER.ESSAM", "M5FVv+lT7yZ9v70tZEdpVmhWWNSQZlvR+KNHi0jC7RU=", null, false, "SEC_STAMP_USER18", false, false, "tamer.essam", 1 },
                    { 19, 0, "777 Ginko Glade", "Code19", "CON_STAMP_USER19", "Egypt", null, "shaimaa.farouk@example.com", false, "Shaimaa Farouk", false, null, "SHAIMAA.FAROUK@EXAMPLE.COM", "SHAIMAA.FAROUK", "BPK1VnFq7chUs3VnoxQdXyoGSrL0Wbe1e+VtrB+lOM4=", null, false, "SEC_STAMP_USER19", false, false, "shaimaa.farouk", 1 },
                    { 20, 0, "888 Hawthorn Hts", "Code20", "CON_STAMP_USER20", "Egypt", null, "ziad.adel@example.com", false, "Ziad Adel", false, null, "ZIAD.ADEL@EXAMPLE.COM", "ZIAD.ADEL", "AHxRnnEv2MxNNiQG54pFv+yB3bWyIuTLzO0LYUykCyM=", null, false, "SEC_STAMP_USER20", false, false, "ziad.adel", 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 20);
        }
    }
}
