using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniversityManagement.Entities.Migrations
{
    /// <inheritdoc />
    public partial class DB07 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Subject_Student",
                keyColumns: new[] { "IdStudent", "IdSubject" },
                keyValues: new object[] { 2, 4 },
                columns: new[] { "Mark", "Status" },
                values: new object[] { 7, 1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Subject_Student",
                keyColumns: new[] { "IdStudent", "IdSubject" },
                keyValues: new object[] { 2, 4 },
                columns: new[] { "Mark", "Status" },
                values: new object[] { 0, 0 });
        }
    }
}
