using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SchoolProject.infraStructure.Migrations
{
    /// <inheritdoc />
    public partial class AddTables : Migration
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
                    SubjectNameEN = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    SubjectNameAR = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Period = table.Column<int>(type: "int", nullable: true)
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
                    DNameEN = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    DNameAR = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
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
                    NameEN = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    NameAR = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
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
                    StudSubID = table.Column<int>(type: "int", nullable: false),
                    grade = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
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

            migrationBuilder.InsertData(
                schema: "Stud",
                table: "students",
                columns: new[] { "StudID", "Address", "DepartmentID", "NameAR", "NameEN", "Phone" },
                values: new object[,]
                {
                    { 3, "Alexandria", null, "سارة كمال", "Sara Kamal", "01112345678" },
                    { 7, "Aswan", null, "يوسف صالح", "Yousef Saleh", "01111111111" },
                    { 13, "Qena", null, "أسامة إبراهيم", "Osama Ibrahim", "01577777777" },
                    { 17, "Damietta", null, "أحمد ياسين", "Ahmed Yassin", "01123232323" },
                    { 22, "Matruh", null, "عمر رضا", "Omar Reda", "01578787878" },
                    { 26, "Sharqia", null, "باسل عماد", "Bassel Emad", "01522233444" },
                    { 30, "South Sinai", null, "أدهم فادي", "Adham Fady", "01566677888" }
                });

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
                    { 9, "دمياط", 5, "طارق حمدي", "Tarek Hamdy", null, "معيد", 7800m, null }
                });

            migrationBuilder.InsertData(
                schema: "Stud",
                table: "students",
                columns: new[] { "StudID", "Address", "DepartmentID", "NameAR", "NameEN", "Phone" },
                values: new object[,]
                {
                    { 1, "New York", 1, "جون سميث", "John Smith", "1234567890" },
                    { 2, "Cairo", 2, "علي أحمد", "Ali Ahmed", "9876543210" },
                    { 4, "Giza", 1, "فاطمة عادل", "Fatma Adel", "01234567890" },
                    { 5, "Tanta", 3, "محمد طارق", "Mohamed Tarek", "01098765432" },
                    { 6, "Mansoura", 2, "نور حسن", "Nour Hassan", "01555555555" },
                    { 8, "Ismailia", 1, "ليلى مصطفى", "Laila Mostafa", "01222222222" },
                    { 9, "Zagazig", 2, "هاني عمر", "Hani Omar", "01033333333" },
                    { 10, "Luxor", 3, "منى إيهاب", "Mona Ehab", "01044444444" },
                    { 11, "Fayoum", 2, "كريم نبيل", "Kareem Nabil", "01255555555" },
                    { 12, "Minya", 1, "أميرة سمير", "Amira Samir", "01166666666" },
                    { 14, "Damanhur", 3, "نادين شريف", "Nadine Sherif", "01088888888" },
                    { 15, "Suez", 2, "حسام علي", "Hossam Ali", "01299999999" },
                    { 16, "Beni Suef", 1, "رنا فتحي", "Rana Fathy", "01012121212" },
                    { 18, "El Mahalla", 2, "تامر عصام", "Tamer Essam", "01534343434" },
                    { 19, "Kafr El-Sheikh", 3, "شيماء فاروق", "Shaimaa Farouk", "01045454545" },
                    { 20, "Port Said", 1, "زياد عادل", "Ziad Adel", "01256565656" },
                    { 21, "Sohag", 2, "ندى إبراهيم", "Nada Ibrahim", "01167676767" },
                    { 23, "Beheira", 3, "آية مصطفى", "Aya Mostafa", "01089898989" },
                    { 24, "Gharbia", 1, "محمود خالد", "Mahmoud Khaled", "01290909090" },
                    { 25, "Qalyubia", 2, "ريم يونس", "Reem Younis", "01111122333" },
                    { 27, "Red Sea", 3, "فرح حاتم", "Farah Hatem", "01033344555" },
                    { 28, "New Valley", 1, "مصطفى عمرو", "Mostafa Amr", "01244455666" },
                    { 29, "North Sinai", 2, "جنى حسام", "Jana Hossam", "01155566777" }
                });

            migrationBuilder.InsertData(
                table: "Instructor",
                columns: new[] { "InsId", "Address", "DepartmentID", "ENameAr", "ENameEn", "Image", "Position", "Salary", "SupervisorId" },
                values: new object[,]
                {
                    { 4, "المنصورة", 4, "فاطمة محمد", "Fatma Mohamed", null, "أستاذ مساعد", 9500m, 3 },
                    { 6, "أسيوط", 3, "نهى محمود", "Noha Mahmoud", null, "دكتور", 10000m, 5 },
                    { 8, "بورسعيد", 2, "إيمان السيد", "Eman ElSayed", null, "مدرس مساعد", 9000m, 7 },
                    { 10, "الفيوم", 3, "هالة عبد الفتاح", "Hala AbdelFattah", null, "مدرس", 8600m, 9 }
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
