using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniversityManagement.Entities.Migrations
{
    /// <inheritdoc />
    public partial class AddDbUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "UserId", "DateOfCreation", "DateOfUpdate", "Description", "FullName", "Password", "Status", "UserName" },
                values: new object[] { new Guid("16cf8c42-8e65-4772-9862-84c84efc10b1"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "No", "Nguyễn Đức Bảo Sơn", "Admin", null, "Admin" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "UserId",
                keyValue: new Guid("16cf8c42-8e65-4772-9862-84c84efc10b1"));
        }
    }
}
