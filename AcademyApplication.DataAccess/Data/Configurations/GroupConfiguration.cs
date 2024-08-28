using AcademyApplication.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyApplication.Core.Configurations
{
    internal class GroupConfiguration : IEntityTypeConfiguration<Group>
    {
        public void Configure(EntityTypeBuilder<Group> builder)
        {
            builder.Property(s => s.Name).IsRequired(true).HasMaxLength(255);
            builder.Property(s => s.Limit).IsRequired(true);
            builder.HasKey(s => s.Id);
        }
    }
}
