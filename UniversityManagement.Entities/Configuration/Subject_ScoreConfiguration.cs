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
    internal class Subject_ScoreConfiguration : IEntityTypeConfiguration<Subject_Score>
    {
        public void Configure(EntityTypeBuilder<Subject_Score> builder)
        {
            builder.HasKey(x => new { x.IdSubject, x.IdStudent });
            builder.HasOne(x => x.Student).WithMany(x => x.Subject_Scores).HasForeignKey(x => x.IdStudent);
            builder.HasOne(x => x.Subject).WithMany(x => x.Subject_Score).HasForeignKey(x => x.IdSubject);
        }
    }
}
