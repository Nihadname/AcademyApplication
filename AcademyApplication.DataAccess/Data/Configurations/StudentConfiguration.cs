using AcademyApplication.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyApplication.DataAccess.Data.Configurations
{
    internal class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.Property(s => s.Name).IsRequired(true).HasMaxLength(255);
            builder.Property(s => s.FileName).IsRequired(true);
            builder.Property(s => s.Email).IsRequired(true).HasMaxLength(100);
            builder.HasOne(s => s.Group).WithMany(g => g.Students)
                .HasForeignKey(s => s.GroupId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
