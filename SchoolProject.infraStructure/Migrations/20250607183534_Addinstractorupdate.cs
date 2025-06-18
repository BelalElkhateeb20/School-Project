using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolProject.infraStructure.Migrations
{
    /// <inheritdoc />
    public partial class Addinstractorupdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "instructors",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "instructors");
        }
    }
}
