using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

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
                    IdClassRoom = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassRoom", x => x.IdClassRoom);
                });

            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    IdDeparment = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.IdDeparment);
                });

            migrationBuilder.CreateTable(
                name: "Teacher",
                columns: table => new
                {
                    IdTeacher = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teacher", x => x.IdTeacher);
                });

            migrationBuilder.CreateTable(
                name: "Class",
                columns: table => new
                {
                    IdClass = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdDeparment = table.Column<int>(type: "int", nullable: false),
                    YearOfAdmission = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Class", x => x.IdClass);
                    table.ForeignKey(
                        name: "FK_Class_Department_IdDeparment",
                        column: x => x.IdDeparment,
                        principalTable: "Department",
                        principalColumn: "IdDeparment",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Subject",
                columns: table => new
                {
                    IdSubject = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdTeacher = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subject", x => x.IdSubject);
                    table.ForeignKey(
                        name: "FK_Subject_Teacher_IdTeacher",
                        column: x => x.IdTeacher,
                        principalTable: "Teacher",
                        principalColumn: "IdTeacher",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    IdStudent = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdClass = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.IdStudent);
                    table.ForeignKey(
                        name: "FK_Student_Class_IdClass",
                        column: x => x.IdClass,
                        principalTable: "Class",
                        principalColumn: "IdClass");
                });

            migrationBuilder.CreateTable(
                name: "Subject_Classroom",
                columns: table => new
                {
                    IdRoom = table.Column<int>(type: "int", nullable: false),
                    IdSubject = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subject_Classroom", x => new { x.IdSubject, x.IdRoom });
                    table.ForeignKey(
                        name: "FK_Subject_Classroom_ClassRoom_IdRoom",
                        column: x => x.IdRoom,
                        principalTable: "ClassRoom",
                        principalColumn: "IdClassRoom",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Subject_Classroom_Subject_IdSubject",
                        column: x => x.IdSubject,
                        principalTable: "Subject",
                        principalColumn: "IdSubject",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Subject_Score",
                columns: table => new
                {
                    IdStudent = table.Column<int>(type: "int", nullable: false),
                    IdSubject = table.Column<int>(type: "int", nullable: false),
                    Mark = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subject_Score", x => new { x.IdSubject, x.IdStudent });
                    table.ForeignKey(
                        name: "FK_Subject_Score_Student_IdStudent",
                        column: x => x.IdStudent,
                        principalTable: "Student",
                        principalColumn: "IdStudent",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Subject_Score_Subject_IdSubject",
                        column: x => x.IdSubject,
                        principalTable: "Subject",
                        principalColumn: "IdSubject",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Subject_Student",
                columns: table => new
                {
                    IdStudent = table.Column<int>(type: "int", nullable: false),
                    IdSubject = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subject_Student", x => new { x.IdSubject, x.IdStudent });
                    table.ForeignKey(
                        name: "FK_Subject_Student_Student_IdStudent",
                        column: x => x.IdStudent,
                        principalTable: "Student",
                        principalColumn: "IdStudent",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Subject_Student_Subject_IdSubject",
                        column: x => x.IdSubject,
                        principalTable: "Subject",
                        principalColumn: "IdSubject",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Class_IdDeparment",
                table: "Class",
                column: "IdDeparment");

            migrationBuilder.CreateIndex(
                name: "IX_Student_IdClass",
                table: "Student",
                column: "IdClass");

            migrationBuilder.CreateIndex(
                name: "IX_Subject_IdTeacher",
                table: "Subject",
                column: "IdTeacher");

            migrationBuilder.CreateIndex(
                name: "IX_Subject_Classroom_IdRoom",
                table: "Subject_Classroom",
                column: "IdRoom");

            migrationBuilder.CreateIndex(
                name: "IX_Subject_Score_IdStudent",
                table: "Subject_Score",
                column: "IdStudent");

            migrationBuilder.CreateIndex(
                name: "IX_Subject_Student_IdStudent",
                table: "Subject_Student",
                column: "IdStudent");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Subject_Classroom");

            migrationBuilder.DropTable(
                name: "Subject_Score");

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
