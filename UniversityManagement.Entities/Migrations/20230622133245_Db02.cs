using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniversityManagement.Entities.Migrations
{
    /// <inheritdoc />
    public partial class Db02 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Deparment",
                columns: new[] { "IdDeparment", "Description", "Name" },
                values: new object[] { 1, null, "Cong Nghe Thong Tin" });

            migrationBuilder.InsertData(
                table: "Class",
                columns: new[] { "IdClass", "Amount", "IdDeparment", "Name", "YearOfAdmission" },
                values: new object[] { 1, 75, 1, "Cong nghe thong tin 1", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "IdClass", "Address", "DateOfBirth", "IdStudent", "Name" },
                values: new object[] { 1, "Ha Noi", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Nguyen Duc Bao Son" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Student",
                keyColumn: "IdClass",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Class",
                keyColumn: "IdClass",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Deparment",
                keyColumn: "IdDeparment",
                keyValue: 1);
        }
    }
}
