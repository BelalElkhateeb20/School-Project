using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolProject.infraStructure.Migrations
{
    /// <inheritdoc />
    public partial class AddAllTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Dep");

            migrationBuilder.EnsureSchema(
                name: "DepSub");

            migrationBuilder.EnsureSchema(
                name: "Stud");

            migrationBuilder.EnsureSchema(
                name: "StuSub");

            migrationBuilder.EnsureSchema(
                name: "Sub");

            migrationBuilder.CreateTable(
                name: "departments",
                schema: "Dep",
                columns: table => new
                {
                    DID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_departments", x => x.DID);
                });

            migrationBuilder.CreateTable(
                name: "subjects",
                schema: "Sub",
                columns: table => new
                {
                    SubID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubjectName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Period = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_subjects", x => x.SubID);
                });

            migrationBuilder.CreateTable(
                name: "students",
                schema: "Stud",
                columns: table => new
                {
                    StudID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    DepartmentID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_students", x => x.StudID);
                    table.ForeignKey(
                        name: "FK_students_departments_DepartmentID",
                        column: x => x.DepartmentID,
                        principalSchema: "Dep",
                        principalTable: "departments",
                        principalColumn: "DID");
                });

            migrationBuilder.CreateTable(
                name: "departmentSubjects",
                schema: "DepSub",
                columns: table => new
                {
                    DeptSubID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentID = table.Column<int>(type: "int", nullable: false),
                    SubID = table.Column<int>(type: "int", nullable: false),
                    SubjectSubID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_departmentSubjects", x => x.DeptSubID);
                    table.ForeignKey(
                        name: "FK_departmentSubjects_departments_DepartmentID",
                        column: x => x.DepartmentID,
                        principalSchema: "Dep",
                        principalTable: "departments",
                        principalColumn: "DID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_departmentSubjects_subjects_SubjectSubID",
                        column: x => x.SubjectSubID,
                        principalSchema: "Sub",
                        principalTable: "subjects",
                        principalColumn: "SubID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "studentSubjects",
                schema: "StuSub",
                columns: table => new
                {
                    StudSubID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudID = table.Column<int>(type: "int", nullable: false),
                    SubID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_studentSubjects", x => x.StudSubID);
                    table.ForeignKey(
                        name: "FK_studentSubjects_students_StudID",
                        column: x => x.StudID,
                        principalSchema: "Stud",
                        principalTable: "students",
                        principalColumn: "StudID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_studentSubjects_subjects_SubID",
                        column: x => x.SubID,
                        principalSchema: "Sub",
                        principalTable: "subjects",
                        principalColumn: "SubID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_departmentSubjects_DepartmentID",
                schema: "DepSub",
                table: "departmentSubjects",
                column: "DepartmentID");

            migrationBuilder.CreateIndex(
                name: "IX_departmentSubjects_SubjectSubID",
                schema: "DepSub",
                table: "departmentSubjects",
                column: "SubjectSubID");

            migrationBuilder.CreateIndex(
                name: "IX_students_DepartmentID",
                schema: "Stud",
                table: "students",
                column: "DepartmentID");

            migrationBuilder.CreateIndex(
                name: "IX_studentSubjects_StudID",
                schema: "StuSub",
                table: "studentSubjects",
                column: "StudID");

            migrationBuilder.CreateIndex(
                name: "IX_studentSubjects_SubID",
                schema: "StuSub",
                table: "studentSubjects",
                column: "SubID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "departmentSubjects",
                schema: "DepSub");

            migrationBuilder.DropTable(
                name: "studentSubjects",
                schema: "StuSub");

            migrationBuilder.DropTable(
                name: "students",
                schema: "Stud");

            migrationBuilder.DropTable(
                name: "subjects",
                schema: "Sub");

            migrationBuilder.DropTable(
                name: "departments",
                schema: "Dep");
        }
    }
}
