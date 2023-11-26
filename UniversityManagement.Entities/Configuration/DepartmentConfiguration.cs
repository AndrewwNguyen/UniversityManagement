using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UniversityManagement.Entities.Models;

namespace UniversityManagement.Entities.Configuration
{
    public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.ToTable(nameof(Department));
            builder.HasKey(x => x.DepartmentId);
            builder.Property(x => x.DepartmentName).IsRequired().HasMaxLength(100);
        }
    }
}
