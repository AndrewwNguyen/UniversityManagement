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
        public DbSet<Subject_Student> Subject_Student { get; set; }
        public DbSet<Subject> Subject { get; set; }
        public DbSet<Teacher> Teacher { get; set; }
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
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(Subject_StudentConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TeacherConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(Subject_ClassroomConfiguration).Assembly);


            //DEPARMENT
            modelBuilder.Entity<Department>().HasData(
                new Department { DepartmentId = 1, DepartmentName = "Cong Nghe Thong Tin", Description = "No" }
                );
            modelBuilder.Entity<Department>().HasData(
    new Department { DepartmentId = 2, DepartmentName = "Luat kinh Te", Description = "No" }
    );
            modelBuilder.Entity<Department>().HasData(
    new Department { DepartmentId = 3, DepartmentName = "Quan Tri Kinh Doanh", Description = "No" }
    );
            modelBuilder.Entity<Department>().HasData(
    new Department { DepartmentId = 4, DepartmentName = "Marketing", Description = "No" }
    );
            modelBuilder.Entity<Department>().HasData(
    new Department { DepartmentId = 5, DepartmentName = "Co Khi", Description = "No" }
    );




            //CLASS
            modelBuilder.Entity<Class>().HasData(
             new Class { ClassId = 1, ClassName = "Cong nghe thong tin 1", DepartmentId = 1, Amount = 75 }
                );
            modelBuilder.Entity<Class>().HasData(
 new Class { ClassId = 2, ClassName = "Cong nghe thong tin 2", DepartmentId = 1, Amount = 70 }
    );
            modelBuilder.Entity<Class>().HasData(
 new Class { ClassId = 3, ClassName = "Marketing 2", DepartmentId = 4, Amount = 46 }
    );
            modelBuilder.Entity<Class>().HasData(
 new Class { ClassId = 4, ClassName = "Co Khi", DepartmentId = 5, Amount = 49 }
    );
            modelBuilder.Entity<Class>().HasData(
 new Class { ClassId = 5, ClassName = "Cong nghe thong tin 3", DepartmentId = 1, Amount = 70 }
    );
            modelBuilder.Entity<Class>().HasData(
 new Class { ClassId = 6, ClassName = "Quan Tri Kinh Doanh 1", DepartmentId = 3, Amount = 60 }
    );
            modelBuilder.Entity<Class>().HasData(
 new Class { ClassId = 7, ClassName = "Luat Kinh Te 1", DepartmentId = 2, Amount = 72 }
    );
            modelBuilder.Entity<Class>().HasData(
 new Class { ClassId = 8, ClassName = "Co Khi 2", DepartmentId = 5, Amount = 75 }
    );


            // STUDENT
            modelBuilder.Entity<Student>().HasData(
                new Student { StudentId = 2, StudentName = "Nguyen Duc Bao Son", Address = "Bac Ninh", ClassId = 1, DateOfBirth = new DateTime(2001, 9, 2), Description = "No" }
                ); ;

            modelBuilder.Entity<Student>().HasData(
                new Student { StudentId = 3, StudentName = "Nguyen Quang Trung", Address = "Ha Noi", ClassId = 1, DateOfBirth = new DateTime(2001, 12, 25), Description = "No" }
                ); ;

            modelBuilder.Entity<Student>().HasData(
                new Student { StudentId = 4, StudentName = "Nguyen Manh Hiep", Address = "Bac Giang", ClassId = 3, DateOfBirth = new DateTime(2001, 1, 4), Description = "No" }
                ); ;

            modelBuilder.Entity<Student>().HasData(
                new Student { StudentId = 5, StudentName = "Vu Hoang Minh", Address = "Ha Noi", ClassId = 4, DateOfBirth = new DateTime(2003, 12, 4), Description = "No" }
                ); ;

            modelBuilder.Entity<Student>().HasData(
                new Student { StudentId = 6, StudentName = "Doan Duy Anh", Address = "Hai Duong", ClassId = 3, DateOfBirth = new DateTime(1999, 12, 8), Description = "No" }
                ); ;

            modelBuilder.Entity<Student>().HasData(
                new Student { StudentId = 7, StudentName = "Phan Tien Anh", Address = "Ha Noi", ClassId = 2, DateOfBirth = new DateTime(2000, 2, 2), Description = "No" }
                ); ;

            modelBuilder.Entity<Student>().HasData(
                new Student { StudentId = 8, StudentName = "Ngo Ngoc Duc", Address = "Ha Noi", ClassId = 4, DateOfBirth = new DateTime(2000, 12, 25), Description = "No" }
                ); ;

            modelBuilder.Entity<Student>().HasData(
                new Student { StudentId = 9, StudentName = "Nguyen Thi Khanh", Address = "Nam Dinh", ClassId = 5, DateOfBirth = new DateTime(1998, 4, 4), Description = "No" }
                ); ;

            modelBuilder.Entity<Student>().HasData(
                new Student { StudentId = 10, StudentName = "Le Kien Truc", Address = "Thai Binh", ClassId = 3, DateOfBirth = new DateTime(2001, 12, 25), Description = "No" }
                );


            ///SUBJECT
            modelBuilder.Entity<Subject>().HasData(
                new Subject { SubjectId = 1, SubjectName = "Lap Trinh Web", Description = "No", TeacherId = 1 }
                );
            modelBuilder.Entity<Subject>().HasData(
    new Subject { SubjectId = 2, SubjectName = "An Ninh Mang", Description = "No", TeacherId = 2 }
    );
            modelBuilder.Entity<Subject>().HasData(
    new Subject { SubjectId = 3, SubjectName = "Tri Tue Nhan Tao", Description = "No", TeacherId = 1 }
    );
            modelBuilder.Entity<Subject>().HasData(
    new Subject { SubjectId = 4, SubjectName = "Lich Su Dang", Description = "No", TeacherId = 3 }
    );
            modelBuilder.Entity<Subject>().HasData(
    new Subject { SubjectId = 5, SubjectName = "Dai So Tuyen Tinh", Description = "No", TeacherId = 4 }
    );
            modelBuilder.Entity<Subject>().HasData(
    new Subject { SubjectId = 6, SubjectName = "Co So Du Lieu", Description = "No", TeacherId = 5 }
    );
            modelBuilder.Entity<Subject>().HasData(
    new Subject { SubjectId = 7, SubjectName = "Xu Ly Anh", Description = "No", TeacherId = 6 }
    );
            modelBuilder.Entity<Subject>().HasData(
    new Subject { SubjectId = 8, SubjectName = "Khai Pha Du Lieu", Description = "No", TeacherId = 1 }
    );
            modelBuilder.Entity<ClassRoom>().HasData(
                new ClassRoom { ClassRoomId = 1, ClassRoomName = "Room 303A7", Description = "No" }
                );
            //                // TEACHER
            modelBuilder.Entity<Teacher>().HasData(
                new Teacher { TeacherId = 1, TeacherName = "Bui Ngoc Dung", Description = "No", }
                );
            modelBuilder.Entity<Teacher>().HasData(
    new Teacher { TeacherId = 2, TeacherName = "Nguyen Kim Sao", Description = "No", }
    );
            modelBuilder.Entity<Teacher>().HasData(
    new Teacher { TeacherId = 3, TeacherName = "Nguyen Thu Phuong", Description = "No", }
    );
            modelBuilder.Entity<Teacher>().HasData(
    new Teacher { TeacherId = 4, TeacherName = "Thieu Tran Cuong", Description = "No", }
    );
            modelBuilder.Entity<Teacher>().HasData(
    new Teacher { TeacherId = 5, TeacherName = "Dao Nhu Quynh", Description = "No", }
    );
            modelBuilder.Entity<Teacher>().HasData(
    new Teacher { TeacherId = 6, TeacherName = "Nguyen Gia Quy", Description = "No", }
    );


            //SUBJECT_STUDENT
            modelBuilder.Entity<Subject_Student>().HasData(
                new Subject_Student { StudentId = 2, SubjectId = 4, Status = Enum.Status.Pass, Mark = 7 },
                new Subject_Student { StudentId = 2, SubjectId = 2, Status = Enum.Status.Inprocess },
                new Subject_Student { StudentId = 3, SubjectId = 1, Status = Enum.Status.Inprocess },
                new Subject_Student { StudentId = 2, SubjectId = 1, Status = Enum.Status.Inprocess },
                new Subject_Student { StudentId = 3, SubjectId = 2, Status = Enum.Status.Inprocess }
                );
        }
    }
}
