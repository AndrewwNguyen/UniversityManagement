using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace UniversityManagement.Entities.Migrations
{
    /// <inheritdoc />
    public partial class AddUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClassRoom",
                columns: table => new
                {
                    ClassRoomId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClassRoomName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfCreation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateOfUpdate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassRoom", x => x.ClassRoomId);
                });

            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    DepartmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DepartmentName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfCreation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateOfUpdate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.DepartmentId);
                });

            migrationBuilder.CreateTable(
                name: "Teacher",
                columns: table => new
                {
                    TeacherId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TeacherName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfCreation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateOfUpdate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teacher", x => x.TeacherId);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfCreation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateOfUpdate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Class",
                columns: table => new
                {
                    ClassId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClassName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DepartmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    YearOfAdmission = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfCreation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateOfUpdate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true)
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
                    SubjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SubjectName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TeacherId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateOfCreation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateOfUpdate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true)
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
                    StudentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StudentName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClassId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfCreation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateOfUpdate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.StudentId);
                    table.ForeignKey(
                        name: "FK_Student_Class_ClassId",
                        column: x => x.ClassId,
                        principalTable: "Class",
                        principalColumn: "ClassId");
                });

            migrationBuilder.CreateTable(
                name: "Subject_Classroom",
                columns: table => new
                {
                    ClassRoomId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SubjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfCreation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateOfUpdate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true)
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
                    StudentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SubjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Mark = table.Column<float>(type: "real", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true),
                    DateOfCreation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateOfUpdate = table.Column<DateTime>(type: "datetime2", nullable: true)
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
                columns: new[] { "ClassRoomId", "ClassRoomName", "DateOfCreation", "DateOfUpdate", "Description", "Status" },
                values: new object[] { new Guid("34c65d1b-cc7a-4d94-8723-ab5cdcce98a7"), "Room 303A7", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "No", null });

            migrationBuilder.InsertData(
                table: "Department",
                columns: new[] { "DepartmentId", "DateOfCreation", "DateOfUpdate", "DepartmentName", "Description", "Status" },
                values: new object[,]
                {
                    { new Guid("3c1f9665-f8f7-42e2-8c38-4ef4f02b4bcf"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Luật Kinh Tế", "No", null },
                    { new Guid("9c6c42ef-7167-41ce-af61-46bd7a9d66da"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Cơ Khí", "No", null },
                    { new Guid("9d7f09aa-4d7c-4f13-b52e-050dd8e73967"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Marketing", "No", null },
                    { new Guid("b2e8e638-aaba-4a91-afb1-56dede21f2e2"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Công Nghệ Thông Tin", "No", null },
                    { new Guid("fce4b0c8-9005-4701-adca-bebd946b2252"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Quản Trị Kinh Doanh", "No", null }
                });

            migrationBuilder.InsertData(
                table: "Teacher",
                columns: new[] { "TeacherId", "DateOfCreation", "DateOfUpdate", "Description", "Status", "TeacherName" },
                values: new object[,]
                {
                    { new Guid("016de7a6-40a2-45c6-80f7-786810f00d27"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "No", null, "Thiều Trần Cường" },
                    { new Guid("0250e0e8-2ee9-43dc-8e13-7a0a0fda5e2a"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "No", null, "Nguyễn Kim Sao" },
                    { new Guid("2f043c43-cfd6-4948-9a9d-78ec32df6a9c"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "No", null, "Nguyễn Thu Phương" },
                    { new Guid("8fa7e6e3-2eab-479c-865a-033694979b04"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "No", null, "Nguyễn Gia Quý" },
                    { new Guid("b65a41d6-c25c-4867-8b7f-a3f52a57bc26"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "No", null, "Đào Như Quỳnh" },
                    { new Guid("d9a47258-d809-4fa1-b241-59ac8c01a50d"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "No", null, "Bùi Ngọc Dũng" }
                });

            migrationBuilder.InsertData(
                table: "Class",
                columns: new[] { "ClassId", "Amount", "ClassName", "DateOfCreation", "DateOfUpdate", "DepartmentId", "Description", "Status", "YearOfAdmission" },
                values: new object[,]
                {
                    { new Guid("00ed687d-de80-424c-a87c-b3f03a922724"), 70, "Công Nghệ Thông Tin 3", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("b2e8e638-aaba-4a91-afb1-56dede21f2e2"), null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("02a4a852-f9de-43b9-91bc-f52dad047562"), 72, "Luật Kinh Tế 1", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("b2e8e638-aaba-4a91-afb1-56dede21f2e2"), null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("1fc38461-29bb-4123-9af6-aec3945bb378"), 70, "Công Nghệ Thông Tin 2", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("9d7f09aa-4d7c-4f13-b52e-050dd8e73967"), null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("2215e3b8-44f2-439c-9c02-107a8fb769e2"), 60, "Quản Trị Kinh Doanh 1", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("3c1f9665-f8f7-42e2-8c38-4ef4f02b4bcf"), null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3fdddd8a-76c9-456e-bf35-5211f599016f"), 75, "Công Nghệ Thông Tin 1", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("9c6c42ef-7167-41ce-af61-46bd7a9d66da"), null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("5e1edcf4-7a25-491c-be13-0f30e69f9d41"), 75, "Cơ Khí 2", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("3c1f9665-f8f7-42e2-8c38-4ef4f02b4bcf"), null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("627ca7ba-82de-442e-80fc-a99b59f28286"), 49, "Cơ Khí 1", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("3c1f9665-f8f7-42e2-8c38-4ef4f02b4bcf"), null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("b41f3593-f66b-4b24-b82e-9b4af5294f7b"), 46, "Marketing 2", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("9d7f09aa-4d7c-4f13-b52e-050dd8e73967"), null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Subject",
                columns: new[] { "SubjectId", "DateOfCreation", "DateOfUpdate", "Description", "Status", "SubjectName", "TeacherId" },
                values: new object[,]
                {
                    { new Guid("3ca5fd36-8f24-4b2d-9292-1ea2772a30d6"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "No", null, "Lập Trình Web", new Guid("d9a47258-d809-4fa1-b241-59ac8c01a50d") },
                    { new Guid("463a34c9-6b74-4a41-8b07-8cc2c8c1e7bf"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "No", null, "Cơ Sở Dữ Liệu", new Guid("8fa7e6e3-2eab-479c-865a-033694979b04") },
                    { new Guid("48c76b9b-f83e-44b4-a3ca-1687859e84f9"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "No", null, "Trí Tuệ Nhân Tạo", new Guid("d9a47258-d809-4fa1-b241-59ac8c01a50d") },
                    { new Guid("5a139003-5612-4a46-9e80-bf13c8f0a9ed"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "No", null, "Đại Số Tuyến Tính", new Guid("2f043c43-cfd6-4948-9a9d-78ec32df6a9c") },
                    { new Guid("5c54dc1b-c003-4408-a7b8-84336e8fc16c"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "No", null, "Lịch Sử Đảng", new Guid("b65a41d6-c25c-4867-8b7f-a3f52a57bc26") },
                    { new Guid("7721a15a-b8e0-4fdc-a561-0b660da56c03"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "No", null, "Khai Phá Dữ Liệu", new Guid("0250e0e8-2ee9-43dc-8e13-7a0a0fda5e2a") },
                    { new Guid("8a9c8ce1-9df1-48f7-aa6f-0d3ac1b9813b"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "No", null, "Xử Lý Ảnh", new Guid("016de7a6-40a2-45c6-80f7-786810f00d27") },
                    { new Guid("a1e6eb19-c594-42a9-9d2b-1f751baffa73"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "No", null, "An Ninh Mạng", new Guid("016de7a6-40a2-45c6-80f7-786810f00d27") }
                });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Address", "ClassId", "DateOfBirth", "DateOfCreation", "DateOfUpdate", "Description", "Status", "StudentName" },
                values: new object[,]
                {
                    { new Guid("31923cf0-edb4-49c7-ab24-a06aa8844095"), "Hà Nội", new Guid("b41f3593-f66b-4b24-b82e-9b4af5294f7b"), new DateTime(2000, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "No", 3, "Ngô Ngọc Đức" },
                    { new Guid("49dc19eb-df89-476d-8974-31b86aeb4344"), "Bắc Ninh", new Guid("5e1edcf4-7a25-491c-be13-0f30e69f9d41"), new DateTime(2001, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "No", 4, "Nguyễn Đức Bảo Sơn" },
                    { new Guid("7c460a79-b7aa-4266-b0b2-825d9b4cf509"), "Bắc Giang", new Guid("627ca7ba-82de-442e-80fc-a99b59f28286"), new DateTime(2001, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "No", 4, "Nguyễn Mạnh Hiệp" },
                    { new Guid("8b1ebf96-8589-4954-875e-87e04c830a04"), "Thái Bình", new Guid("b41f3593-f66b-4b24-b82e-9b4af5294f7b"), new DateTime(2001, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "No", 3, "Lê Kiến Trúc" },
                    { new Guid("a9121c32-faa1-4394-803b-d064672a3a41"), "Hà Nội", new Guid("5e1edcf4-7a25-491c-be13-0f30e69f9d41"), new DateTime(2001, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "No", 4, "Nguyễn Quang Trung" },
                    { new Guid("aba5aae7-739b-4484-8448-7a7edd8db5a1"), "Hà Nội", new Guid("b41f3593-f66b-4b24-b82e-9b4af5294f7b"), new DateTime(2003, 12, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "No", 4, "Vũ Hoàng Minh" },
                    { new Guid("c471576f-eb74-4c3d-8071-f78e5954d959"), "Nam Định", new Guid("3fdddd8a-76c9-456e-bf35-5211f599016f"), new DateTime(1998, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "No", 4, "Nguyễn Thị Khánh" },
                    { new Guid("e9211e39-c43c-4c42-a2ad-6bb41ac928e5"), "Hải Dương", new Guid("627ca7ba-82de-442e-80fc-a99b59f28286"), new DateTime(1999, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "No", 3, "Đoàn Duy Anh" },
                    { new Guid("f67db176-22d1-4420-b683-8ab761a46948"), "Hà Nội", new Guid("627ca7ba-82de-442e-80fc-a99b59f28286"), new DateTime(2000, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "No", 4, "Phan Tiến Anh" }
                });

            migrationBuilder.InsertData(
                table: "Subject_Student",
                columns: new[] { "StudentId", "SubjectId", "DateOfCreation", "DateOfUpdate", "Description", "Mark", "Status" },
                values: new object[,]
                {
                    { new Guid("aba5aae7-739b-4484-8448-7a7edd8db5a1"), new Guid("3ca5fd36-8f24-4b2d-9292-1ea2772a30d6"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, 0 },
                    { new Guid("f67db176-22d1-4420-b683-8ab761a46948"), new Guid("463a34c9-6b74-4a41-8b07-8cc2c8c1e7bf"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, 0 },
                    { new Guid("8b1ebf96-8589-4954-875e-87e04c830a04"), new Guid("48c76b9b-f83e-44b4-a3ca-1687859e84f9"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, 0 },
                    { new Guid("49dc19eb-df89-476d-8974-31b86aeb4344"), new Guid("7721a15a-b8e0-4fdc-a561-0b660da56c03"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, 0 },
                    { new Guid("31923cf0-edb4-49c7-ab24-a06aa8844095"), new Guid("8a9c8ce1-9df1-48f7-aa6f-0d3ac1b9813b"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 7f, 1 }
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

            migrationBuilder.CreateIndex(
                name: "IX_User_UserName",
                table: "User",
                column: "UserName",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Subject_Classroom");

            migrationBuilder.DropTable(
                name: "Subject_Student");

            migrationBuilder.DropTable(
                name: "User");

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
