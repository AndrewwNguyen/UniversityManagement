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
    public class ClassRoomConfiguration : IEntityTypeConfiguration<ClassRoom>

    {
        public void Configure(EntityTypeBuilder<ClassRoom> builder)
        {
            builder.ToTable(nameof(ClassRoom));
            builder.HasKey(x => x.IdClassRoom);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
        }
    }
}