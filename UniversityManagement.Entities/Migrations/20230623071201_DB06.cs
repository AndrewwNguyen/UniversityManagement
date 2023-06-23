using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniversityManagement.Entities.Migrations
{
    /// <inheritdoc />
    public partial class DB06 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Subject_Student",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Subject_Student",
                keyColumns: new[] { "IdStudent", "IdSubject" },
                keyValues: new object[] { 2, 1 },
                column: "Status",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Subject_Student",
                keyColumns: new[] { "IdStudent", "IdSubject" },
                keyValues: new object[] { 3, 1 },
                column: "Status",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Subject_Student",
                keyColumns: new[] { "IdStudent", "IdSubject" },
                keyValues: new object[] { 2, 2 },
                column: "Status",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Subject_Student",
                keyColumns: new[] { "IdStudent", "IdSubject" },
                keyValues: new object[] { 3, 2 },
                column: "Status",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Subject_Student",
                keyColumns: new[] { "IdStudent", "IdSubject" },
                keyValues: new object[] { 2, 4 },
                column: "Status",
                value: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Subject_Student");
        }
    }
}
