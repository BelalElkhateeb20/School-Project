using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolProject.infraStructure.Migrations
{
    /// <inheritdoc />
    public partial class EntitiesLocalizaion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SubjectName",
                schema: "Sub",
                table: "subjects",
                newName: "SubjectNameEN");

            migrationBuilder.RenameColumn(
                name: "Name",
                schema: "Stud",
                table: "students",
                newName: "NameEN");

            migrationBuilder.RenameColumn(
                name: "DName",
                schema: "Dep",
                table: "departments",
                newName: "DNameEN");

            migrationBuilder.AddColumn<string>(
                name: "SubjectNameAR",
                schema: "Sub",
                table: "subjects",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NameAR",
                schema: "Stud",
                table: "students",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DNameAR",
                schema: "Dep",
                table: "departments",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SubjectNameAR",
                schema: "Sub",
                table: "subjects");

            migrationBuilder.DropColumn(
                name: "NameAR",
                schema: "Stud",
                table: "students");

            migrationBuilder.DropColumn(
                name: "DNameAR",
                schema: "Dep",
                table: "departments");

            migrationBuilder.RenameColumn(
                name: "SubjectNameEN",
                schema: "Sub",
                table: "subjects",
                newName: "SubjectName");

            migrationBuilder.RenameColumn(
                name: "NameEN",
                schema: "Stud",
                table: "students",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "DNameEN",
                schema: "Dep",
                table: "departments",
                newName: "DName");
        }
    }
}
