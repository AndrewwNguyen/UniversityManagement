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
    public class SubjectConfiguration : IEntityTypeConfiguration<Subject>
    {
        public void Configure(EntityTypeBuilder<Subject> builder)
        {
            builder.ToTable(nameof(Subject));
            builder.HasKey(x => x.IdSubject);
            builder.HasOne(x=>x.Teacher).WithMany(x=>x.Subjects).HasForeignKey(x=>x.IdTeacher);
        }
    }
}
