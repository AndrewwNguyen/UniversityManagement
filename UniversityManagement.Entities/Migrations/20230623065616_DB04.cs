using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniversityManagement.Entities.Migrations
{
    /// <inheritdoc />
    public partial class DB04 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Subject_Score");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Subject_Student",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Mark",
                table: "Subject_Student",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Subject_Classroom",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Class",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Class",
                keyColumn: "IdClass",
                keyValue: 1,
                column: "Description",
                value: null);

            migrationBuilder.UpdateData(
                table: "Class",
                keyColumn: "IdClass",
                keyValue: 2,
                column: "Description",
                value: null);

            migrationBuilder.UpdateData(
                table: "Class",
                keyColumn: "IdClass",
                keyValue: 3,
                column: "Description",
                value: null);

            migrationBuilder.UpdateData(
                table: "Class",
                keyColumn: "IdClass",
                keyValue: 4,
                column: "Description",
                value: null);

            migrationBuilder.UpdateData(
                table: "Class",
                keyColumn: "IdClass",
                keyValue: 5,
                column: "Description",
                value: null);

            migrationBuilder.UpdateData(
                table: "Class",
                keyColumn: "IdClass",
                keyValue: 6,
                column: "Description",
                value: null);

            migrationBuilder.UpdateData(
                table: "Class",
                keyColumn: "IdClass",
                keyValue: 7,
                column: "Description",
                value: null);

            migrationBuilder.UpdateData(
                table: "Class",
                keyColumn: "IdClass",
                keyValue: 8,
                column: "Description",
                value: null);

            migrationBuilder.UpdateData(
                table: "Subject_Student",
                keyColumns: new[] { "IdStudent", "IdSubject" },
                keyValues: new object[] { 2, 1 },
                columns: new[] { "Description", "Mark" },
                values: new object[] { null, 0 });

            migrationBuilder.UpdateData(
                table: "Subject_Student",
                keyColumns: new[] { "IdStudent", "IdSubject" },
                keyValues: new object[] { 3, 1 },
                columns: new[] { "Description", "Mark" },
                values: new object[] { null, 0 });

            migrationBuilder.UpdateData(
                table: "Subject_Student",
                keyColumns: new[] { "IdStudent", "IdSubject" },
                keyValues: new object[] { 2, 2 },
                columns: new[] { "Description", "Mark" },
                values: new object[] { null, 0 });

            migrationBuilder.UpdateData(
                table: "Subject_Student",
                keyColumns: new[] { "IdStudent", "IdSubject" },
                keyValues: new object[] { 3, 2 },
                columns: new[] { "Description", "Mark" },
                values: new object[] { null, 0 });

            migrationBuilder.UpdateData(
                table: "Subject_Student",
                keyColumns: new[] { "IdStudent", "IdSubject" },
                keyValues: new object[] { 2, 4 },
                columns: new[] { "Description", "Mark" },
                values: new object[] { null, 0 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Subject_Student");

            migrationBuilder.DropColumn(
                name: "Mark",
                table: "Subject_Student");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Subject_Classroom");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Class");

            migrationBuilder.CreateTable(
                name: "Subject_Score",
                columns: table => new
                {
                    IdSubject = table.Column<int>(type: "int", nullable: false),
                    IdStudent = table.Column<int>(type: "int", nullable: false),
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

            migrationBuilder.CreateIndex(
                name: "IX_Subject_Score_IdStudent",
                table: "Subject_Score",
                column: "IdStudent");
        }
    }
}
