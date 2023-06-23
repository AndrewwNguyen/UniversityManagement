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
    internal class Subject_StudentConfiguration : IEntityTypeConfiguration<Subject_Student>
    {
        public void Configure(EntityTypeBuilder<Subject_Student> builder)
        {
            builder.HasKey(x => new { x.SubjectId, x.StudentId });
            builder.HasOne(x => x.Student).WithMany(x => x.Subject_Students).HasForeignKey(x => x.StudentId);
            builder.HasOne(x => x.Subject).WithMany(x => x.Subject_Student).HasForeignKey(x => x.SubjectId);
        }
    }
}
