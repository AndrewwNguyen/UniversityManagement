using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace UniversityManagement.Entities.Migrations
{
    /// <inheritdoc />
    public partial class DB02 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ClassRoom",
                columns: new[] { "IdClassRoom", "Description", "Name" },
                values: new object[] { 1, "No", "Room 303A7" });

            migrationBuilder.InsertData(
                table: "Department",
                columns: new[] { "IdDeparment", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "No", "Cong Nghe Thong Tin" },
                    { 2, "No", "Luat kinh Te" },
                    { 3, "No", "Quan Tri Kinh Doanh" },
                    { 4, "No", "Marketing" },
                    { 5, "No", "Co Khi" }
                });

            migrationBuilder.InsertData(
                table: "Teacher",
                columns: new[] { "IdTeacher", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "No", "Bui Ngoc Dung" },
                    { 2, "No", "Nguyen Kim Sao" },
                    { 3, "No", "Nguyen Thu Phuong" },
                    { 4, "No", "Thieu Tran Cuong" },
                    { 5, "No", "Dao Nhu Quynh" },
                    { 6, "No", "Nguyen Gia Quy" }
                });

            migrationBuilder.InsertData(
                table: "Class",
                columns: new[] { "IdClass", "Amount", "IdDeparment", "Name", "YearOfAdmission" },
                values: new object[,]
                {
                    { 1, 75, 1, "Cong nghe thong tin 1", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 70, 1, "Cong nghe thong tin 2", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 46, 4, "Marketing 2", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, 49, 5, "Co Khi", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, 70, 1, "Cong nghe thong tin 3", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, 60, 3, "Quan Tri Kinh Doanh 1", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, 72, 2, "Luat Kinh Te 1", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, 75, 5, "Co Khi 2", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Subject",
                columns: new[] { "IdSubject", "Description", "IdTeacher", "Name" },
                values: new object[,]
                {
                    { 1, "No", 1, "Lap Trinh Web" },
                    { 2, "No", 2, "An Ninh Mang" },
                    { 3, "No", 1, "Tri Tue Nhan Tao" },
                    { 4, "No", 3, "Lich Su Dang" },
                    { 5, "No", 4, "Dai So Tuyen Tinh" },
                    { 6, "No", 5, "Co So Du Lieu" },
                    { 7, "No", 6, "Xu Ly Anh" },
                    { 8, "No", 1, "Khai Pha Du Lieu" }
                });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "IdStudent", "Address", "DateOfBirth", "IdClass", "Name" },
                values: new object[,]
                {
                    { 2, "Bac Ninh", new DateTime(2012, 12, 25, 1, 3, 12, 0, DateTimeKind.Unspecified), 1, "Nguyen Duc Bao Son" },
                    { 3, "Ha Noi", new DateTime(2012, 12, 25, 1, 3, 12, 0, DateTimeKind.Unspecified), 1, "Nguyen Quang Trung" },
                    { 4, "Bac Giang", new DateTime(2012, 12, 25, 1, 3, 12, 0, DateTimeKind.Unspecified), 3, "Nguyen Manh Hiep" },
                    { 5, "Ha Noi", new DateTime(2012, 12, 25, 1, 3, 12, 0, DateTimeKind.Unspecified), 4, "Vu Hoang Minh" },
                    { 6, "Hai Duong", new DateTime(2012, 12, 25, 1, 3, 12, 0, DateTimeKind.Unspecified), 3, "Doan Duy Anh" },
                    { 7, "Ha Noi", new DateTime(2012, 12, 25, 1, 3, 12, 0, DateTimeKind.Unspecified), 2, "Phan Tien Anh" },
                    { 8, "Ha Noi", new DateTime(2012, 12, 25, 1, 3, 12, 0, DateTimeKind.Unspecified), 4, "Ngo Ngoc Duc" },
                    { 9, "Nam Dinh", new DateTime(2012, 12, 25, 1, 3, 12, 0, DateTimeKind.Unspecified), 5, "Nguyen Thi Khanh" },
                    { 10, "Thai Binh", new DateTime(2012, 12, 25, 1, 3, 12, 0, DateTimeKind.Unspecified), 3, "Le Kien Truc" }
                });

            migrationBuilder.InsertData(
                table: "Subject_Student",
                columns: new[] { "IdStudent", "IdSubject" },
                values: new object[,]
                {
                    { 2, 1 },
                    { 3, 1 },
                    { 2, 2 },
                    { 3, 2 },
                    { 2, 4 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Class",
                keyColumn: "IdClass",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Class",
                keyColumn: "IdClass",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Class",
                keyColumn: "IdClass",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "ClassRoom",
                keyColumn: "IdClassRoom",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Student",
                keyColumn: "IdStudent",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Student",
                keyColumn: "IdStudent",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Student",
                keyColumn: "IdStudent",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Student",
                keyColumn: "IdStudent",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Student",
                keyColumn: "IdStudent",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Student",
                keyColumn: "IdStudent",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Student",
                keyColumn: "IdStudent",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Subject",
                keyColumn: "IdSubject",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Subject",
                keyColumn: "IdSubject",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Subject",
                keyColumn: "IdSubject",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Subject",
                keyColumn: "IdSubject",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Subject",
                keyColumn: "IdSubject",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Subject_Student",
                keyColumns: new[] { "IdStudent", "IdSubject" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "Subject_Student",
                keyColumns: new[] { "IdStudent", "IdSubject" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "Subject_Student",
                keyColumns: new[] { "IdStudent", "IdSubject" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "Subject_Student",
                keyColumns: new[] { "IdStudent", "IdSubject" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.DeleteData(
                table: "Subject_Student",
                keyColumns: new[] { "IdStudent", "IdSubject" },
                keyValues: new object[] { 2, 4 });

            migrationBuilder.DeleteData(
                table: "Class",
                keyColumn: "IdClass",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Class",
                keyColumn: "IdClass",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Class",
                keyColumn: "IdClass",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Class",
                keyColumn: "IdClass",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Department",
                keyColumn: "IdDeparment",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Department",
                keyColumn: "IdDeparment",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Student",
                keyColumn: "IdStudent",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Student",
                keyColumn: "IdStudent",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Subject",
                keyColumn: "IdSubject",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Subject",
                keyColumn: "IdSubject",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Subject",
                keyColumn: "IdSubject",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Teacher",
                keyColumn: "IdTeacher",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Teacher",
                keyColumn: "IdTeacher",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Teacher",
                keyColumn: "IdTeacher",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Class",
                keyColumn: "IdClass",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Department",
                keyColumn: "IdDeparment",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Department",
                keyColumn: "IdDeparment",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Teacher",
                keyColumn: "IdTeacher",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Teacher",
                keyColumn: "IdTeacher",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Teacher",
                keyColumn: "IdTeacher",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Department",
                keyColumn: "IdDeparment",
                keyValue: 1);
        }
    }
}
