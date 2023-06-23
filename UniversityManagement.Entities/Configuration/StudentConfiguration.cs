using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityManagement.Entities.Models;

namespace UniversityManagement.Entities.Configuration
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.ToTable(nameof(Student));
            builder.HasKey(x => x.StudentId);
            builder.Property(x=>x.StudentName).IsRequired().HasMaxLength(100);
            builder.HasOne(x=>x.Class).WithMany(x=>x.Students).HasForeignKey(x=>x.ClassId);
        }
    }
}
