using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniversityManagement.Entities.Migrations
{
    /// <inheritdoc />
    public partial class DB10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Student",
                keyColumn: "IdStudent",
                keyValue: 2,
                column: "DateOfBirth",
                value: new DateTime(2001, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Student",
                keyColumn: "IdStudent",
                keyValue: 3,
                column: "DateOfBirth",
                value: new DateTime(2001, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Student",
                keyColumn: "IdStudent",
                keyValue: 4,
                column: "DateOfBirth",
                value: new DateTime(2001, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Student",
                keyColumn: "IdStudent",
                keyValue: 5,
                column: "DateOfBirth",
                value: new DateTime(2003, 12, 4, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Student",
                keyColumn: "IdStudent",
                keyValue: 6,
                column: "DateOfBirth",
                value: new DateTime(1999, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Student",
                keyColumn: "IdStudent",
                keyValue: 7,
                column: "DateOfBirth",
                value: new DateTime(2000, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Student",
                keyColumn: "IdStudent",
                keyValue: 8,
                column: "DateOfBirth",
                value: new DateTime(2000, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Student",
                keyColumn: "IdStudent",
                keyValue: 9,
                column: "DateOfBirth",
                value: new DateTime(1998, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Student",
                keyColumn: "IdStudent",
                keyValue: 10,
                column: "DateOfBirth",
                value: new DateTime(2001, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Student",
                keyColumn: "IdStudent",
                keyValue: 2,
                column: "DateOfBirth",
                value: new DateTime(2012, 12, 25, 1, 3, 12, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Student",
                keyColumn: "IdStudent",
                keyValue: 3,
                column: "DateOfBirth",
                value: new DateTime(2012, 12, 25, 1, 3, 12, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Student",
                keyColumn: "IdStudent",
                keyValue: 4,
                column: "DateOfBirth",
                value: new DateTime(2012, 12, 25, 1, 3, 12, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Student",
                keyColumn: "IdStudent",
                keyValue: 5,
                column: "DateOfBirth",
                value: new DateTime(2012, 12, 25, 1, 3, 12, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Student",
                keyColumn: "IdStudent",
                keyValue: 6,
                column: "DateOfBirth",
                value: new DateTime(2012, 12, 25, 1, 3, 12, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Student",
                keyColumn: "IdStudent",
                keyValue: 7,
                column: "DateOfBirth",
                value: new DateTime(2012, 12, 25, 1, 3, 12, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Student",
                keyColumn: "IdStudent",
                keyValue: 8,
                column: "DateOfBirth",
                value: new DateTime(2012, 12, 25, 1, 3, 12, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Student",
                keyColumn: "IdStudent",
                keyValue: 9,
                column: "DateOfBirth",
                value: new DateTime(2012, 12, 25, 1, 3, 12, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Student",
                keyColumn: "IdStudent",
                keyValue: 10,
                column: "DateOfBirth",
                value: new DateTime(2012, 12, 25, 1, 3, 12, 0, DateTimeKind.Unspecified));
        }
    }
}
