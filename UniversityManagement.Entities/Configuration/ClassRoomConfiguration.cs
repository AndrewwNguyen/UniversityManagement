using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UniversityManagement.Entities.Models;

namespace UniversityManagement.Entities.Configuration
{
    public class ClassRoomConfiguration : IEntityTypeConfiguration<ClassRoom>

    {
        public void Configure(EntityTypeBuilder<ClassRoom> builder)
        {
            builder.ToTable(nameof(ClassRoom));
            builder.HasKey(x => x.ClassRoomId);
            builder.Property(x => x.ClassRoomName).IsRequired().HasMaxLength(100);
        }
    }
}