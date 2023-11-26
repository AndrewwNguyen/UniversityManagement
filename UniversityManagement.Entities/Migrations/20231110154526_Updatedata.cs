using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniversityManagement.Entities.Migrations
{
    /// <inheritdoc />
    public partial class Updatedata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "UserId", "DateOfCreation", "DateOfUpdate", "Description", "FullName", "Password", "Role", "Status", "UserName" },
                values: new object[] { new Guid("8791be24-35e1-4e8c-aee9-2e0e9c706609"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "No", "Bùi Linh Giang", "Giang", "User", null, "Giang" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "UserId",
                keyValue: new Guid("8791be24-35e1-4e8c-aee9-2e0e9c706609"));
        }
    }
}
