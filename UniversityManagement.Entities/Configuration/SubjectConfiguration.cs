using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UniversityManagement.Entities.Models;

namespace UniversityManagement.Entities.Configuration
{
    public class SubjectConfiguration : IEntityTypeConfiguration<Subject>
    {
        public void Configure(EntityTypeBuilder<Subject> builder)
        {
            builder.ToTable(nameof(Subject));
            builder.HasKey(x => x.SubjectId);
            builder.HasOne(x => x.Teacher).WithMany(x => x.Subjects).HasForeignKey(x => x.TeacherId);
        }
    }
}
