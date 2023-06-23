using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniversityManagement.Entities.Migrations
{
    /// <inheritdoc />
    public partial class DB03 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Student",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Student",
                keyColumn: "IdStudent",
                keyValue: 2,
                column: "Description",
                value: null);

            migrationBuilder.UpdateData(
                table: "Student",
                keyColumn: "IdStudent",
                keyValue: 3,
                column: "Description",
                value: null);

            migrationBuilder.UpdateData(
                table: "Student",
                keyColumn: "IdStudent",
                keyValue: 4,
                column: "Description",
                value: null);

            migrationBuilder.UpdateData(
                table: "Student",
                keyColumn: "IdStudent",
                keyValue: 5,
                column: "Description",
                value: null);

            migrationBuilder.UpdateData(
                table: "Student",
                keyColumn: "IdStudent",
                keyValue: 6,
                column: "Description",
                value: null);

            migrationBuilder.UpdateData(
                table: "Student",
                keyColumn: "IdStudent",
                keyValue: 7,
                column: "Description",
                value: null);

            migrationBuilder.UpdateData(
                table: "Student",
                keyColumn: "IdStudent",
                keyValue: 8,
                column: "Description",
                value: null);

            migrationBuilder.UpdateData(
                table: "Student",
                keyColumn: "IdStudent",
                keyValue: 9,
                column: "Description",
                value: null);

            migrationBuilder.UpdateData(
                table: "Student",
                keyColumn: "IdStudent",
                keyValue: 10,
                column: "Description",
                value: null);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Student");
        }
    }
}
