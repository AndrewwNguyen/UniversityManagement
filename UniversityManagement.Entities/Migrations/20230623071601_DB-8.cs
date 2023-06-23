using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniversityManagement.Entities.Migrations
{
    /// <inheritdoc />
    public partial class DB8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "Mark",
                table: "Subject_Student",
                type: "real",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Subject_Student",
                keyColumns: new[] { "IdStudent", "IdSubject" },
                keyValues: new object[] { 2, 1 },
                column: "Mark",
                value: null);

            migrationBuilder.UpdateData(
                table: "Subject_Student",
                keyColumns: new[] { "IdStudent", "IdSubject" },
                keyValues: new object[] { 3, 1 },
                column: "Mark",
                value: null);

            migrationBuilder.UpdateData(
                table: "Subject_Student",
                keyColumns: new[] { "IdStudent", "IdSubject" },
                keyValues: new object[] { 2, 2 },
                column: "Mark",
                value: null);

            migrationBuilder.UpdateData(
                table: "Subject_Student",
                keyColumns: new[] { "IdStudent", "IdSubject" },
                keyValues: new object[] { 3, 2 },
                column: "Mark",
                value: null);

            migrationBuilder.UpdateData(
                table: "Subject_Student",
                keyColumns: new[] { "IdStudent", "IdSubject" },
                keyValues: new object[] { 2, 4 },
                column: "Mark",
                value: 7f);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Mark",
                table: "Subject_Student",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(float),
                oldType: "real",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Subject_Student",
                keyColumns: new[] { "IdStudent", "IdSubject" },
                keyValues: new object[] { 2, 1 },
                column: "Mark",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Subject_Student",
                keyColumns: new[] { "IdStudent", "IdSubject" },
                keyValues: new object[] { 3, 1 },
                column: "Mark",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Subject_Student",
                keyColumns: new[] { "IdStudent", "IdSubject" },
                keyValues: new object[] { 2, 2 },
                column: "Mark",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Subject_Student",
                keyColumns: new[] { "IdStudent", "IdSubject" },
                keyValues: new object[] { 3, 2 },
                column: "Mark",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Subject_Student",
                keyColumns: new[] { "IdStudent", "IdSubject" },
                keyValues: new object[] { 2, 4 },
                column: "Mark",
                value: 7);
        }
    }
}
