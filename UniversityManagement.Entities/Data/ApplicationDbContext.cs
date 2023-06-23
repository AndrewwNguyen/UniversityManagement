using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityManagement.Entities.Configuration;
using UniversityManagement.Entities.Models;

namespace UniversityManagement.Entities.Data
{
    public class ApplicationDbContext : DbContext

    {
        public DbSet<Class> Class { get; set; }
        public DbSet<ClassRoom> ClassRoom { get; set; }
        public DbSet<Department> Department { get; set; }
        public DbSet<Student> Student { get; set; }
        public DbSet <Subject_Student> Subject_Student { get; set; }
        public DbSet <Subject> Subject { get; set; }
        public DbSet <Teacher> Teacher { get; set; }
        public DbSet<Subject_Classroom> Subject_Classroom { get; set; }
        private const string connectionString = @"Server=ANDREWW\SQLEXPRESS;Database=UniversityManagement;Integrated Security=True;Trusted_Connection =True;TrustServerCertificate=True;";

        public static readonly ILoggerFactory loggerFactory = LoggerFactory.Create(builder =>
        {
            builder
                   .AddFilter(DbLoggerCategory.Database.Command.Name, LogLevel.Warning)
                   .AddFilter(DbLoggerCategory.Query.Name, LogLevel.Debug);
        }
       );
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseLoggerFactory(loggerFactory);
            optionsBuilder.UseSqlServer(connectionString);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ClassConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ClassRoomConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DepartmentConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(StudentConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(Subject_StudentConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TeacherConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(Subject_ClassroomConfiguration).Assembly);


            //DEPARMENT
            modelBuilder.Entity<Department>().HasData(
                new Department { IdDeparment = 1, Name = "Cong Nghe Thong Tin", Description = "No" }
                );
            modelBuilder.Entity<Department>().HasData(
    new Department { IdDeparment = 2, Name = "Luat kinh Te", Description = "No" }
    );
            modelBuilder.Entity<Department>().HasData(
    new Department { IdDeparment = 3, Name = "Quan Tri Kinh Doanh", Description = "No" }
    );
            modelBuilder.Entity<Department>().HasData(
    new Department { IdDeparment = 4, Name = "Marketing", Description = "No" }
    );
            modelBuilder.Entity<Department>().HasData(
    new Department { IdDeparment = 5, Name = "Co Khi", Description = "No" }
    );




            //CLASS
            modelBuilder.Entity<Class>().HasData(
             new Class { IdClass = 1, Name = "Cong nghe thong tin 1", IdDeparment = 1, Amount = 75 }
                );
            modelBuilder.Entity<Class>().HasData(
 new Class { IdClass = 2, Name = "Cong nghe thong tin 2", IdDeparment = 1, Amount = 70 }
    );
            modelBuilder.Entity<Class>().HasData(
 new Class { IdClass = 3, Name = "Marketing 2", IdDeparment = 4, Amount = 46 }
    );
            modelBuilder.Entity<Class>().HasData(
 new Class { IdClass = 4, Name = "Co Khi", IdDeparment = 5, Amount = 49 }
    );
            modelBuilder.Entity<Class>().HasData(
 new Class { IdClass = 5, Name = "Cong nghe thong tin 3", IdDeparment = 1, Amount = 70 }
    );
            modelBuilder.Entity<Class>().HasData(
 new Class { IdClass = 6, Name = "Quan Tri Kinh Doanh 1", IdDeparment = 3, Amount = 60 }
    );
            modelBuilder.Entity<Class>().HasData(
 new Class { IdClass = 7, Name = "Luat Kinh Te 1", IdDeparment = 2, Amount = 72 }
    );
            modelBuilder.Entity<Class>().HasData(
 new Class { IdClass = 8, Name = "Co Khi 2", IdDeparment = 5, Amount = 75 }
    );


            // STUDENT
            modelBuilder.Entity<Student>().HasData(
                new Student { IdStudent = 2, Name = "Nguyen Duc Bao Son", Address = "Bac Ninh", IdClass = 1, DateOfBirth = new DateTime(2001, 9, 2) }
                ); ;

            modelBuilder.Entity<Student>().HasData(
                new Student { IdStudent = 3, Name = "Nguyen Quang Trung", Address = "Ha Noi", IdClass = 1, DateOfBirth = new DateTime(2001, 12, 25) }
                ); ;

            modelBuilder.Entity<Student>().HasData(
                new Student { IdStudent = 4, Name = "Nguyen Manh Hiep", Address = "Bac Giang", IdClass = 3, DateOfBirth = new DateTime(2001, 1, 4) }
                ); ;

            modelBuilder.Entity<Student>().HasData(
                new Student { IdStudent = 5, Name = "Vu Hoang Minh", Address = "Ha Noi", IdClass = 4, DateOfBirth = new DateTime(2003, 12, 4) }
                ); ;

            modelBuilder.Entity<Student>().HasData(
                new Student { IdStudent = 6, Name = "Doan Duy Anh", Address = "Hai Duong", IdClass = 3, DateOfBirth = new DateTime(1999, 12, 8) }
                ); ;

            modelBuilder.Entity<Student>().HasData(
                new Student { IdStudent = 7, Name = "Phan Tien Anh", Address = "Ha Noi", IdClass = 2, DateOfBirth = new DateTime(2000, 2, 2) }
                ); ;

            modelBuilder.Entity<Student>().HasData(
                new Student { IdStudent = 8, Name = "Ngo Ngoc Duc", Address = "Ha Noi", IdClass = 4, DateOfBirth = new DateTime(2000, 12, 25) }
                ); ;

            modelBuilder.Entity<Student>().HasData(
                new Student { IdStudent = 9, Name = "Nguyen Thi Khanh", Address = "Nam Dinh", IdClass = 5, DateOfBirth = new DateTime(1998, 4, 4) }
                ); ;

            modelBuilder.Entity<Student>().HasData(
                new Student { IdStudent = 10, Name = "Le Kien Truc", Address = "Thai Binh", IdClass = 3, DateOfBirth = new DateTime(2001, 12, 25) }
                );


            ///SUBJECT
            modelBuilder.Entity<Subject>().HasData(
                new Subject { IdSubject = 1, Name = "Lap Trinh Web", Description = "No" ,IdTeacher =1}
                );
            modelBuilder.Entity<Subject>().HasData(
    new Subject { IdSubject = 2, Name = "An Ninh Mang", Description = "No", IdTeacher = 2 }
    );
            modelBuilder.Entity<Subject>().HasData(
    new Subject { IdSubject = 3, Name = "Tri Tue Nhan Tao", Description = "No", IdTeacher = 1 }
    );
            modelBuilder.Entity<Subject>().HasData(
    new Subject { IdSubject = 4, Name = "Lich Su Dang", Description = "No" , IdTeacher = 3 }
    );
            modelBuilder.Entity<Subject>().HasData(
    new Subject { IdSubject = 5, Name = "Dai So Tuyen Tinh", Description = "No" , IdTeacher = 4 }
    );
            modelBuilder.Entity<Subject>().HasData(
    new Subject { IdSubject = 6, Name = "Co So Du Lieu", Description = "No" , IdTeacher = 5 }
    );
            modelBuilder.Entity<Subject>().HasData(
    new Subject { IdSubject = 7, Name = "Xu Ly Anh", Description = "No" , IdTeacher = 6 }
    );
            modelBuilder.Entity<Subject>().HasData(
    new Subject { IdSubject = 8, Name = "Khai Pha Du Lieu", Description = "No" , IdTeacher = 1 }
    );
            modelBuilder.Entity<ClassRoom>().HasData(
                new ClassRoom { IdClassRoom = 1, Name = "Room 303A7", Description = "No"}
                );

            //                // TEACHER
            modelBuilder.Entity<Teacher>().HasData(
                new Teacher { IdTeacher = 1, Name = "Bui Ngoc Dung", Description = "No",}
                );
            modelBuilder.Entity<Teacher>().HasData(
    new Teacher { IdTeacher = 2, Name = "Nguyen Kim Sao", Description = "No", }
    );
            modelBuilder.Entity<Teacher>().HasData(
    new Teacher { IdTeacher = 3, Name = "Nguyen Thu Phuong", Description = "No", }
    );
            modelBuilder.Entity<Teacher>().HasData(
    new Teacher { IdTeacher = 4, Name = "Thieu Tran Cuong", Description = "No", }
    );
            modelBuilder.Entity<Teacher>().HasData(
    new Teacher { IdTeacher = 5, Name = "Dao Nhu Quynh", Description = "No", }
    );
            modelBuilder.Entity<Teacher>().HasData(
    new Teacher { IdTeacher = 6, Name = "Nguyen Gia Quy", Description = "No", }
    );


            //SUBJECT_STUDENT
            modelBuilder.Entity<Subject_Student>().HasData(
                new Subject_Student { IdStudent = 2, IdSubject = 4 ,Status = Enum.Status.Pass, Mark =7},
                new Subject_Student { IdStudent = 2, IdSubject = 2, Status = Enum.Status.Inprocess },
                new Subject_Student { IdStudent = 3, IdSubject = 1, Status = Enum.Status.Inprocess },
                new Subject_Student { IdStudent = 2, IdSubject = 1 , Status = Enum.Status.Inprocess },
                new Subject_Student { IdStudent = 3, IdSubject = 2 , Status = Enum.Status.Inprocess }
                );
        }
    }
}
