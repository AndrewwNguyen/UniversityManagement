using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace UniversityManagement.Entities.Migrations
{
    /// <inheritdoc />
    public partial class DB01 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClassRoom",
                columns: table => new
                {
                    ClassRoomId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClassRoomName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassRoom", x => x.ClassRoomId);
                });

            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.DepartmentId);
                });

            migrationBuilder.CreateTable(
                name: "Teacher",
                columns: table => new
                {
                    TeacherId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeacherName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teacher", x => x.TeacherId);
                });

            migrationBuilder.CreateTable(
                name: "Class",
                columns: table => new
                {
                    ClassId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClassName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    YearOfAdmission = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Class", x => x.ClassId);
                    table.ForeignKey(
                        name: "FK_Class_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Department",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Subject",
                columns: table => new
                {
                    SubjectId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubjectName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TeacherId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subject", x => x.SubjectId);
                    table.ForeignKey(
                        name: "FK_Subject_Teacher_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teacher",
                        principalColumn: "TeacherId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    StudentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClassId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.StudentId);
                    table.ForeignKey(
                        name: "FK_Student_Class_ClassId",
                        column: x => x.ClassId,
                        principalTable: "Class",
                        principalColumn: "ClassId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Subject_Classroom",
                columns: table => new
                {
                    ClassRoomId = table.Column<int>(type: "int", nullable: false),
                    SubjectId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subject_Classroom", x => new { x.SubjectId, x.ClassRoomId });
                    table.ForeignKey(
                        name: "FK_Subject_Classroom_ClassRoom_ClassRoomId",
                        column: x => x.ClassRoomId,
                        principalTable: "ClassRoom",
                        principalColumn: "ClassRoomId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Subject_Classroom_Subject_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subject",
                        principalColumn: "SubjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Subject_Student",
                columns: table => new
                {
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    SubjectId = table.Column<int>(type: "int", nullable: false),
                    Mark = table.Column<float>(type: "real", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subject_Student", x => new { x.SubjectId, x.StudentId });
                    table.ForeignKey(
                        name: "FK_Subject_Student_Student_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Student",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Subject_Student_Subject_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subject",
                        principalColumn: "SubjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ClassRoom",
                columns: new[] { "ClassRoomId", "ClassRoomName", "Description" },
                values: new object[] { 1, "Room 303A7", "No" });

            migrationBuilder.InsertData(
                table: "Department",
                columns: new[] { "DepartmentId", "DepartmentName", "Description" },
                values: new object[,]
                {
                    { 1, "Cong Nghe Thong Tin", "No" },
                    { 2, "Luat kinh Te", "No" },
                    { 3, "Quan Tri Kinh Doanh", "No" },
                    { 4, "Marketing", "No" },
                    { 5, "Co Khi", "No" }
                });

            migrationBuilder.InsertData(
                table: "Teacher",
                columns: new[] { "TeacherId", "Description", "TeacherName" },
                values: new object[,]
                {
                    { 1, "No", "Bui Ngoc Dung" },
                    { 2, "No", "Nguyen Kim Sao" },
                    { 3, "No", "Nguyen Thu Phuong" },
                    { 4, "No", "Thieu Tran Cuong" },
                    { 5, "No", "Dao Nhu Quynh" },
                    { 6, "No", "Nguyen Gia Quy" }
                });

            migrationBuilder.InsertData(
                table: "Class",
                columns: new[] { "ClassId", "Amount", "ClassName", "DepartmentId", "Description", "YearOfAdmission" },
                values: new object[,]
                {
                    { 1, 75, "Cong nghe thong tin 1", 1, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 70, "Cong nghe thong tin 2", 1, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 46, "Marketing 2", 4, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, 49, "Co Khi", 5, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, 70, "Cong nghe thong tin 3", 1, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, 60, "Quan Tri Kinh Doanh 1", 3, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, 72, "Luat Kinh Te 1", 2, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, 75, "Co Khi 2", 5, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Subject",
                columns: new[] { "SubjectId", "Description", "SubjectName", "TeacherId" },
                values: new object[,]
                {
                    { 1, "No", "Lap Trinh Web", 1 },
                    { 2, "No", "An Ninh Mang", 2 },
                    { 3, "No", "Tri Tue Nhan Tao", 1 },
                    { 4, "No", "Lich Su Dang", 3 },
                    { 5, "No", "Dai So Tuyen Tinh", 4 },
                    { 6, "No", "Co So Du Lieu", 5 },
                    { 7, "No", "Xu Ly Anh", 6 },
                    { 8, "No", "Khai Pha Du Lieu", 1 }
                });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Address", "ClassId", "DateOfBirth", "Description", "StudentName" },
                values: new object[,]
                {
                    { 2, "Bac Ninh", 1, new DateTime(2001, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "No", "Nguyen Duc Bao Son" },
                    { 3, "Ha Noi", 1, new DateTime(2001, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "No", "Nguyen Quang Trung" },
                    { 4, "Bac Giang", 3, new DateTime(2001, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "No", "Nguyen Manh Hiep" },
                    { 5, "Ha Noi", 4, new DateTime(2003, 12, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "No", "Vu Hoang Minh" },
                    { 6, "Hai Duong", 3, new DateTime(1999, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "No", "Doan Duy Anh" },
                    { 7, "Ha Noi", 2, new DateTime(2000, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "No", "Phan Tien Anh" },
                    { 8, "Ha Noi", 4, new DateTime(2000, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "No", "Ngo Ngoc Duc" },
                    { 9, "Nam Dinh", 5, new DateTime(1998, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "No", "Nguyen Thi Khanh" },
                    { 10, "Thai Binh", 3, new DateTime(2001, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "No", "Le Kien Truc" }
                });

            migrationBuilder.InsertData(
                table: "Subject_Student",
                columns: new[] { "StudentId", "SubjectId", "Description", "Mark", "Status" },
                values: new object[,]
                {
                    { 2, 1, null, null, 0 },
                    { 3, 1, null, null, 0 },
                    { 2, 2, null, null, 0 },
                    { 3, 2, null, null, 0 },
                    { 2, 4, null, 7f, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Class_DepartmentId",
                table: "Class",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Student_ClassId",
                table: "Student",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_Subject_TeacherId",
                table: "Subject",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_Subject_Classroom_ClassRoomId",
                table: "Subject_Classroom",
                column: "ClassRoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Subject_Student_StudentId",
                table: "Subject_Student",
                column: "StudentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Subject_Classroom");

            migrationBuilder.DropTable(
                name: "Subject_Student");

            migrationBuilder.DropTable(
                name: "ClassRoom");

            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropTable(
                name: "Subject");

            migrationBuilder.DropTable(
                name: "Class");

            migrationBuilder.DropTable(
                name: "Teacher");

            migrationBuilder.DropTable(
                name: "Department");
        }
    }
}
