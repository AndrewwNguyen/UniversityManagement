using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using UniversityManagement.Entities.Enum;
using UniversityManagement.Entities.Configuration;
using UniversityManagement.Entities.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace UniversityManagement.Entities.Data
{
    public class ApplicationDbContext :DbContext
    {
        //public ApplicationDbContext(DbContextOptions<ApplicationDbContext> opt):base(opt)
        //{

        //}
        public DbSet<Class> Class { get; set; }
        public DbSet<ClassRoom> ClassRoom { get; set; }
        public DbSet<Department> Department { get; set; }
        public DbSet<Student> Student { get; set; }
        public DbSet<Subject_Student> Subject_Student { get; set; }
        public DbSet<RefreshToken> RefreshToken { get; set; }
        public DbSet<Subject> Subject { get; set; }
        public DbSet<Teacher> Teacher { get; set; }
        public DbSet<Subject_Classroom> Subject_Classroom { get; set; }
        public DbSet<User> User { get; set; }
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
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(UserConfiguration).Assembly);


            //DEPARMENT
            modelBuilder.Entity<Department>().HasData(
                           new Department { DepartmentId = Guid.Parse("b2e8e638-aaba-4a91-afb1-56dede21f2e2"), DepartmentName = "Công Nghệ Thông Tin", Description = "No" }
                           );
                        modelBuilder.Entity<Department>().HasData(
    new Department { DepartmentId = Guid.Parse("3c1f9665-f8f7-42e2-8c38-4ef4f02b4bcf"), DepartmentName = "Luật Kinh Tế", Description = "No" }
    );
            modelBuilder.Entity<Department>().HasData(
    new Department { DepartmentId = Guid.Parse("fce4b0c8-9005-4701-adca-bebd946b2252"), DepartmentName = "Quản Trị Kinh Doanh", Description = "No" }
    );
            modelBuilder.Entity<Department>().HasData(
    new Department { DepartmentId = Guid.Parse("9d7f09aa-4d7c-4f13-b52e-050dd8e73967"), DepartmentName = "Marketing", Description = "No" }
    );
            modelBuilder.Entity<Department>().HasData(
    new Department { DepartmentId = Guid.Parse("9c6c42ef-7167-41ce-af61-46bd7a9d66da"), DepartmentName = "Cơ Khí", Description = "No" }
    );




            //           //CLASS
            modelBuilder.Entity<Class>().HasData(
             new Class { ClassId = Guid.Parse("3fdddd8a-76c9-456e-bf35-5211f599016f"), ClassName = "Công Nghệ Thông Tin 1", DepartmentId = Guid.Parse("9c6c42ef-7167-41ce-af61-46bd7a9d66da"), Amount = 75 }
                );
            modelBuilder.Entity<Class>().HasData(
 new Class { ClassId = Guid.Parse("1fc38461-29bb-4123-9af6-aec3945bb378"), ClassName = "Công Nghệ Thông Tin 2", DepartmentId = Guid.Parse("9d7f09aa-4d7c-4f13-b52e-050dd8e73967"), Amount = 70 }
    );
            modelBuilder.Entity<Class>().HasData(
 new Class { ClassId = Guid.Parse("b41f3593-f66b-4b24-b82e-9b4af5294f7b"), ClassName = "Marketing 2", DepartmentId = Guid.Parse("9d7f09aa-4d7c-4f13-b52e-050dd8e73967"), Amount = 46 }
    );
            modelBuilder.Entity<Class>().HasData(
 new Class { ClassId = Guid.Parse("627ca7ba-82de-442e-80fc-a99b59f28286"), ClassName = "Cơ Khí 1", DepartmentId = Guid.Parse("3c1f9665-f8f7-42e2-8c38-4ef4f02b4bcf"), Amount = 49 }
    );
            modelBuilder.Entity<Class>().HasData(
 new Class { ClassId = Guid.Parse("00ed687d-de80-424c-a87c-b3f03a922724"), ClassName = "Công Nghệ Thông Tin 3", DepartmentId = Guid.Parse("b2e8e638-aaba-4a91-afb1-56dede21f2e2"), Amount = 70 }
    );
            modelBuilder.Entity<Class>().HasData(
 new Class { ClassId = Guid.Parse("2215e3b8-44f2-439c-9c02-107a8fb769e2"), ClassName = "Quản Trị Kinh Doanh 1", DepartmentId = Guid.Parse("3c1f9665-f8f7-42e2-8c38-4ef4f02b4bcf"), Amount = 60 }
    );
            modelBuilder.Entity<Class>().HasData(
 new Class { ClassId = Guid.Parse("02a4a852-f9de-43b9-91bc-f52dad047562"), ClassName = "Luật Kinh Tế 1", DepartmentId = Guid.Parse("b2e8e638-aaba-4a91-afb1-56dede21f2e2"), Amount = 72 }
    );
            modelBuilder.Entity<Class>().HasData(
 new Class { ClassId = Guid.Parse("5e1edcf4-7a25-491c-be13-0f30e69f9d41"), ClassName = "Cơ Khí 2", DepartmentId = Guid.Parse("3c1f9665-f8f7-42e2-8c38-4ef4f02b4bcf"), Amount = 75 }
               );

            // STUDENT
            modelBuilder.Entity<Student>().HasData(
                new Student { StudentId = Guid.Parse("49dc19eb-df89-476d-8974-31b86aeb4344"), StudentName = "Nguyễn Đức Bảo Sơn", Address = "Bắc Ninh", ClassId = Guid.Parse("5e1edcf4-7a25-491c-be13-0f30e69f9d41"), DateOfBirth = new DateTime(2001, 9, 2), Description = "No", Status = Status.Actived }
                ); ;

            modelBuilder.Entity<Student>().HasData(
                new Student { StudentId = Guid.Parse("a9121c32-faa1-4394-803b-d064672a3a41"), StudentName = "Nguyễn Quang Trung", Address = "Hà Nội", ClassId = Guid.Parse("5e1edcf4-7a25-491c-be13-0f30e69f9d41"), DateOfBirth = new DateTime(2001, 12, 25), Description = "No", Status = Status.Actived }
                ); ;

            modelBuilder.Entity<Student>().HasData(
                new Student { StudentId = Guid.Parse("7c460a79-b7aa-4266-b0b2-825d9b4cf509"), StudentName = "Nguyễn Mạnh Hiệp", Address = "Bắc Giang", ClassId = Guid.Parse("627ca7ba-82de-442e-80fc-a99b59f28286"), DateOfBirth = new DateTime(2001, 1, 4), Description = "No", Status = Status.Actived }
                ); ;

            modelBuilder.Entity<Student>().HasData(
                new Student { StudentId = Guid.Parse("aba5aae7-739b-4484-8448-7a7edd8db5a1"), StudentName = "Vũ Hoàng Minh", Address = "Hà Nội", ClassId = Guid.Parse("b41f3593-f66b-4b24-b82e-9b4af5294f7b"), DateOfBirth = new DateTime(2003, 12, 4), Description = "No", Status = Status.Actived }
                ); ;

            modelBuilder.Entity<Student>().HasData(
                new Student { StudentId = Guid.Parse("e9211e39-c43c-4c42-a2ad-6bb41ac928e5"), StudentName = "Đoàn Duy Anh", Address = "Hải Dương", ClassId = Guid.Parse("627ca7ba-82de-442e-80fc-a99b59f28286"), DateOfBirth = new DateTime(1999, 12, 8), Description = "No", Status = Status.Block }
                ); ;

            modelBuilder.Entity<Student>().HasData(
                new Student { StudentId = Guid.Parse("f67db176-22d1-4420-b683-8ab761a46948"), StudentName = "Phan Tiến Anh", Address = "Hà Nội", ClassId = Guid.Parse("627ca7ba-82de-442e-80fc-a99b59f28286"), DateOfBirth = new DateTime(2000, 2, 2), Description = "No", Status = Status.Actived }
                ); ;

            modelBuilder.Entity<Student>().HasData(
                new Student { StudentId = Guid.Parse("31923cf0-edb4-49c7-ab24-a06aa8844095"), StudentName = "Ngô Ngọc Đức", Address = "Hà Nội", ClassId = Guid.Parse("b41f3593-f66b-4b24-b82e-9b4af5294f7b"), DateOfBirth = new DateTime(2000, 12, 25), Description = "No", Status = Status.Block }
                ); ;

            modelBuilder.Entity<Student>().HasData(
                new Student { StudentId = Guid.Parse("c471576f-eb74-4c3d-8071-f78e5954d959"), StudentName = "Nguyễn Thị Khánh", Address = "Nam Định", ClassId = Guid.Parse("3fdddd8a-76c9-456e-bf35-5211f599016f"), DateOfBirth = new DateTime(1998, 4, 4), Description = "No", Status = Status.Actived }
                );

            modelBuilder.Entity<Student>().HasData(
    new Student { StudentId = Guid.Parse("8b1ebf96-8589-4954-875e-87e04c830a04"), StudentName = "Lê Kiến Trúc", Address = "Thái Bình", ClassId = Guid.Parse("b41f3593-f66b-4b24-b82e-9b4af5294f7b"), DateOfBirth = new DateTime(2001, 12, 25), Description = "No", Status = Status.Block }
    );

            ///SUBJECT
            modelBuilder.Entity<Subject>().HasData(
    new Subject { SubjectId = Guid.Parse("3ca5fd36-8f24-4b2d-9292-1ea2772a30d6"), SubjectName = "Lập Trình Web", Description = "No", TeacherId = Guid.Parse("d9a47258-d809-4fa1-b241-59ac8c01a50d") }
    );
            modelBuilder.Entity<Subject>().HasData(
    new Subject { SubjectId = Guid.Parse("a1e6eb19-c594-42a9-9d2b-1f751baffa73"), SubjectName = "An Ninh Mạng", Description = "No", TeacherId = Guid.Parse("016de7a6-40a2-45c6-80f7-786810f00d27") }
    );
            modelBuilder.Entity<Subject>().HasData(
    new Subject { SubjectId = Guid.Parse("48c76b9b-f83e-44b4-a3ca-1687859e84f9"), SubjectName = "Trí Tuệ Nhân Tạo", Description = "No", TeacherId = Guid.Parse("d9a47258-d809-4fa1-b241-59ac8c01a50d") }
    );      
            modelBuilder.Entity<Subject>().HasData(
    new Subject { SubjectId = Guid.Parse("5c54dc1b-c003-4408-a7b8-84336e8fc16c"), SubjectName = "Lịch Sử Đảng", Description = "No", TeacherId = Guid.Parse("b65a41d6-c25c-4867-8b7f-a3f52a57bc26") }
    );
            modelBuilder.Entity<Subject>().HasData(
    new Subject { SubjectId = Guid.Parse("5a139003-5612-4a46-9e80-bf13c8f0a9ed"), SubjectName = "Đại Số Tuyến Tính", Description = "No", TeacherId = Guid.Parse("2f043c43-cfd6-4948-9a9d-78ec32df6a9c") }
    );
            modelBuilder.Entity<Subject>().HasData(
    new Subject { SubjectId = Guid.Parse("463a34c9-6b74-4a41-8b07-8cc2c8c1e7bf"), SubjectName = "Cơ Sở Dữ Liệu", Description = "No", TeacherId = Guid.Parse("8fa7e6e3-2eab-479c-865a-033694979b04") }
    );
            modelBuilder.Entity<Subject>().HasData(
    new Subject { SubjectId = Guid.Parse("8a9c8ce1-9df1-48f7-aa6f-0d3ac1b9813b"), SubjectName = "Xử Lý Ảnh", Description = "No", TeacherId = Guid.Parse("016de7a6-40a2-45c6-80f7-786810f00d27") }
    );
            modelBuilder.Entity<Subject>().HasData(
    new Subject { SubjectId = Guid.Parse("7721a15a-b8e0-4fdc-a561-0b660da56c03"), SubjectName = "Khai Phá Dữ Liệu", Description = "No", TeacherId = Guid.Parse("0250e0e8-2ee9-43dc-8e13-7a0a0fda5e2a") }
    );
            modelBuilder.Entity<ClassRoom>().HasData(
    new ClassRoom { ClassRoomId = Guid.Parse("34c65d1b-cc7a-4d94-8723-ab5cdcce98a7"), ClassRoomName = "Room 303A7", Description = "No" }
    );
            //                // TEACHER
            modelBuilder.Entity<Teacher>().HasData(
    new Teacher { TeacherId = Guid.Parse("d9a47258-d809-4fa1-b241-59ac8c01a50d"), TeacherName = "Bùi Ngọc Dũng", Description = "No", }
    );
            modelBuilder.Entity<Teacher>().HasData(
    new Teacher { TeacherId = Guid.Parse("0250e0e8-2ee9-43dc-8e13-7a0a0fda5e2a"), TeacherName = "Nguyễn Kim Sao", Description = "No", }
    );
            modelBuilder.Entity<Teacher>().HasData(
    new Teacher { TeacherId = Guid.Parse("2f043c43-cfd6-4948-9a9d-78ec32df6a9c"), TeacherName = "Nguyễn Thu Phương", Description = "No", }
    );
            modelBuilder.Entity<Teacher>().HasData(
    new Teacher { TeacherId = Guid.Parse("016de7a6-40a2-45c6-80f7-786810f00d27"), TeacherName = "Thiều Trần Cường", Description = "No", }
    );
            modelBuilder.Entity<Teacher>().HasData(
    new Teacher { TeacherId = Guid.Parse("b65a41d6-c25c-4867-8b7f-a3f52a57bc26"), TeacherName = "Đào Như Quỳnh", Description = "No", }
    );
            modelBuilder.Entity<Teacher>().HasData(
    new Teacher { TeacherId = Guid.Parse("8fa7e6e3-2eab-479c-865a-033694979b04"), TeacherName = "Nguyễn Gia Quý", Description = "No", }
    );

            //SUBJECT_STUDENT
            modelBuilder.Entity<Subject_Student>().HasData(
                new Subject_Student { StudentId = Guid.Parse("31923cf0-edb4-49c7-ab24-a06aa8844095"), SubjectId = Guid.Parse("8a9c8ce1-9df1-48f7-aa6f-0d3ac1b9813b"), Status = Enum.Status.Pass, Mark = 7 },
                new Subject_Student { StudentId = Guid.Parse("8b1ebf96-8589-4954-875e-87e04c830a04"), SubjectId = Guid.Parse("48c76b9b-f83e-44b4-a3ca-1687859e84f9"), Status = Enum.Status.Inprocess },
                new Subject_Student { StudentId = Guid.Parse("aba5aae7-739b-4484-8448-7a7edd8db5a1"), SubjectId = Guid.Parse("3ca5fd36-8f24-4b2d-9292-1ea2772a30d6"), Status = Enum.Status.Inprocess },
                new Subject_Student { StudentId = Guid.Parse("f67db176-22d1-4420-b683-8ab761a46948"), SubjectId = Guid.Parse("463a34c9-6b74-4a41-8b07-8cc2c8c1e7bf"), Status = Enum.Status.Inprocess },
                new Subject_Student { StudentId = Guid.Parse("49dc19eb-df89-476d-8974-31b86aeb4344"), SubjectId = Guid.Parse("7721a15a-b8e0-4fdc-a561-0b660da56c03"), Status = Enum.Status.Inprocess }
                );

            modelBuilder.Entity<User>().HasData(
                new User { UserId = Guid.Parse("16cf8c42-8e65-4772-9862-84c84efc10b1"),UserName="Admin",Password="Admin",FullName="Nguyễn Đức Bảo Sơn", Description="No",Role="Admin" },
                new User { UserId = Guid.Parse("8791be24-35e1-4e8c-aee9-2e0e9c706609"), UserName = "Giang", Password = "Giang", FullName = "Bùi Linh Giang", Description = "No", Role = "User" }
                );
        }
    }
}
