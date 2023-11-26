using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UniversityManagement.Entities.Models;

namespace UniversityManagement.Entities.Configuration
{
    public class Subject_ClassroomConfiguration : IEntityTypeConfiguration<Subject_Classroom>
    {
        public void Configure(EntityTypeBuilder<Subject_Classroom> builder)
        {
            builder.HasKey(x => new { x.SubjectId, x.ClassRoomId });
            builder.HasOne(x => x.ClassRoom).WithMany(x => x.Subject_Classrooms).HasForeignKey(x => x.ClassRoomId);
            builder.HasOne(x => x.Subject).WithMany(x => x.Subject_Classroom).HasForeignKey(x => x.SubjectId);
        }
    }
}
