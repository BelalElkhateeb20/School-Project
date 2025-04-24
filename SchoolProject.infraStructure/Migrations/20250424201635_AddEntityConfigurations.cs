using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolProject.infraStructure.Migrations
{
    /// <inheritdoc />
    public partial class AddEntityConfigurations : Migration
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
                name: "subjects",
                schema: "Sub",
                columns: table => new
                {
                    SubID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubjectNameEN = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    SubjectNameAR = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Period = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_subjects", x => x.SubID);
                });

            migrationBuilder.CreateTable(
                name: "departments",
                schema: "Dep",
                columns: table => new
                {
                    DID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DNameEN = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    DNameAR = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    InsManager = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_departments", x => x.DID);
                });

            migrationBuilder.CreateTable(
                name: "departmentSubjects",
                schema: "DepSub",
                columns: table => new
                {
                    DepartmentID = table.Column<int>(type: "int", nullable: false),
                    SubID = table.Column<int>(type: "int", nullable: false),
                    SubjectSubID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_departmentSubjects", x => new { x.SubID, x.DepartmentID });
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
                        principalColumn: "SubID");
                });

            migrationBuilder.CreateTable(
                name: "Instructor",
                columns: table => new
                {
                    InsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ENameAr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ENameEn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SupervisorId = table.Column<int>(type: "int", nullable: true),
                    Salary = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DepartmentID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instructor", x => x.InsId);
                    table.ForeignKey(
                        name: "FK_Instructor_Instructor_SupervisorId",
                        column: x => x.SupervisorId,
                        principalTable: "Instructor",
                        principalColumn: "InsId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Instructor_departments_DepartmentID",
                        column: x => x.DepartmentID,
                        principalSchema: "Dep",
                        principalTable: "departments",
                        principalColumn: "DID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "students",
                schema: "Stud",
                columns: table => new
                {
                    StudID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameEN = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    NameAR = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
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
                name: "Ins_Subject",
                columns: table => new
                {
                    InsId = table.Column<int>(type: "int", nullable: false),
                    SubId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ins_Subject", x => new { x.SubId, x.InsId });
                    table.ForeignKey(
                        name: "FK_Ins_Subject_Instructor_InsId",
                        column: x => x.InsId,
                        principalTable: "Instructor",
                        principalColumn: "InsId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ins_Subject_subjects_SubId",
                        column: x => x.SubId,
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
                    StudID = table.Column<int>(type: "int", nullable: false),
                    SubID = table.Column<int>(type: "int", nullable: false),
                    StudSubID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_studentSubjects", x => new { x.SubID, x.StudID });
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
                name: "IX_departments_InsManager",
                schema: "Dep",
                table: "departments",
                column: "InsManager",
                unique: true,
                filter: "[InsManager] IS NOT NULL");

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
                name: "IX_Ins_Subject_InsId",
                table: "Ins_Subject",
                column: "InsId");

            migrationBuilder.CreateIndex(
                name: "IX_Instructor_DepartmentID",
                table: "Instructor",
                column: "DepartmentID");

            migrationBuilder.CreateIndex(
                name: "IX_Instructor_SupervisorId",
                table: "Instructor",
                column: "SupervisorId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_departments_Instructor_InsManager",
                schema: "Dep",
                table: "departments",
                column: "InsManager",
                principalTable: "Instructor",
                principalColumn: "InsId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_departments_Instructor_InsManager",
                schema: "Dep",
                table: "departments");

            migrationBuilder.DropTable(
                name: "departmentSubjects",
                schema: "DepSub");

            migrationBuilder.DropTable(
                name: "Ins_Subject");

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
                name: "Instructor");

            migrationBuilder.DropTable(
                name: "departments",
                schema: "Dep");
        }
    }
}
