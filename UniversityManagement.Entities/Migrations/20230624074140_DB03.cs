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
            migrationBuilder.DropForeignKey(
                name: "FK_Subject_Teacher_TeacherId",
                table: "Subject");

            migrationBuilder.AlterColumn<int>(
                name: "TeacherId",
                table: "Subject",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Subject_Teacher_TeacherId",
                table: "Subject",
                column: "TeacherId",
                principalTable: "Teacher",
                principalColumn: "TeacherId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subject_Teacher_TeacherId",
                table: "Subject");

            migrationBuilder.AlterColumn<int>(
                name: "TeacherId",
                table: "Subject",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Subject_Teacher_TeacherId",
                table: "Subject",
                column: "TeacherId",
                principalTable: "Teacher",
                principalColumn: "TeacherId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
